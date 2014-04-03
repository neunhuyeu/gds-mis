using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using  DMS_Service.MySynchroniseService;

namespace Doctor_Client
{
    public partial class Client : Form
    {
        MyDoctorService.Staff currentUser;
        MyDoctorService.Patient[] potentualPatients;

        public Client(MyDoctorService.Staff user)
        {
            InitializeComponent();
            currentUser = user;
            userNamelb.Text =  " Welcome Mr. "+user.firstName+user.lastName;
            
        
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (tbSearchName.Text.Length + tbInsuranceSearch.Text.Length + tbDOBSearch.Text.Length > 0)
            {
              MyDoctorService.DoctorClient  proxy = new MyDoctorService.DoctorClient();
                
                if (((potentualPatients=proxy.search(tbSearchName.Text ,tbDOBSearch.Text,tbInsuranceSearch.Text))!=null) )
                {
                    foreach (MyDoctorService.Patient patient in potentualPatients)
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
