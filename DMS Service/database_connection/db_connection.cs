using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DMS_Service.database_connection
{
    public class db_connection
    {
        //full connection string
        private string db_connection_string = "";

       /// <summary>
       /// constructor of the database connect class
       /// </summary>
       /// <param name="database_name"> requires the name of the database</param>
        public db_connection(string database_name)
        {
            set_connection_values(database_name);
        }
       
        
        /// <summary>
        /// set the connections string values
        /// </summary>
        /// <param name="db_name">name of the Database</param>
        /// <param name="server_ip"> The IP adress of the server</param>
        /// <param name="server_port">the port of the server dedicated for database acess</param>
        /// <param name="user_id"> username of database to be acessed</param>
        /// <param name="user_passw"> password to log in to the database of the account relating with the username</param>
        /// <returns> the databse connection string</returns>
        public string set_connection_values(string db_name, string server_ip = "localhost", string server_port = "3306", string user_id = "root", string user_passw = "")
        {
            //Database full connection string
            db_connection_string = " SERVER=" + server_ip + ";" +
                                            " PORT=" + server_port + ";" +
                                            " DATABASE=" + db_name + ";" +
                                            " UID=" + user_id + ";" +
                                            " PASSWORD=" + user_passw + ";";
            return db_connection_string;
        }
        /// <summary>
        /// These functions convertes a sql string statement to the resulting information
        /// </summary>
        /// <param name="query">the sql statemnet which should be run by the database </param>
        /// <returns> a datatable containing the result of the select staement passed by the function</returns>
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
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
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
                System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\errorlog.txt", lines);
                return null;
            }

            return dt_table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
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
                            dt_adapter.UpdateCommand = cmd;
                            //dt_adapter.Fill(dt_set);
                            //dt_table = dt_set.Tables[0];
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
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParameter"></param>
        /// <returns></returns>
        public bool DeleteQuery(String query, MySqlParameter[] sqlParameter)
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
                            dt_adapter.DeleteCommand = cmd;
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException e)
            {
                string[] lines = { "Error - DeleteQuery - Query: ", query, "Exception: " + e.Message + e.StackTrace.ToString() };
                System.IO.File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\errorlog.txt", lines);
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlscript"></param>
        /// <returns></returns>
        public bool executeScript(string sqlscript)
        {

            try
            {
                using (MySqlConnection con = new MySqlConnection(db_connection_string))
                {
                    MySqlScript script = new MySqlScript(con, sqlscript);

                    con.Open();
                    script.Execute();
                    con.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
