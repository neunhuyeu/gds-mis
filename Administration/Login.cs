﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Using the service namespaces to avoid typing long identifiers.
using Administration.MedicalInformation;

namespace Administration
{
    public partial class Login : Form
    {
        private DoctorClient proxy;

        public Login()
        {
            proxy = new DoctorClient();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginErrorlb.Text = "";
            if (tbEmail.Text.Length > 7 && tbPassword.Text.Length > 2)
            {
                string Email = tbEmail.Text;
                string Password = tbPassword.Text;
                Staff currentUser;
                if ((currentUser = proxy.Login(Email, Password)).FirstNamek__BackingField != null)
                {
                    MainForm administration = new MainForm(currentUser);
                    this.Visible = false;
                    administration.ShowDialog();
                    this.Visible = true;
                }
                else
                {
                    LoginErrorlb.Text = "Error: login was unsucessfull";
                }

            }
            else
            {
                LoginErrorlb.Text = "Error: username and/or password is incorrect";
            }
        }
    }
}
