using System;
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
    public partial class PatientDetails : Form
    {
        Patient patient;
       List< Perscription> perscription;
        public PatientDetails(Patient Pateint)
        {
            InitializeComponent();
            //overview filler
            patient = Pateint;
            tbPatientDetailsOverviewName.Text = patient.FirstName + " " + patient.LastName;
            tbPatientDetailsOverviewAge.Text = DOBtoAge(Pateint.DateOfBirth).ToString();
            tbPatientDetailsOverviewDoB.Text = patient.DateOfBirth.ToString();
            tbPatientDetailsOverviewGender.Text = fixGender(patient.Gender);
            tbPatientDetailsOverviewIsuranceNumber.Text = patient.InsuranceNumber.ToString();
            tbPatientDetailsOverviewEMail.Text=patient.Email;
            tbPatientDetailsOverviewMPhone.Text = patient.MobileNumber.ToString();
            //percriptions
            foreach (Perscription persrip in perscription= new CDoctor().getPatientPerscriptions(patient.PatientID))
            {
                PerscriptionLb.Items.Add(persrip.Drug);
            }
        }
        private int DOBtoAge(string DOB)
        {
           DateTime formatedDOB=  Convert.ToDateTime(DOB);
            DateTime Now=DateTime.Now;
           int Age = Now.Year - formatedDOB.Year;
           if ((Now.Month * 100 + Now.Day) < (formatedDOB.Month * 100 + formatedDOB.Day))
           {
               Age--;
           }
           return Age;
        }
        private string fixGender(char genval)
        {
            switch (genval)
            {
                case 'm':
                case 'M':
                             return "Male";
                             break;
                case 'f':
                case 'F':
                             return "Female";
                             break;
                default: 
                            return "";
            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void PatientDetails_Load(object sender, EventArgs e)
        {

        }

        private void PerscriptionLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PerscriptionLb.SelectedIndex > -1)
            {
                MessageBox.Show(this, "Drug Name : " + perscription[PerscriptionLb.SelectedIndex].Drug.ToString() + "\nDate :  " + perscription[PerscriptionLb.SelectedIndex].Date.ToString() + "\nDoctor :  " + perscription[PerscriptionLb.SelectedIndex].Doctor.ToString() + "\nDosage" + perscription[PerscriptionLb.SelectedIndex].Dosage.ToString(), patient.FirstName + " " + patient.LastName + " takes" + perscription[PerscriptionLb.SelectedIndex].Drug.ToString());
            }
        }
    }
}
