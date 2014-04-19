using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DMS_Service.user_auth
{
    public class user_auth_db_connection
    {
        //Data base connection and addapter;
        MySqlDataAdapter data_adapter;
        MySqlConnection mysql_connection;
        
        //full connection string
        private string db_connection_string = "";
        
        //constructor
        public user_auth_db_connection()
        {
            if (!db_connection_string.Equals("")) set_connection_values();
            data_adapter = new MySqlDataAdapter();
            mysql_connection = new MySqlConnection(db_connection_string);
        }

        //set the connections string values
        public string set_connection_values(string server_ip = "localhost", string server_port = "3306", string db_name = "user_auth", string user_id = "root", string user_passw = "")
        {
            //Database full connection string
            db_connection_string =   "SERVER=" + server_ip + ";" +
                                            "PORT=" + server_port + ";" +
                                            "DATABASE=" + db_name + ";" +
                                            "UID=" + user_id + ";" +
                                            "PASSWORD=" + user_passw + ";";
            return db_connection_string;
        }

        MySqlConnection open_connection()
        {
            if (mysql_connection.State.Equals(System.Data.ConnectionState.Broken) || mysql_connection.State.Equals(System.Data.ConnectionState.Closed))
            {
                mysql_connection.Open();
                return mysql_connection;
            }
            return null;
        }

        public DataTable SelectQuery(String query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = open_connection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();
                data_adapter.SelectCommand = myCommand;
                data_adapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (MySqlException e)
            {
                Console.Write("Error - SelectQuery - Query: " +
                    query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {

            }
            return dataTable;
        }
    

            public bool InsertQuery(String query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                myCommand.Connection = open_connection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                data_adapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.Write("Error - InsertQuery - Query: " 
                    + query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            catch
            {

            }
            finally
            {
            }
            return true;
        }


        public bool UpdateQuery(String query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                myCommand.Connection = open_connection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                data_adapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.Write("Error - UpdateQuery - Query: " 
                    + query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }

    }
}
