using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ServiceModel;


namespace DMS_Service
{
    // Kirolos
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BusinessLayer : IDoctor
    {
        private DbAccessLayer dbAcess;

        public BusinessLayer()
        {
            dbAcess = new DbAccessLayer();
        }

        //Kirolos
        /// <summary>
        /// To get the patient as a person. This function could be used by the secratery to get the contact info
        /// of a  person without having access to see his medical private info.
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns>return patient object</returns>
        public Patient GetPatient_by_lastName_DateOfBirth(string lastName, DateTime dateOfBirth)
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
                patient.DateOfBirth = dr["date_of_birth"].ToString();
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
                patient.Gender = Convert.ToChar(row["gender"]);
                patient.Height = Convert.ToInt32(row["height_cm"]);
                patient.Weight = Convert.ToInt32(row["weight_kg"]);
                patient.BloodType = Convert.ToChar(row["blood_type"]);
                patient.Smoker = Convert.ToBoolean(row["smoking"]);
                //patient.InsuranceNumber = Convert.ToInt32(row["InsuranceNumber"]);
            }
            return patient;
        }

        //Kirolos
        public Staff GetStaff_by_id(int id)
        {
            Staff staff = new Staff();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchStaffById(id);

            foreach (DataRow dr in dataTable.Rows)
            {
                staff.PersonId = Convert.ToInt32(dr["person_id"]);
                staff.FirstName = dr["first_name"].ToString();
                staff.LastName = dr["last_name"].ToString();
                staff.DateOfBirth = dr["date_of_birth"].ToString();
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
            //Patient patient = this.GetPatientOverview(patientID);
            //List<string> diseases = new List<string>();
            //DataTable dataTable = new DataTable();
            //string query = string.Format("SELECT diagnosis FROM diagnosis WHERE diagnosis_id = @diagId");

            //SqlParameter[] Parameter = new SqlParameter[1];
            //Parameter[1] = new SqlParameter("@diagId", SqlDbType.Int);
            //Parameter[1].Value = Convert.ToString(patient.DiagnosisId);

            //dataTable = dbConnection.SelectQuery(query, Parameter);
            //DataRow row = dataTable.Rows[0];
            //string diagnosis = row["diagnosis"].ToString();

            //diseases = diagnosis.Split(',').ToList();
            //return diseases;
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
            throw new System.NotImplementedException();
            //Patient patient = this.GetPatientOverview(patientID);
            //Perscription prescription = new Perscription();
            //List<Perscription> prescriptionlist = new List<Perscription>();
            //DataTable dataTable = new DataTable();
            //string query = string.Format("SELECT * FROM prescribtion WHERE prescribtion_id = @PrescId");

            //SqlParameter[] Parameter = new SqlParameter[1];
            //Parameter[1] = new SqlParameter("@PrescId", SqlDbType.Int);
            //Parameter[1].Value = Convert.ToString(patient.PrescriptionId);

            //dataTable = dbConnection.SelectQuery(query, Parameter);

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    prescription.Drug = row["medicine"].ToString();
            //    prescription.Dosage = Convert.ToInt32(row["dosage"]);
            //    prescription.Doctor = row["doctor"].ToString();
            //    prescription.Date = Convert.ToDateTime(row["date_prescribed"]);

            //    prescriptionlist.Add(prescription);
            //}
            //return prescriptionlist;
        }

        //how do I do the login? I found the staff with the email, and it will return this one....but WHERE do I login?
        public Staff login(string email, string password)
        {
            throw new System.NotImplementedException();
            //Staff staff = new Staff();

            //DataTable dataTable = new DataTable();
            //string query = string.Format("SELECT * FROM person p,staff_members s ON p.person_id = s.person_id  WHERE p.email_address = @email");

            //SqlParameter[] Parameter = new SqlParameter[1];
            //Parameter[1] = new SqlParameter("@email", SqlDbType.Char);
            //Parameter[1].Value = Convert.ToString(email);

            //dataTable = dbConnection.SelectQuery(query, Parameter);

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    staff.FirstName = row["first_name"].ToString();
            //    staff.LastName = row["last_name"].ToString();
            //    staff.Function = (Staff.StaffType)Enum.Parse(typeof(Staff.StaffType), row["function"].ToString());
            //    staff.RoomNumber = Convert.ToInt32(row["room_number"]);
            //    staff.Specialization = row["specialization"].ToString();
            //}

            //return staff;
        }

        public DataTable getStaff()
        {
            throw new System.NotImplementedException();
        }


        public List<Patient> search(string name, string dateOfBirth, string insuranceNumber)
        {
            throw new NotImplementedException();
        }

        public string setPerscription(int appointmentID, Perscription perscription)
        {
            throw new NotImplementedException();
        }
    }
}
