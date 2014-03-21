using System;
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
            dbConnection = new DbConnection(cred);
        }
        
        //Kirolos
        public DataTable SearchPatient_lastName_dateOfBirth(string lastName, DateTime dateOfBirth)
        {
            string query = string.Format("SELECT * FROM person" + 
                      "WHERE last_name = @lastName AND date_of_birth = @dateOfBirth");
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@lastName", SqlDbType.Char);
            sqlParameters[0].Value = Convert.ToString(lastName);
            sqlParameters[1] = new SqlParameter("@dateOfBirth", SqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(dateOfBirth);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable getPatient()
        {
            throw new System.NotImplementedException();
        }

        public void addPatient()
        {
            throw new System.NotImplementedException();
        }

        //Kirolos
        public DataTable GetStaff_byId(int id)
        {
            string query = "SELECT * FROM Staff_members WHERE Staff_id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToString(id);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        public DataTable getStaff()
        {
            throw new System.NotImplementedException();
        }
    }
}
