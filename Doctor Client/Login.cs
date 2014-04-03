﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DMS_Service;


namespace Doctor_Client
{
    public partial class Login : Form
    {

        private MyDoctorService.DoctorClient proxy;
        //private CDoctor Doc;
        public Login()
        {
            proxy = new MyDoctorService.DoctorClient();
            //Doc = new CDoctor();
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
            if (tbEmail.Text.Length>7&& tbPassword.Text.Length>2)
            {
                string  Email = tbEmail.Text;
                string Password = tbPassword.Text;
                 Staff currentUser;
                if((currentUser=Doc.login(Email,Password))!=null)
                {
                    this.Visible=false;
                    Client doctorform= new Client(currentUser); 
                    this.Visible=true;
                }
            }
            
              

          
            
        }
    }
}
