using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using DMS_Service.database_connection;

namespace DMS_Service.wiki
{
    
    class wiki_access
    {

        private db_connection db_con;
        /// <summary>
        /// constructor for wiki access
        /// </summary>
        public wiki_access()
        {
            db_con = new db_connection("gds_wiki");
        }
        /// <summary>
        /// gets all diseases from the database
        /// </summary>
        /// <returns>all diseases from the database</returns>
        public DataTable get_all_diseases()
        {
            string query = string.Format("SELECT * " +
                                         "From diseases ");
            return db_con.SelectQuery(query);
        }
        /// <summary>
        /// gets all medicine in the database
        /// </summary>
        /// <returns>a table of all medications in the database</returns>
        public DataTable get_all_medicines()
        {
            string query = string.Format("SELECT * " +
                                         "From medicine ");
            return db_con.SelectQuery(query);
        }

        /// <summary>
        /// lookes in the database for diseases with the following parameters 
        /// </summary>
        /// <param name="name">diseases name</param>
        /// <param name="symptoms">diseases syptoms </param>
        /// <param name="classification">diseases classification</param>
        /// <returns>a list of all possible diseases</returns>
        public DataTable search_disease(string name, string symptoms, string classification)
        {
            string parameters = "";
            string query = "Select * from diseases ";
            if (name.Length > 0 || symptoms.Length > 0 || classification.Length > 0)
            {
                query += " WHERE";
                if (name.Length > 0)
                {
                    query += " name like @name";
                    parameters += "n";
                }
                if (symptoms.Length > 0)
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " symptoms like @symptoms";
                    parameters += "s";
                }
                if (classification.Length > 0)
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " classification like @classification";
                    parameters += "c";
                }
            }
            MySqlParameter[] sqlParameters = null;
            if (parameters.Length > 0)
            {
                int index = 0;

                sqlParameters = new MySqlParameter[parameters.Length];
                parameters = parameters.PadRight(3, '#');

                if (parameters[index] == 'n')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@name", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + name + "%");
                }
                if (parameters[index] == 's')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@symptoms", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + symptoms + "%");
                }
                if (parameters[index] == 'c')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@classification", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + classification + "%");
                }
                query = string.Format(query);
            }
            return (sqlParameters == null) ? db_con.SelectQuery(query) : db_con.SelectQuery(query, sqlParameters);
        }
        /// <summary>
        /// searches for information about mediceine dependent on the parameters
        /// </summary>
        /// <param name="name"> complete or a part of the medicine name to look for related medicine</param>
        /// <param name="side_effects">complete or a part of the medicine side effects  to look for related medicine</param>
        /// <param name="classification">complete or a part of the medicine classification to look for related medicine</param>
        
        public DataTable search_medicine(string name, string side_effects, string classification)
        {
            string parameters = "";
            string query = "Select * from medicine ";
            if (name.Length > 0 || side_effects.Length > 0 || classification.Length > 0)
            {
                query += " WHERE";
                if (name.Length > 0)
                {
                    query += " name like ?name";
                    parameters += "n";
                }
                if (side_effects.Length > 0)
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " side_effects like @side_effects";
                    parameters += "s";
                }
                if (classification.Length > 0)
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " classification like @classification";
                    parameters += "c";
                }
            }
            MySqlParameter[] sqlParameters = null;
            if (parameters.Length > 0)
            {
                int index = 0;

                sqlParameters = new MySqlParameter[parameters.Length];
                parameters = parameters.PadRight(3, '#');

                if (parameters[index] == 'n')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("?name", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + name + "%");
                }
                if (parameters[index] == 's')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@side_effects", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + side_effects + "%");
                }
                if (parameters[index] == 'c')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@classification", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + classification + "%");
                }
                query = string.Format(query);
            }
            return (sqlParameters == null) ? db_con.SelectQuery(query) : db_con.SelectQuery(query, sqlParameters);
        }
    }
}
