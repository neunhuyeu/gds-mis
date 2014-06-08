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

        //constructor
        public user_auth_access()
        {
            db_con = new Appointment_database_connection("gds_mis_auth");
        }


        /// <summary>
        /// Method for loggin in a user
        /// </summary>
        /// <param name="email">a specific email address</param>
        /// <param name="passw">a specific password</param>
        /// <returns>datatable containing the user with that email and password</returns>
        public DataTable user_login(string email, string passw)
        {
            string query = string.Format("SELECT user_name " +
                                         "From patient_user_auth " + 
                                         "WHERE email_address = @email " +
                                         "AND `password` = @passw");

            MySqlParameter[] query_parameters = new MySqlParameter[2];
            query_parameters[0] = new MySqlParameter("@passw", MySqlDbType.VarChar);
            query_parameters[0].Value = Convert.ToString(passw);
            query_parameters[1] = new MySqlParameter("@email", MySqlDbType.VarChar);
            query_parameters[1].Value = Convert.ToString(email);
            return db_con.SelectQuery(query, query_parameters);
        }
    }
}
