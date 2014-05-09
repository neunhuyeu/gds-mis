using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows;
using DMS_Service;


namespace DMS_Service.user_auth
{
    class user_auth_business
    {
        private user_auth_access db_access;

        public user_auth_business()
        {
            db_access = new user_auth_access();
        }

        public bool login(string email, string passw)
        {
            DataTable temp_datatable = new DataTable();
            temp_datatable = db_access.user_login(email, passw);
            string temp_mail = "";
            string temp_passw = "";
            if (temp_datatable != null)
            {
                foreach (DataRow row in temp_datatable.Rows)
                {
                    temp_mail = row["email_address"].ToString();
                    temp_passw = row["password"].ToString();    
                }
                if ((temp_mail == email) && (temp_passw == passw))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
