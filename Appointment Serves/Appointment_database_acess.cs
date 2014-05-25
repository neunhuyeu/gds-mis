﻿
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    using MySql.Data.MySqlClient;
    

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
    }
}
