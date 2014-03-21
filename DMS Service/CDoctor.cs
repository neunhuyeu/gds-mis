using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DMS_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IDoctor" in both code and config file together.
    public class CDoctor : IDoctor
    {
        DbConnection dbConnection;
        SqlCredential cred;

        public BusinessLayer businessLayer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public CDoctor(){
            dbConnection = new DbConnection(cred);
        }

        //what does this do? does it return the list of patients the doctor has? it's void so what does this do...should I add the parameter userID, so it returns user by id?
        public void getPatient()
        {
            throw new System.NotImplementedException();
        }

        
        public Patient getPatientOverview(int patientID)
        {
            Patient patient = new Patient();
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT * FROM patients,consultations WHERE patient_id = @patient_id");

            SqlParameter[] Parameter = new SqlParameter[1];
            Parameter[1] = new SqlParameter("@patient_id",SqlDbType.Int);   
            Parameter[1].Value = Convert.ToString(patientID);

            dataTable = dbConnection.SelectQuery(query, Parameter);

            foreach (DataRow row in dataTable.Rows)
            {

                patient.PatientID = Convert.ToInt32(row["patient_id"]);
                patient.DiagnosisId = Convert.ToInt32(row["diagnos_id"]);
                patient.ConsultationId = Convert.ToInt32(row["consultation_id"]);
                patient.PrescriptionId = Convert.ToInt32(row["prescription_id"]);

                patient.FirstName = row["first_name"].ToString();
                patient.LastName = row["last_name"].ToString();
                patient.DateOfBirth = row["date_of_birth"].ToString();
                patient.Email = row["email_address"].ToString();
                patient.Address = row["home_address"].ToString();

                patient.Gender = Convert.ToChar(row["gender"]);
                patient.Height = Convert.ToInt32(row["height_cm"]);
                patient.Weight = Convert.ToInt32(row["weight_kg"]);
                patient.BloodType = Convert.ToChar(row["blood_type"]);
                patient.Smoker = Convert.ToBoolean(row["smoking"]);
                patient.InsuranceNumber = Convert.ToInt32(row["InsuranceNumber"]);
            }
            return patient;
        }

        //I have assumed, that the diagnosis column in the table contains the diseases, and they are seperated by a comma..hence the string.split()
        public List<string> getPatientDiseases(int patientID)
        {
            Patient patient = this.getPatientOverview(patientID);
            List<string> diseases = new List<string>();
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT diagnosis FROM diagnosis WHERE diagnosis_id = @diagId");

            SqlParameter[] Parameter = new SqlParameter[1];
            Parameter[1] = new SqlParameter("@diagId", SqlDbType.Int);
            Parameter[1].Value = Convert.ToString(patient.DiagnosisId);

            dataTable = dbConnection.SelectQuery(query, Parameter);
            DataRow row = dataTable.Rows[0];
            string diagnosis = row["diagnosis"].ToString();

            diseases = diagnosis.Split(',').ToList();
            return diseases;
        }

        //couldn't find 'canceled' in the database design, should be added..
        public List<Appointment> getPatientAppointments(int patientID)
        {
            Patient patient = this.getPatientOverview(patientID);
            Appointment appointment = new Appointment();
            List<Appointment> appointments = new List<Appointment>();
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT * FROM consultation_details WHERE consultation_id = @ConsulId");

            SqlParameter[] Parameter = new SqlParameter[1];
            Parameter[1] = new SqlParameter("@ConsulId", SqlDbType.Int);
            Parameter[1].Value = Convert.ToString(patient.ConsultationId);

            dataTable = dbConnection.SelectQuery(query, Parameter);

            foreach (DataRow row in dataTable.Rows)
            {
                appointment.startTime = Convert.ToDateTime(row["start"]);
                appointment.endTime = Convert.ToDateTime(row["end"]);
                appointment.canceled = Convert.ToBoolean(row["canceled"]);
                appointments.Add(appointment);
            }
            return appointments;
        }

        //dosage and doctor needs to be added to the database design to the prescription table
        //ALSO WE NEED TO BE CLEAR HOW WE SPELL THINGS..this method says "perscription"...in the database design it says "prescribtion"
        //it should be "prescription"
        public List<Perscription> getPatientPerscriptions(int patientID)
        {
            Patient patient = this.getPatientOverview(patientID);
            Perscription prescription = new Perscription();
            List<Perscription> prescriptionlist = new List<Perscription>();
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT * FROM prescribtion WHERE prescribtion_id = @PrescId");

            SqlParameter[] Parameter = new SqlParameter[1];
            Parameter[1] = new SqlParameter("@PrescId", SqlDbType.Int);
            Parameter[1].Value = Convert.ToString(patient.PrescriptionId);

            dataTable = dbConnection.SelectQuery(query, Parameter);

            foreach (DataRow row in dataTable.Rows)
            {
                prescription.Drug = row["medicine"].ToString();
                prescription.Dosage = Convert.ToInt32(row["dosage"]);
                prescription.Doctor = row["doctor"].ToString();
                prescription.Date = Convert.ToDateTime(row["date_prescribed"]);

                prescriptionlist.Add(prescription);
            }
            return prescriptionlist;
        }

        //how do I do the login? I found the staff with the email, and it will return this one....but WHERE do I login?
        public Staff login(string email, string password)
        {
            Staff staff = new Staff();
            
            DataTable dataTable = new DataTable();
            string query = string.Format("SELECT * FROM person p,staff_members s ON p.person_id = s.person_id  WHERE p.email_address = @email");

            SqlParameter[] Parameter = new SqlParameter[1];
            Parameter[1] = new SqlParameter("@email", SqlDbType.Char);
            Parameter[1].Value = Convert.ToString(email);

            dataTable = dbConnection.SelectQuery(query, Parameter);

            foreach (DataRow row in dataTable.Rows)
            {
                staff.FirstName = row["first_name"].ToString();
                staff.LastName = row["last_name"].ToString();
                staff.Function = (Staff.StaffType)Enum.Parse(typeof(Staff.StaffType), row["function"].ToString());
                staff.RoomNumber = Convert.ToInt32(row["room_number"]);
                staff.Specialization = row["specialization"].ToString();
            }

            return staff;
        }

        
        public void logout(string email)
        {
            throw new System.NotImplementedException();
        }

        
        public List<Patient> search(string name, string dateOfBirth, string insuranceNumber)
        {
            throw new System.NotImplementedException();
        }

        
        public string setPerscription(int appointmentID, Perscription perscription)
        {
            throw new System.NotImplementedException();
        }

        public void registerPatient()
        {
            throw new System.NotImplementedException();
        }
    }
}
