using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using DMS_Service.database_connection;

namespace DMS_Service.user_auth
{
    class user_auth_access
    {
        private db_connection db_con;
        /// <summary>
        /// empty constuctor of the user authentication class
        /// </summary>
        public user_auth_access()
        {
            db_con = new db_connection("gds_mis_auth");
        }
        /// <summary>
        /// funktion to login with the autenticated user these is an login process which acts ontop of the normal login but with connection to a more secure and smaller database 
        /// </summary>
        /// <param name="email">e-mail of the user act as username</param>
        /// <param name="passw"> secreat access key of to the account</param>
        /// <returns> gets the email and passord to enter in the normal login</returns>
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
