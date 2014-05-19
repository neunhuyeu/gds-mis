using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;
using DMS_Service.user_auth;
using DMS_Service.wiki;
using DMS_Service.Structs;

namespace DMS_Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BusinessLayer : IDoctor
    {
        private DbAccessLayer dbAcess;
        private wiki_business wiki_access;

        public BusinessLayer()
        {
            dbAcess = new DbAccessLayer();
            wiki_access = new wiki_business();
        }

        /// <summary>
        /// To get the patient as a person. This function could be used by the secratery to get the contact info
        /// of a  person without having access to see his medical private info.
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns>return patient object</returns>
        public Patient GetPatient_by_lastName_DateOfBirth(string lastName, string dateOfBirth)
        {
            Patient patient = new Patient();
            DataTable dataTable = new DataTable();

            //using search person from the person table
            dataTable = dbAcess.SearchPatient_lastName_dateOfBirth(lastName, dateOfBirth);

            foreach (DataRow dr in dataTable.Rows)
            {
                patient.PersonId = Convert.ToInt32(dr["person_id"]);
                patient.FirstName = dr["first_name"].ToString();
                patient.LastName = dr["last_name"].ToString();
                patient.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]);
                patient.Email = dr["email_address"].ToString();
                patient.MobileNumber = dr["mobile_number"].ToString();
                patient.LandLineNumber = dr["landline_number"].ToString();
                patient.Address = dr["home_address"].ToString();
            }
            return patient;
        }

        public Patient GetPatientOverview(int personID)
        {
            Patient patient = new Patient();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchPatientById(personID);

            foreach (DataRow row in dataTable.Rows)
            {
                patient.PatientID = Convert.ToInt32(row["patient_id"]);
                patient.Gender = Convert.ToString(row["gender"])[0];
                patient.Height = Convert.ToInt32(row["height_cm"]);
                patient.Weight = Convert.ToInt32(row["weight_kg"]);
                patient.BloodType = Convert.ToString(row["blood_type"])[0];
                patient.Smoker = Convert.ToBoolean(row["smoking"]);
                patient.InsuranceNumber = Convert.ToString(row["insurance_number"]);
            }  
            return patient;
        }

        public Staff GetStaff_by_Personid(int id)
        {
            Staff staff = new Staff();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchStaffByPersonId(id);

            foreach (DataRow dr in dataTable.Rows)
            {
                staff.PersonId = Convert.ToInt32(dr["person_id"]);
                staff.FirstName = dr["first_name"].ToString();
                staff.LastName = dr["last_name"].ToString();
                staff.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"].ToString());
                staff.Email = dr["email_address"].ToString();
                staff.MobileNumber = dr["mobile_number"].ToString();
                staff.LandLineNumber = dr["landline_number"].ToString();
                staff.Address = dr["home_address"].ToString();
            }
            return staff;
        }
        public Staff GetStaff_by_staff_id(int id)
        {
            Staff staff = new Staff();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchStaffByStaffId(id);

            foreach (DataRow dr in dataTable.Rows)
            {
                staff.PersonId = Convert.ToInt32(dr["person_id"]);
                staff.FirstName = dr["first_name"].ToString();
                staff.LastName = dr["last_name"].ToString();
                staff.DateOfBirth = Convert.ToDateTime( dr["date_of_birth"]);
                staff.Email = dr["email_address"].ToString();
                staff.MobileNumber = dr["mobile_number"].ToString();
                staff.LandLineNumber = dr["landline_number"].ToString();
                staff.Address = dr["home_address"].ToString();
            }
            return staff;
        }

        //I have assumed, that the diagnosis column in the table contains the diseases, and they are seperated by a comma..hence the string.split()
        public List<string> GetPatientDiseases(int patientID)
        {
            throw new System.NotImplementedException();
        }

        //couldn't find 'canceled' in the database design, should be added..
        public List<Appointment> getPatientAppointments(int patientID)
        {
            throw new System.NotImplementedException();
            //Patient patient = this.GetPatientOverview(patientID);
            //Appointment appointment = new Appointment();
            //List<Appointment> appointments = new List<Appointment>();
            //DataTable dataTable = new DataTable();
            //string query = string.Format("SELECT * FROM consultation_details WHERE consultation_id = @ConsulId");

            //SqlParameter[] Parameter = new SqlParameter[1];
            //Parameter[1] = new SqlParameter("@ConsulId", SqlDbType.Int);
            //Parameter[1].Value = Convert.ToString(patient.ConsultationId);

            //dataTable = dbConnection.SelectQuery(query, Parameter);

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    appointment.startTime = Convert.ToDateTime(row["start"]);
            //    appointment.endTime = Convert.ToDateTime(row["end"]);
            //    appointment.canceled = Convert.ToBoolean(row["canceled"]);
            //    appointments.Add(appointment);
            //}
            //return appointments;
        }

        //dosage and doctor needs to be added to the database design to the prescription table
        //ALSO WE NEED TO BE CLEAR HOW WE SPELL THINGS..this method says "perscription"...in the database design it says "prescribtion"
        //it should be "prescription"
        public List<Perscription> getPatientPerscriptions(int patientID)
        {


            //Patient patient = this.GetPatientOverview(patientID);
            Perscription prescription = new Perscription();
            List<Perscription> prescriptionlist = new List<Perscription>();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchprescriptionListByID(patientID);
           
            foreach (DataRow row in dataTable.Rows)
            {
                prescription.Medicine = row["medicine"].ToString();
                prescription.Strength = Convert.ToInt32(row["strength_mg"]);
                prescription.Doctor = GetStaff_by_staff_id( Convert.ToInt32( row["Staff_id"])).LastName;
                prescription.Date = Convert.ToDateTime(row["date_prescribed"]);

                prescriptionlist.Add(prescription);
            }
            return prescriptionlist;
        }

        //how do I do the login? I found the staff with the email, and it will return this one....but WHERE do I login?
        public Staff Login(string email, string password)
        {
            Staff staff = new Staff();
            DataTable dataTable = new DataTable();

            //Business layer for the user authentication
            user_auth_business user_auth = new user_auth_business();
            
            //if the user credentails are correct then the search by mail is done to find the staff member
            //if no staff member is found matching the credentails provided the user will still not be 
            //logged in.  a failsafe of sorts is in place
            if (user_auth.login(email, password))
            {
                dataTable = dbAcess.SearchStaffByEmail(email);
            }
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    staff.FirstName = row["first_name"].ToString();
                    staff.LastName = row["last_name"].ToString();
                    staff.StaffID = Convert.ToInt32(row["Staff_id"]);

                    //staff.Function = (Staff.StaffType)Enum.Parse(typeof(Staff.StaffType), row["function"].ToString());
                    //staff.RoomNumber = Convert.ToInt32(row["room_number"]);
                    //staff.Specialization = row["specialization"].ToString();
                    
                }
                return staff;
            }
            return null;
        }

        public DataTable getStaff()
        {
            throw new System.NotImplementedException();
        }


        public List<Patient> SearchPatients(string first, string last, DateTime dateOfBirth, string insurance)
        {
            List<Patient> patients = new List<Patient>();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchPatientsList(first, last,dateOfBirth , insurance);
            if (dataTable==null)
            {
                return null;
            }
            foreach (DataRow dr in dataTable.Rows)
            {
                Patient p = new Patient();
                p.PersonId = Convert.ToInt32(dr["person_id"]);
                p.PatientID = Convert.ToInt32(dr["patient_id"]);
                p.FirstName = dr["first_name"].ToString();
                p.LastName = dr["last_name"].ToString();
                p.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]);
                p.Email = dr["email_address"].ToString();
                p.Gender = dr["gender"].ToString()[0];
                p.MobileNumber = dr["mobile_number"].ToString();
                p.LandLineNumber = dr["landline_number"].ToString();
                p.Address = dr["home_address"].ToString();
                p.InsuranceNumber = dr["insurance_number"].ToString();
                patients.Add(p);
            }

            return patients;
        }

        public string setPerscription(int appointmentID, Perscription perscription)
        {
            throw new NotImplementedException();
        }
        public bool addPerscription(int appointmentID, Perscription perscription)
        {
            return dbAcess.addPrescrption(perscription, appointmentID);
        }
       public int getnextConsultationID()
        {
            DataTable dt= dbAcess.getLatestConsultationID();
           foreach(DataRow dr in dt.Rows)
           {
               return Convert.ToInt32(dr["latest"]) + 1;
           }
           
           return Convert.ToInt32( dt.Rows[0])+1;
        }


       public List<Consultation> getConsultationHistorybyPatient(int Patientid)
       {
           List<Consultation> myconsultions= new List<Consultation>();
           DataTable dataTable = dbAcess.SearchconsultionHistoryByPersionID(Patientid);

           foreach (DataRow row in dataTable.Rows)
           {
               Consultation consultation = new Consultation();

               consultation.Start_date =Convert.ToDateTime( row["start_date"]);
               consultation.ConsultationID = Convert.ToInt32(row["consultation_id"]);

               myconsultions.Add(consultation);
           }
           return myconsultions;
       }

       public List<Consultation> SearchconsultionHistoryByStaffID(int staffId)
       {
           List<Consultation> myconsultions = new List<Consultation>();
           DataTable dataTable = dbAcess.SearchconsultionHistoryByStaffID(staffId);

           foreach (DataRow row in dataTable.Rows)
           {
               Consultation consultation = new Consultation();

               consultation.Start_date = Convert.ToDateTime(row["start_date"]);
               consultation.ConsultationID = Convert.ToInt32(row["consultation_id"]);

               myconsultions.Add(consultation);
           }
           return myconsultions;
       }


       public List<Consultation> getConsultationOfToday(int staffID)
       {
           List<Consultation> myconsultions = new List<Consultation>();
           DataTable dataTable = dbAcess.SearchconsultationsOfToday(staffID);

           foreach (DataRow row in dataTable.Rows)
           {
               Consultation consultation = new Consultation();

               consultation.Start_date = Convert.ToDateTime(row["start_date"]);
               consultation.ConsultationID = Convert.ToInt32(row["consultation_id"]);
               consultation.End_date = Convert.ToDateTime(row["end_date"]);
               consultation.Staff_id = Convert.ToInt32(row["Staff_id"]);
               consultation.Patient_id = Convert.ToInt32(row["patient_id"]);

               myconsultions.Add(consultation);
           }
           return myconsultions;
       }

       //public List<Patient> SearchConsultationsbyDate(DateTime date, int staffId)
       //{
       //    List<Patient> mypersons = new List<Patient>();
       //    DataTable dataTable = dbAcess.SearchConsultationsbyDate(date, staffId);

       //    foreach (DataRow row in dataTable.Rows)
       //    {
       //        Patient person = new Patient();

       //        person.PersonId = Convert.ToInt32(row["person_id"]);
       //        person.FirstName = Convert.ToString(row["first_name"]);
       //        person.LastName = Convert.ToString(row["last_name"]);
       //        person.DateOfBirth = Convert.ToDateTime(row["date_of_birth"]);

       //        mypersons.Add(person);
       //    }
       //    return mypersons;
       //}
        




       public List<Diagnosis> getDiagnosisHistoryByPersionID(int Patientid)
       {
           List<Diagnosis> myDiagnosis = new List<Diagnosis>();
           DataTable dataTable = dbAcess.SearchDiagnosisHistoryByPersionID(Patientid);
           foreach (DataRow row in dataTable.Rows)
           {
               Diagnosis diagnosis = new Diagnosis();
              
               diagnosis.Consultation_id = Convert.ToInt32(row["consultation_id"]);
               diagnosis.Diagnosises = row["diagnosis"].ToString();
               diagnosis.Symptoms = row["symptoms"].ToString();
               diagnosis.Date = Convert.ToDateTime(row["start_date"]);
               Staff doc =GetStaff_by_staff_id(Convert.ToInt32(row["Staff_id"]));
               diagnosis.DoctorName = doc.FirstName + " " + doc.LastName;
               

               myDiagnosis.Add(diagnosis);
           }
           return myDiagnosis;

       }

        public void addTestPatient()
        {
            
            DMS_Service.MySynchroniseService.SynchroniseClient proxy;

            Patient dude = new Patient();

            dude.FirstName = "Homer";
            dude.LastName = "Simpson";
            dude.Height = 180;
            dude.Weight = 100;
            dude.Smoker = false;
            dude.SmokingFrequency = 0;
            dude.MobileNumber = "12345";
            dude.LandLineNumber = "54321";
            dude.InsuranceNumber = "222222";
            dude.DateOfBirth = new DateTime(1960,5,5);
            dude.Email = "Homer@lol.com";
            dude.Address = "springfield";


            DMS_Service.MySynchroniseService.Patient sameDude;
            sameDude = new DMS_Service.MySynchroniseService.Patient();

            sameDude.FirstNamek__BackingField = dude.FirstName;
            sameDude.LastNamek__BackingField = dude.LastName;
            sameDude.Heightk__BackingField = dude.Height;
            sameDude.Weightk__BackingField = dude.Weight;
            sameDude.Smokerk__BackingField = dude.Smoker;
            sameDude.SmokingFrequencyk__BackingField = dude.SmokingFrequency;
            sameDude.MobileNumberk__BackingField = dude.MobileNumber;
            sameDude.LandLineNumberk__BackingField = dude.LandLineNumber;
            sameDude.InsuranceNumberk__BackingField = dude.InsuranceNumber;
            sameDude.DateOfBirthk__BackingField = dude.DateOfBirth;
            sameDude.Emailk__BackingField = dude.Email;
            sameDude.Addressk__BackingField = dude.Address;

            //add to own database
            dbAcess.addPatient(dude);
            
            //add tot he other server
            try
            {
                proxy = new DMS_Service.MySynchroniseService.SynchroniseClient();
                proxy.addPatient(sameDude);
            }
            catch(TimeoutException)
            {
                MessageBox.Show("couldn't connect to other server");
            }
            catch
            {

            }
            
            
            


        }

        
        public void addTestAppointment()
        {
            //create the sync proxy
            DMS_Service.MySynchroniseService.SynchroniseClient proxy;
           
            //create the the test appointment
            Appointment appoinment = new Appointment();
            appoinment.startTime = new DateTime(2014, 1, 1, 13, 0, 0);
            appoinment.endTime = new DateTime(2014, 1, 1, 13, 30, 0);
            //appoinment.Staff = new Staff();
            //appoinment.Staff.StaffID = 1;
            //appoinment.Patient = new Patient();
            //appoinment.Patient.PatientID = 1;

            DMS_Service.MySynchroniseService.Appointment sameAppointment;
            sameAppointment= new DMS_Service.MySynchroniseService.Appointment();

            
            sameAppointment.startTimek__BackingField = new DateTime(2014, 1, 1, 13, 0, 0);
            sameAppointment.endTimek__BackingField = new DateTime(2014, 1, 1, 13, 30, 0);
            
            
            //Add appointment to own database   
            dbAcess.addAppointment(appoinment);

            //Add appointment to other server
            try
            {
                proxy = new DMS_Service.MySynchroniseService.SynchroniseClient();
                proxy.addAppointment(sameAppointment);
                
            }
            catch(TimeoutException)
            {
                MessageBox.Show("couldn't connect to other server");
            }
            catch
            {

            }
            
        }
        public bool updateConsultion_End_Date(Consultation currentConultion)
       {
           return dbAcess.updateConsultionEnd_date(currentConultion);
       }
        public bool addDiagnosis(Diagnosis diagnosis)
        {
            return dbAcess.addDiagnosis(diagnosis);
        }
       public bool addConsultion(Consultation currentConsultation)
       {
         return  dbAcess.addConsultion(currentConsultation);
       }

       public List<Structs.Disease> get_all_diseases()
       {
           return wiki_access.get_all_diseases();
       }

       public List<Structs.Disease> search_disease(string name, string symptoms, string classification)
       {
           return wiki_access.search_disease(name, symptoms, classification);
       }

       public List<Structs.Medicine> get_all_medicines()
       {
           return wiki_access.get_all_medicines();
       }

       public List<Structs.Medicine> search_medicine(string name, string side_effects, string classification)
       {
           return wiki_access.search_medicine(name, side_effects, classification);
       }
    }
}
