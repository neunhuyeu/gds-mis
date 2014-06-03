
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

        public Appointment_database_acess()
        {
            dbConnection = new Appointment_database_connection(" gds_mis_agenda");
        }
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

        public DataTable SearchAppointmentsByPersionID(int personID)
        {

            string query = string.Format("SELECT * " +
                                        "FROM appointments " +
                                        "WHERE patient_id = (select patient_id from patient_info where patient_id = @personID) " +
                                        "ORDER BY start_date");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@personID", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(personID);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

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

        public DataTable SearchPatientByEmail(string email)
        {
            string query = string.Format("SELECT * FROM patient_info WHERE email_address = @email");
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@email", MySqlDbType.String);
            sqlParameters[0].Value = Convert.ToString(email);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable GetDoctors()
        {
            string query = string.Format("select last_name from staff_info");
            return dbConnection.SelectQuery(query);
        }

        public DataTable GetAppointmentsToday(string staffLastName, DateTime start_date)
        {
            string query = string.Format("select appointment_id  "
                                        + "from appointments  "
                                        + "Where staff_id = (select staff_id  "
                                                           + "from staff_info  "
                                                           + "where last_name = @staffLastName)  "
                                        + "AND start_date = @start_date");
            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@start_date", MySqlDbType.DateTime);
            string dateString = start_date.ToString("yyyy-MM-dd HH:mm:ss");
            sqlParameters[0].Value = dateString;
            sqlParameters[1] = new MySqlParameter("@StaffID", MySqlDbType.String);
            sqlParameters[1].Value = staffLastName;
            return dbConnection.SelectQuery(query, sqlParameters);
        }

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
