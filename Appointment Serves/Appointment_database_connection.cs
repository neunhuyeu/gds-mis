using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Appointment_Serves
{
    class Appointment_database_connection
    {

   
        //full connection string
        private string db_connection_string = "";
        
        //constructor
        public Appointment_database_connection(string database_name)
        {
            set_connection_values(database_name);
        }

        //set the connections string values
        public string set_connection_values(string db_name, string server_ip = "localhost", string server_port = "3306", string user_id = "root", string user_passw = "")
        {
            //Database full connection string
            db_connection_string =   " SERVER=" + server_ip + ";" +
                                            " PORT=" + server_port + ";" +
                                            " DATABASE=" + db_name + ";" +
                                            " UID=" + user_id + ";" +
                                            " PASSWORD=" + user_passw + ";";
            return db_connection_string;
        }

        /// <summary>
        /// Method running a select query
        /// </summary>
        /// <param name="query">a specific query</param>
        /// <returns>datatable containing the result of the query</returns>
        public DataTable SelectQuery(String query)
        {
            DataSet dt_set = new DataSet();
            DataTable dt_table = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(db_connection_string))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                        using (MySqlDataAdapter dt_adapter = new MySqlDataAdapter())
                        {
                            dt_adapter.SelectCommand = cmd;
                            dt_adapter.Fill(dt_set);
                            dt_table = dt_set.Tables[0];
                        }

                    }
                }
            }
            catch (MySqlException e)
            {
                string[] lines = { "Error - SelectQuery - Query: ", query, "Exception: " + e.Message + e.StackTrace.ToString() };
                System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\errorlog.txt", lines);
                return null;
            }

            return dt_table;
        }

        /// <summary>
        /// Method running a select query with parameters
        /// </summary>
        /// <param name="query">a specific query</param>
        /// <param name="sqlParameter">array of MySqlParameters</param>
        /// <returns>datatable containing the result of the query</returns>
        public DataTable SelectQuery(String query, MySqlParameter[] sqlParameter)
        {
            DataSet dt_set = new DataSet();
            DataTable dt_table = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(db_connection_string))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = query;
                        cmd.Parameters.AddRange(sqlParameter);
                        cmd.ExecuteNonQuery();

                        using (MySqlDataAdapter dt_adapter = new MySqlDataAdapter())
                        {
                            dt_adapter.SelectCommand = cmd;
                            dt_adapter.Fill(dt_set);
                            dt_table = dt_set.Tables[0];
                        }

                    }
                }
            }
            catch (MySqlException e)
            {
                string[] lines = { "Error - SelectQuery - Query: ", query, "Exception: " + e.Message + e.StackTrace.ToString() };
                    System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\errorlog.txt",lines);
                return null;
            }
            
            return dt_table;
        }


        /// <summary>
        /// Method running an insert query with parameters
        /// </summary>
        /// <param name="query">a specific query</param>
        /// <param name="sqlParameter">array of MySqlParameters</param>
        /// <returns>true if the query was successfull or else false</returns>
        public bool InsertQuery(String query, MySqlParameter[] sqlParameter)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(db_connection_string))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = query;
                        cmd.Parameters.AddRange(sqlParameter);

                        using (MySqlDataAdapter dt_adapter = new MySqlDataAdapter())
                        {
                            dt_adapter.InsertCommand = cmd;
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                string[] lines = { "Error - SelectQuery - Query: ", query, "Exception: " + e.Message + e.StackTrace.ToString() };
                System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\errorlog.txt", lines);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Method running an update query with parameters
        /// </summary>
        /// <param name="query">a specific query</param>
        /// <param name="sqlParameter">array of MySqlParameters</param>
        /// <returns>true if the query was successfull or else false</returns>
        public bool UpdateQuery(String query, MySqlParameter[] sqlParameter)
        {
            DataSet dt_set = new DataSet();
            DataTable dt_table = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(db_connection_string))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = query;
                        cmd.Parameters.AddRange(sqlParameter);

                        using (MySqlDataAdapter dt_adapter = new MySqlDataAdapter())
                        {
                            dt_adapter.SelectCommand = cmd;
                            dt_adapter.Fill(dt_set);
                            dt_table = dt_set.Tables[0];
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                string[] lines = { "Error - SelectQuery - Query: ", query, "Exception: " + e.Message + e.StackTrace.ToString() };
                System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\errorlog.txt", lines);
                return false;
            }

            return true;
        }

    }
}

    

