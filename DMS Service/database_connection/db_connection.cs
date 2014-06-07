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

        //constructor
        public db_connection(string database_name)
        {
            set_connection_values(database_name);
        }

        //set the connections string values
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
