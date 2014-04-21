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
    public partial class PatientDetails : Form
    {
      Patient patient;
      DoctorClient proxy;
      Perscription[] perscription;
       public PatientDetails(Patient Pateint)
        {
            InitializeComponent();
          proxy= new DoctorClient();
            //overview filler
            patient = Pateint;
            tbPatientDetailsOverviewName.Text = patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField;
            tbPatientDetailsOverviewAge.Text = DOBtoAge(Pateint.DateOfBirthk__BackingField).ToString();
            tbPatientDetailsOverviewDoB.Text = patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[0];
            tbPatientDetailsOverviewGender.Text = fixGender(patient.Genderk__BackingField);
            tbPatientDetailsOverviewIsuranceNumber.Text = patient.InsuranceNumberk__BackingField.ToString();
            tbPatientDetailsOverviewEMail.Text = patient.Emailk__BackingField;
            tbPatientDetailsOverviewMPhone.Text = patient.MobileNumberk__BackingField.ToString();
            tbPatientDetailsOverviewPhone.Text = patient.LandLineNumberk__BackingField.ToString();
            //percriptions
            perscription = proxy.getPatientPerscriptions(patient.PersonIdk__BackingField);
            foreach (ServerConnection.Perscription persrip in perscription )
            {
                PerscriptionLb.Items.Add(persrip.drug);
            }
        }
        private int DOBtoAge(DateTime DOB)
        {
            DateTime Now=DateTime.Now;
           int Age = Now.Year - DOB.Year;
           if ((Now.Month * 100 + Now.Day) < (DOB.Month * 100 + DOB.Day))
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
                MessageBox.Show(this, "Drug Name : " + perscription[PerscriptionLb.SelectedIndex].drug.ToString() + "\nDate :  " + perscription[PerscriptionLb.SelectedIndex].date.ToString() + "\nDoctor :  " + perscription[PerscriptionLb.SelectedIndex].doctor.ToString() + "\nDosage" + perscription[PerscriptionLb.SelectedIndex].dosage.ToString(), patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + " takes" + perscription[PerscriptionLb.SelectedIndex].drug.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            easyPrint PerscriptionPrint = new easyPrint();
            PerscriptionPrint.PrintString("\tMedical prescription \n" + "the following drug is issued to:/n" + patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + "\nname of medicine:" + perscription[PerscriptionLb.SelectedIndex].drug.ToString() + "\nDosage" + perscription[PerscriptionLb.SelectedIndex].dosage.ToString() + "\nDoctor: ___________________________________ " + perscription[PerscriptionLb.SelectedIndex].doctor.ToString());
        }
    }
}
