using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DMS_Service
{
    // Kirolos
    public class DbAccessLayer
    {
        DbConnection dbConnection;

        public DbAccessLayer()
        {
            dbConnection = new DbConnection();
        }
        
        //Kirolos
        public DataTable SearchPatient_lastName_dateOfBirth(string lastName, DateTime dateOfBirth)
        {
            string query = string.Format("SELECT *" +
                                        "FROM person" + 
                                        "WHERE last_name = @lastName" +
                                        "AND date_of_birth = @dateOfBirth");
            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@lastName", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(lastName);
            sqlParameters[1] = new MySqlParameter("@dateOfBirth", MySqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(dateOfBirth);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable SearchPatientById(int id)
        {
            string query = string.Format("SELECT *" +
                                          "FROM person" +
                                          "JOIN patients" +
                                          "ON person.person_id = patient.person_id");
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            sqlParameters[0].Value = id.ToString();
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        //Kirolos
        public DataTable SearchStaffById(int id)
        {
            string query = "SELECT * FROM Staff_members WHERE person_id = @id";
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(id);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable SearchStaffByEmail(string email)
        {
            try
            {
                string query = "SELECT * FROM person JOIN Staff_members ON person.person_id = Staff_members.person_id" +
                    "HAVING person.email_address = '@email'";
                MySqlParameter[] sqlParameters = new MySqlParameter[1];
                sqlParameters[0] = new MySqlParameter("@email", MySqlDbType.String);
                sqlParameters[0].Value = Convert.ToString(email);
                return dbConnection.SelectQuery(query, sqlParameters);
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// JP.
        /// Adds patient to the database by first adding record to person table and then patient table.
        /// </summary>
        /// <param name="patient">patient to be added</param>
        public void addPatient(Patient patient)
        {
            //query for person table
            string query = "INSERT INTO person(first_name, last_name, date_of_birth, email_address, mobile_number, landline_number, home_addres)" +
                           "VALUES ('@first_name', '@last_name', @date_of_birth, '@email_address', '@mobile_number', '@landline_number', '@home_address')";

            //parameters for person table
            MySqlParameter[] sqlParameters = new MySqlParameter[7];
            sqlParameters[0] = new MySqlParameter("@first_name", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(patient.FirstName);
            sqlParameters[1] = new MySqlParameter("@last_name", MySqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(patient.LastName);
            sqlParameters[2] = new MySqlParameter("@date_of_birth", MySqlDbType.Date);
            sqlParameters[2].Value = Convert.ToString(patient.DateOfBirth);
            sqlParameters[3] = new MySqlParameter("@email_address", MySqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(patient.Email);
            sqlParameters[4] = new MySqlParameter("@mobile_number", MySqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(patient.MobileNumber);
            sqlParameters[5] = new MySqlParameter("@landline_number", MySqlDbType.VarChar);
            sqlParameters[5].Value = Convert.ToString(patient.LandLineNumber);
            sqlParameters[6] = new MySqlParameter("@home_address", MySqlDbType.VarChar);
            sqlParameters[6].Value = Convert.ToString(patient.Address);

            //execute query on person table
            dbConnection.InsertQuery(query, sqlParameters);

            //query for patient table
            query = "INSERT INTO patients (gender, height_cm, weight_kg, blood_type, smoking, smoking_frequency, hard_drugs, hard_drugs_frequency, person_id)" +
                    "VALUES ('@gender', @height_cm, @weight_kg, '@blood_type', @smoking Bool, @smoking_frequency, @hard_drugs, @hard_drugs_frequency, (SELECT MAX(person_ID) FROM person))";


            //parameters for patient table
            sqlParameters = null;
            sqlParameters = new MySqlParameter[9];
            sqlParameters[0] = new MySqlParameter("@gender", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(patient.Gender);
            sqlParameters[1] = new MySqlParameter("@height_cm", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(patient.Height);
            sqlParameters[2] = new MySqlParameter("@weight_kg", MySqlDbType.Int32);
            sqlParameters[2].Value = Convert.ToString(patient.Weight);
            sqlParameters[3] = new MySqlParameter("@blood_type", MySqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(patient.BloodType);
            sqlParameters[4] = new MySqlParameter("@smoking", MySqlDbType.Bit);
            sqlParameters[4].Value = Convert.ToString(patient.Smoker);
            sqlParameters[5] = new MySqlParameter("@smoking_frequency", MySqlDbType.Int32);
            sqlParameters[5].Value = Convert.ToString(patient.SmokingFrequency);

            //TODO: Add correct paameters
            sqlParameters[6] = new MySqlParameter("@hard_drugs", MySqlDbType.Bit);
            sqlParameters[6].Value = false;
            sqlParameters[7] = new MySqlParameter("@smoking_frequency", MySqlDbType.Int32);
            sqlParameters[7].Value = 0;

            //execute query on patient table
            dbConnection.InsertQuery(query, sqlParameters);

            return;
        }

        /// <summary>
        /// JP.
        /// Adds consultation to the conusltation table.
        /// </summary>
        /// <param name="patient">patient to be added</param>
        public void addConsultation(Appointment appointment)
        {
            //query
            string query = "INSERT INTO consultation(start_date, end_date, patient_id, staff_id)" + 
                           "VALUES (@start_date, @end_date, @patient_id, '@staff_id',)";

            //parameters
            MySqlParameter[] sqlParameters = new MySqlParameter[4];
            sqlParameters[0] = new MySqlParameter("@start_date", MySqlDbType.DateTime);
            sqlParameters[0].Value = Convert.ToString(appointment.startTime );
            sqlParameters[1] = new MySqlParameter("@end_date", MySqlDbType.DateTime);
            sqlParameters[1].Value = Convert.ToString(appointment.endTime);
            sqlParameters[2] = new MySqlParameter("@patient_id", MySqlDbType.Int32);
            sqlParameters[2].Value = Convert.ToString(appointment.Patient.PatientID);
            sqlParameters[3] = new MySqlParameter("@staff_id", MySqlDbType.Int32);
            sqlParameters[3].Value = Convert.ToString(appointment.Staff.StaffID);
            

            //execute query on appointment table
            dbConnection.InsertQuery(query, sqlParameters);

            return;
        }

        
    }
}
