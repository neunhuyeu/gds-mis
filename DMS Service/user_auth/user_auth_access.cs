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

        public DataTable user_login(string e_mail, string passw)
        {
            string query = string.Format("SELECT email, password" + " " +
                                         "From user_auth" + " " +
                                         "WHERE password = '@passw'" + " " +
                                         "AND email = '@e_mail'"
                                        );

            MySqlParameter[] query_parameters = new MySqlParameter[2];
            query_parameters[0] = new MySqlParameter("@passw", MySqlDbType.VarChar);
            query_parameters[0].Value = Convert.ToString(passw);
            query_parameters[1] = new MySqlParameter("@e_mail", MySqlDbType.VarChar);
            query_parameters[1].Value = Convert.ToString(e_mail);
            return db_connection.SelectQuery(query,query_parameters);
        }

        //public DataTable get_users(string name, string passw)
        //{
            
        //}
    }
}
