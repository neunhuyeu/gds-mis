
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Globalization;


namespace Appointment_Serves
{

    class Appointment_database_acess
    {
        private Appointment_database_connection dbConnection;

        //constructor
        public Appointment_database_acess()
        {
            dbConnection = new Appointment_database_connection(" gds_mis_agenda");
        }

        /// <summary>
        /// Method for searching appointments by a given date and staffId
        /// </summary>
        /// <param name="date">a specific date</param>
        /// <param name="staffId">a specific staff Id</param>
        /// <returns>a datatable containing all appointments on a specific date and for a specific staff id</returns>
        public DataTable SearchAppointmentsbyDate(DateTime date, int staffId)
        {
            string query = string.Format("SELECT * " +
                                          "FROM patient_info " +
                                          "WHERE 	patient_id IN (SELECT patient_id FROM appointments WHERE DATE(start_date)= @datetime AND staff_id = @StaffID)");

            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@datetime", MySqlDbType.Date);
            string caseTime = date.ToString("yyyy/MM/dd");
            sqlParameters[0].Value = caseTime;
            sqlParameters[1] = new MySqlParameter("@StaffID", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(staffId);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// Method for searching appointments of a certain patient
        /// </summary>
        /// <param name="personID">a specific patient ID</param>
        /// <returns>a datatable containing all appointments of a certain patient</returns>
         public DataTable SearchAppointmentsByPersonID(int personID)
         {
             
             string query = string.Format("SELECT a.appointment_id, a.start_date, a.end_date, s.first_name, s.last_name, s.room_number " +
                                         "FROM appointments a, staff_info s " +
                                         "WHERE a.patient_id =@patientID AND a.staff_id = s.staff_id " +
                                         "ORDER BY a.start_date");

             MySqlParameter[] sqlParameters = new MySqlParameter[1];
             sqlParameters[0] = new MySqlParameter("@patientID", MySqlDbType.Int32);
             sqlParameters[0].Value = Convert.ToString(personID);

             return dbConnection.SelectQuery(query, sqlParameters);
         }

         /// <summary>
         /// Method for searching appointments by a given patient username
         /// </summary>
         /// <param name="username">a certain username</param>
         /// <returns>a datatable containing all appointments of a patient with that username</returns>
        public DataTable SearchAppointmentsByPatientUsername(string username)
        {

            string query = string.Format("select a.appointment_id, a.start_date, a.end_date, s.last_name " +
                                           "from appointments as a join staff_info as s " +
                                           "on a.staff_id = s.staff_id " +
                                           "join patient_info as p on a.patient_id = p.patient_id " +
                                           "Where p.email_address = @username " +
                                           "order by a.start_date desc");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@username", MySqlDbType.String);
            sqlParameters[0].Value = Convert.ToString(username);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// Method for searching appointments by staffId
        /// </summary>
        /// <param name="staffId">a specific staff id</param>
        /// <returns>a datatable containing all appointments for a specific staff id</returns>
        public DataTable SearchAppointmentsByStaffID(int staffId)
        {

            string query = string.Format("SELECT * " +
                                        "FROM appointments  " +
                                        "WHERE  Staff_id = @StaffID  " +
                                       " ORDER BY start_date");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@StaffID", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(staffId);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// Method for searching appointments of today by staffId
        /// </summary>
        /// <param name="staffID">a specific staff Id</param>
        /// <returns>a datatable containing all appointments of today for a specific staff id</returns>
        public DataTable SearchAppointmentsOfToday(int staffID)
        {
            string query = string.Format("SELECT * " +
                                          "FROM patient_info " +
                                          "Where patient_id IN (SELECT patient_id FROM appointments WHERE DATE(start_date) = @today AND Staff_id = @StaffID)");

            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@today", MySqlDbType.Date);
            string caseTime = DateTime.Now.ToString("yyyy/MM/dd");
            sqlParameters[0].Value = caseTime;
            sqlParameters[1] = new MySqlParameter("@StaffID", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(staffID);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// Method for searching a patient by a given email
        /// </summary>
        /// <param name="email">a specific email address</param>
        /// <returns>a datatable containing the patient with that specific email address</returns>
        public DataTable SearchPatientByEmail(string email)
        {
            string query = string.Format("SELECT * FROM patient_info WHERE email_address = @email");
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@email", MySqlDbType.String);
            sqlParameters[0].Value = Convert.ToString(email);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// Method for getting doctors
        /// </summary>
        /// <returns>a datatable containing all doctors' last names</returns>
        public DataTable GetDoctors()
        {
            string query = string.Format("select last_name from staff_info");
            return dbConnection.SelectQuery(query);
        }

        /// <summary>
        /// Method for getting all the appointments start dates
        /// </summary>
        /// <returns>a datatable containing all appointments start dates</returns>
        public DataTable GetAppointmentStartDates()
        {
            string query = string.Format("select start_date from appointments");
            return dbConnection.SelectQuery(query);
        }

        /// <summary>
        /// Method for adding an appointment to the database
        /// </summary>
        /// <param name="staffId">a specific staff Id</param>
        /// <param name="patientId">a specific patient Id</param>
        /// <param name="startDate">a specific start date</param>
        /// <param name="endDate">a specific end date</param>
        /// <returns>true if the appointment has successfully been added. or else returns false</returns>
        public bool addAppointmrnt(int staffId, int patientId, string startDate, string endDate)
        {
            string query = string.Format("INSERT INTO appointments (appointment_id, staff_id, patient_id, start_date, end_date) "
                                + "VALUES (@appId, @staffId, @patientId, @startDate, @endDate)");
            MySqlParameter[] sqlParameters = new MySqlParameter[5];

            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            DateTime date;

            int appId = newAppointmentId();

            sqlParameters[0] = new MySqlParameter("@appId", MySqlDbType.Int32);
            sqlParameters[0].Value = appId;
            sqlParameters[1] = new MySqlParameter("@staffId", MySqlDbType.Int32);
            sqlParameters[1].Value = staffId;
            sqlParameters[2] = new MySqlParameter("@patientId", MySqlDbType.Int32);
            sqlParameters[2].Value = patientId;
            sqlParameters[3] = new MySqlParameter("@startDate", MySqlDbType.DateTime);
            date = DateTime.Parse(startDate, culture);
            sqlParameters[3].Value = date;
            sqlParameters[4] = new MySqlParameter("@endDate", MySqlDbType.DateTime);
            date = DateTime.Parse(endDate, culture);
            sqlParameters[4].Value = date;
            
            return dbConnection.InsertQuery(query, sqlParameters);
        }


        /// <summary>
        /// Method for returning the next new appointment id
        /// </summary>
        /// <returns>returns the new next appointment id</returns>
        private int newAppointmentId()
        {
            string query = "SELECT MAX(appointment_id)+1 as new FROM appointments";
            int result;
            try
            {
                // Execute query on person table.
                result = Convert.ToInt32(dbConnection.SelectQuery(query).Rows[0]["new"]);
            }
            catch { return -1; }
            return result;
        }

        /// <summary>
        /// Method for getting the patient id by a certain email address
        /// </summary>
        /// <param name="patientMail">a specific email address</param>
        /// <returns>the patient id of the patient who has that email</returns>
        internal int GetPatientId(string patientMail)
        {
            int patientId = -1;
            string query = string.Format("SELECT patient_id " +
                                        "FROM patient_info " +
                                        "WHERE email_address = @patientMail");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@patientMail", MySqlDbType.String);
            sqlParameters[0].Value = Convert.ToString(patientMail);

            DataTable dt = dbConnection.SelectQuery(query, sqlParameters);
            if (dt.Rows.Count > 0)
            {
                patientId = Convert.ToInt32(dt.Rows[0][0]);
            }
            return patientId;
        }

        /// <summary>
        /// Method for getting the staff id by a certain last name
        /// </summary>
        /// <param name="staffLastName">a specific staff last name</param>
        /// <returns>returns the staff id of the staff who has that last name</returns>
        internal int GetStaffId(string staffLastName)
        {
            int staffId = -1;
            string query = string.Format("SELECT staff_id " +
                                        "FROM staff_info " +
                                        "WHERE last_name = @staffLastName");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@staffLastName", MySqlDbType.String);
            sqlParameters[0].Value = Convert.ToString(staffLastName);

            DataTable dt = dbConnection.SelectQuery(query, sqlParameters);
            if (dt.Rows.Count > 0)
            {
                staffId = Convert.ToInt32(dt.Rows[0][0]);
            }
            return staffId;
        }
    }
}
