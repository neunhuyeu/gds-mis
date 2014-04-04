using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doctor_Client.ServerConnection;


namespace Doctor_Client
{
    public partial class Login : Form
    {

        private ServerConnection.DoctorClient proxy;
      
        public Login()
        {
            
                proxy = new ServerConnection.DoctorClient();
         
   
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginErrorlb.Text = "";
            if (tbEmail.Text.Length>7&& tbPassword.Text.Length>2)
            {
                string  Email = tbEmail.Text;
                string Password = tbPassword.Text;
                    ServerConnection.Staff currentUser;
                if ((currentUser = proxy.Login(Email, Password)) != null)
                  {
                      Client doctorform = new Client(currentUser);
                      this.Visible = false;
                      doctorform.ShowDialog();
                      this.Visible = true;
                  }
                  else {
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
