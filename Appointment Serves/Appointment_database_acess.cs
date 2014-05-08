
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
        public DataTable SearchConsultationsbyDate(DateTime date, int staffId)
        {
            string query = string.Format("SELECT * " +
                                          "FROM patient_info " +
                                          "WHERE 	patient_id IN (SELECT 	patient_id FROM appointments WHERE patient_id IN (SELECT patient_id FROM consultations WHERE DATE(start_date)= @datetime AND staff_id = @StaffID))");

            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@datetime", MySqlDbType.Date);
            string caseTime = date.ToString("yyyy/MM/dd");
            sqlParameters[0].Value = caseTime;
            sqlParameters[1] = new MySqlParameter("@StaffID", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(staffId);

            return dbConnection.SelectQuery(query, sqlParameters);
        }
    }
}
