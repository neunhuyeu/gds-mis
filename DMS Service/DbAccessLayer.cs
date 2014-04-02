using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DMS_Service
{
    // Kirolos
    public class DbAccessLayer
    {
        DbConnection dbConnection;
        SqlCredential cred;

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
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@lastName", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(lastName);
            sqlParameters[1] = new SqlParameter("@dateOfBirth", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(dateOfBirth);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable SearchPatientById(int id)
        {
            string query = string.Format("SELECT *" +
                                          "FROM person" +
                                          "JOIN patients" +
                                          "ON person.person_id = patient.person_id");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameters[0].Value = id.ToString();
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        //Kirolos
        public DataTable SearchStaffById(int id)
        {
            string query = "SELECT * FROM Staff_members WHERE person_id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToString(id);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// JP.
        /// Adds patient to the database by first adding record to person table and then patient table.
        /// </summary>
        /// <param name="patient">patient to be added</param>
        public void addPatient(Patient patient)
        {
            //query for person table
            string query = "INSERT INTO person(first_name, last_name, date_of_birth, email_address, mobile_number, landline_number, home_addres) VALUES ('@first_name', '@last_name', @date_of_birth, '@email_address', '@mobile_number', '@landline_number', '@home_address')";

            //parameters for person table
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@first_name", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(patient.FirstName);
            sqlParameters[1] = new SqlParameter("@last_name", SqlDbType.Char);
            sqlParameters[1].Value = Convert.ToString(patient.LastName);
            sqlParameters[2] = new SqlParameter("@date_of_birth", SqlDbType.Date);
            sqlParameters[2].Value = Convert.ToString(patient.DateOfBirth);
            sqlParameters[3] = new SqlParameter("@email_address", SqlDbType.Char);
            sqlParameters[3].Value = Convert.ToString(patient.Email);
            sqlParameters[4] = new SqlParameter("@mobile_number", SqlDbType.Char);
            sqlParameters[4].Value = Convert.ToString(patient.MobileNumber);
            sqlParameters[5] = new SqlParameter("@landline_number", SqlDbType.Char);
            sqlParameters[5].Value = Convert.ToString(patient.LandLineNumber);
            sqlParameters[6] = new SqlParameter("@home_address", SqlDbType.Char);
            sqlParameters[6].Value = Convert.ToString(patient.Address);

            //execute query on person table
            dbConnection.InsertQuery(query, sqlParameters);

            //query for patient table
            query = "INSERT INTO patients (gender, height_cm, weight_kg, blood_type, smoking, smoking_frequency, hard_drugs, hard_drugs_frequency, person_id) VALUES ('@gender', @height_cm, @weight_kg, '@blood_type', @smoking Bool, @smoking_frequency, @hard_drugs, @hard_drugs_frequency, (SELECT MAX(person_ID) FROM person))";


            //parameters for patient table
            sqlParameters = null;
            sqlParameters = new SqlParameter[9];
            sqlParameters[0] = new SqlParameter("@gender", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(patient.Gender);
            sqlParameters[1] = new SqlParameter("@height_cm", SqlDbType.Int);
            sqlParameters[1].Value = Convert.ToString(patient.Height);
            sqlParameters[2] = new SqlParameter("@weight_kg", SqlDbType.Int);
            sqlParameters[2].Value = Convert.ToString(patient.Weight);
            sqlParameters[3] = new SqlParameter("@blood_type", SqlDbType.Char);
            sqlParameters[3].Value = Convert.ToString(patient.BloodType);
            sqlParameters[4] = new SqlParameter("@smoking", SqlDbType.Bit);
            sqlParameters[4].Value = Convert.ToString(patient.Smoker);
            sqlParameters[5] = new SqlParameter("@smoking_frequency", SqlDbType.Int);
            sqlParameters[5].Value = Convert.ToString(patient.SmokingFrequency);

            //TODO: Add correct paameters
            sqlParameters[6] = new SqlParameter("@hard_drugs", SqlDbType.Bit);
            sqlParameters[6].Value = false;
            sqlParameters[7] = new SqlParameter("@smoking_frequency", SqlDbType.Int);
            sqlParameters[7].Value = 0;

            //execute query on patient table
            dbConnection.InsertQuery(query, sqlParameters);

            return;
        }

        
    }
}
