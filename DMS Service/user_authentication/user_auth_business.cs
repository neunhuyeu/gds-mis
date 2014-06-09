using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;
using DMS_Service;


namespace DMS_Service.user_auth
{
    class user_auth_business
    {
        private user_auth_access db_access;
        /// <summary>
        /// constructor for the bussiness layer of the user authentication
        /// </summary>
        public user_auth_business()
        {
            db_access = new user_auth_access();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email">user e-mail act as username </param>
        /// <param name="passw"> secreat password</param>
        /// <returns> true = can precide to the normal login false= inserted credentials are wrong</returns>
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
