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
            userNamelb.Text =  " Welcome: "+user.FirstNamek__BackingField + " "+user.LastNamek__BackingField;
            DOBSearch.Value = DateTime.Now.Date;
            
        
        }

        private void searchPatients()
        {
            searchListLB.Items.Clear();
            if (tbSearchFirstName.Text.Length + tbInsuranceSearch.Text.Length + DOBSearch.Text.Length + tbSearchLastName.Text.Length > 0)
            {
                ServerConnection.DoctorClient proxy = new ServerConnection.DoctorClient();
               
                if (((potentualPatients = proxy.SearchPatients(tbSearchFirstName.Text, tbSearchLastName.Text, DOBSearch.Value,insurancenumberFormater())) != null))
                {
                    foreach (Patient patient in potentualPatients)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", patient.FirstNamek__BackingField, patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1], patient.InsuranceNumberk__BackingField));

                    }
                }


            }
        }

        private int insurancenumberFormater()
        {
            int insurancenr;
            if (tbInsuranceSearch.Text == "")
            {
                insurancenr = 0;
            }
            else
            {
                insurancenr = Convert.ToInt32(tbInsuranceSearch.Text);
            }
            return insurancenr;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            searchPatients();
        }

        private void logoubtn_Click(object sender, EventArgs e)
        {
          this.Close();

        }

        private void searchListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientDetails Patient = new PatientDetails(potentualPatients[searchListLB.SelectedIndex]);

            Patient.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_searchPatients_Click(object sender, EventArgs e)
        {
            searchPatients();
        }

        private void tbSearchFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            searchPatients();
        }

 
    }
}
