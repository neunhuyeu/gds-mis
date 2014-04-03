using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;
using System.Security;
using MySql.Data.MySqlClient;

namespace DMS_Service
{   
    // Kirolos
    public class DbConnection
    {
        MySqlDataAdapter myAdapter;
        MySqlConnection conn;
        string provider = "SERVER=" + "92.109.173.161" + ";" + "Port=5055;" + "DATABASE=gds_mis;" + "UID=gds;" + "PASSWORD=gds-m1s-r00t!;";

        public DbConnection()
        {
            myAdapter = new MySqlDataAdapter();
            conn = new MySqlConnection(provider);
        }

        //Kirolos
        MySqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == 
						ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        //Kirolos
        public DataTable SelectQuery(String query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();           
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
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

        //Kirolos
        public bool InsertQuery(String query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
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

        //Kirolos
        public bool UpdateQuery(String query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
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
