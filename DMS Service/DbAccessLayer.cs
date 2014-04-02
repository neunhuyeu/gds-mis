﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DMS_Service
{
    // Kirolos
    public class DbAccessLayer
    {
        DbConnection dbConnection;
        SqlCredential cred;

        public DbAccessLayer()
        {
            dbConnection = new DbConnection();
        }
        
        //Kirolos
        public DataTable SearchPatient_lastName_dateOfBirth(string lastName, DateTime dateOfBirth)
        {
            string query = string.Format("SELECT *" +
                                        "FROM person" + 
                                        "WHERE last_name = @lastName" +
                                        "AND date_of_birth = @dateOfBirth");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@lastName", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(lastName);
            sqlParameters[1] = new SqlParameter("@dateOfBirth", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(dateOfBirth);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable SearchPatientById(int id)
        {
            string query = string.Format("SELECT *" +
                                          "FROM person" +
                                          "JOIN patients" +
                                          "ON person.person_id = patient.person_id");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameters[0].Value = id.ToString();
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        //Kirolos
        public DataTable SearchStaffById(int id)
        {
            string query = "SELECT * FROM Staff_members WHERE person_id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToString(id);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        
    }
}
