using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DMS_Service
{
    // Kirolos
    public class BusinessLayer
    {
        private DbAccessLayer dbAcess;

        public BusinessLayer()
        {
            dbAcess = new DbAccessLayer();
        }
        // branch 1 change
        //Kirolos
        public Patient GetPatient_lastName_DateOfBirth(string lastName, DateTime dateOfBirth)
        {
            Patient patient = new Patient();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.SearchPatient_lastName_dateOfBirth(lastName, dateOfBirth);

            foreach (DataRow dr in dataTable.Rows)
            {
                patient.FirstName = dr["first_name"].ToString();
                patient.LastName = dr["last_name"].ToString();
                patient.DateOfBirth = dr["date_of_birth"].ToString();
                patient.Email = dr["email_address"].ToString();
                patient.Address = dr["home_address"].ToString();
            }
            return patient;
        }

        //Kirolos
        public Staff GetStaff_by_id(int id)
        {
            Staff staff = new Staff();
            DataTable dataTable = new DataTable();
            dataTable = dbAcess.GetStaff_byId(id);

            foreach (DataRow dr in dataTable.Rows)
            {
                staff.FirstName = dr["first_name"].ToString();
                staff.LastName = dr["last_name"].ToString();
                staff.DateOfBirth = dr["date_of_birth"].ToString();
                staff.Email = dr["email_address"].ToString();
                staff.Address = dr["home_address"].ToString();
            }
            return staff;
        }
    }
}
