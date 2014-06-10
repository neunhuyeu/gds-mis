using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doctor_Client.ServerConnectionMedicalInformation;

namespace Doctor_Client
{
    /// <summary>
    /// constructor for the login implementing together with the form class 
    /// </summary>
    public partial class Login : Form
    {

        private ServerConnectionMedicalInformation.DoctorClient proxy;
      
        public Login()
        {
            
                proxy = new ServerConnectionMedicalInformation.DoctorClient();
         
   
            InitializeComponent();
        }

     

 
        /// <summary>
        /// these is the done when the login button is pressed it should log the user in to the form, if the e-mail and password are equal of the audentification values in the database for the user
        /// </summary>
    
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginErrorlb.Text = "";
            if (tbEmail.Text.Length>7&& tbPassword.Text.Length>2)
            {
                string  Email = tbEmail.Text;
                string Password = tbPassword.Text;
                    ServerConnectionMedicalInformation.Staff currentUser;
                    if ((currentUser = proxy.Login(Email, Password)).FirstNamek__BackingField != null)
                    {
                        Client doctorform = new Client(currentUser);
                        this.Visible = false;
                        doctorform.ShowDialog();
                        this.Visible = true;
                    }
                    else
                    {
                        LoginErrorlb.Text = "Error: login were unsucessfull";
                    }

            }
            else
            {
                LoginErrorlb.Text = "Error: username and/or password is incorrect";
            }
            
              

          
            
        }
    }
}
