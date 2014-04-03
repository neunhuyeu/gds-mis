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
    public partial class Client : Form
    {
        ServerConnection.Staff currentUser;
        ServerConnection.Patient[] potentualPatients;

        public Client(Staff user)
        {
            InitializeComponent();
            currentUser = user;
            userNamelb.Text =  " Welcome Mr. "+user.FirstNamek__BackingField + user.LastNamek__BackingField;
            
        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (tbSearchName.Text.Length + tbInsuranceSearch.Text.Length + tbDOBSearch.Text.Length > 0)
            {
              ServerConnection.DoctorClient  proxy = new ServerConnection.DoctorClient();
                
                if (((potentualPatients=proxy.search(tbSearchName.Text ,tbDOBSearch.Text,tbInsuranceSearch.Text))!=null) )
                {
                    foreach (Patient patient in potentualPatients)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}",patient.FirstNamek__BackingField ,patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField,patient.InsuranceNumberk__BackingField));

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
