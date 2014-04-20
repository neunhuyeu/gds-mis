using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DMS_Service.user_auth
{
    class user_auth_access
    {
        private user_auth_db_connection db_connection;

        public user_auth_access()
        {
            db_connection = new user_auth_db_connection();
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
            return db_connection.SelectQuery(query,query_parameters);
        }

        //public DataTable get_users(string name, string passw)
        //{
            
        //}
    }
}
