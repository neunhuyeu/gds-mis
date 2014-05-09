using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using Appointment_Serves;

namespace DMS_Service.user_auth
{
    class user_auth_access
    {
        private Appointment_database_connection db_con;

        public user_auth_access()
        {
            db_con = new Appointment_database_connection("gds_mis_auth");
        }

        public DataTable user_login(string email, string passw)
        {
            string query = string.Format("SELECT email_address, password " +
                                         "From user_auth " + 
                                         "WHERE email_address = @email " +
                                         "AND password = @passw ");

            MySqlParameter[] query_parameters = new MySqlParameter[2];
            query_parameters[0] = new MySqlParameter("@passw", MySqlDbType.VarChar);
            query_parameters[0].Value = Convert.ToString(passw);
            query_parameters[1] = new MySqlParameter("@email", MySqlDbType.VarChar);
            query_parameters[1].Value = Convert.ToString(email);
            return db_con.SelectQuery(query, query_parameters);
        }
    }
}
