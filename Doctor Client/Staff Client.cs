using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  DMS_Service;

namespace Doctor_Client
{
    public partial class Client : Form
    {
        Staff currentUser;
        List<Patient> potentualPatients;
        
        public Client(Staff user)
        {
            InitializeComponent();
            currentUser = user;
            userNamelb.Text = user.FirstName + " "+user.LastName;
            
        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (tbSearchName.Text.Length + tbInsuranceSearch.Text.Length + tbDOBSearch.Text.Length > 0)
            {
                CDoctor doc =new CDoctor();
                
                if (((potentualPatients=doc.search(tbSearchName.Text ,tbDOBSearch.Text,tbInsuranceSearch.Text))!=null) )
                {
                    foreach (Patient patient in potentualPatients)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}",patient.FirstName ,patient.LastName, patient.DateOfBirth,patient.InsuranceNumber));

                    }
                }
                
              
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void logoubtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void searchListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientDetails Patient = new PatientDetails(potentualPatients[searchListLB.SelectedIndex]);
        }

 
    }
}
