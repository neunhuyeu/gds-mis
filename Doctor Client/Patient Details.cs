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
      List<Int32> consultationsIDs;
      Staff CurrentUser;
      Consultation currentConsultation;
      bool newConsultation;
            public PatientDetails(Patient Pateint,Staff currentUser)
        {
            InitializeComponent();
          proxy= new DoctorClient();
          CurrentUser = currentUser;
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
            //Diagnosis
               foreach (Diagnosis item in    proxy.getDiagnosisHistoryByPersionID(patient.PatientIDk__BackingField))
            {
                
                DiagnosisHistory.Items.Add("Diagnosis" + item.diagnosis + "upon symptoms" + item.symptoms);
	        }
          

            //current Consultation
            currentConsultation.start_date = DateTime.Now;
            currentConsultation.patient_id = patient.PatientIDk__BackingField;
            currentConsultation.consultationID = proxy.getnextConsultationID();
            currentConsultation.staff_id = currentUser.StaffIDk__BackingField;
            newConsultation = false;
            consultationsIDs = new List<int>();
            foreach (Consultation item in proxy.getConsultationHistorybyPatient(currentConsultation.patient_id))
            {
                consultationsIDs.Add(item.consultationID);

                comboBox1.Items.Add(item.start_date.GetDateTimeFormats('D')[0]);

            }
                //percriptions
            perscription = proxy.getPatientPerscriptions(patient.PersonIdk__BackingField);
            foreach (ServerConnection.Perscription persrip in perscription )
            {
                PerscriptionLb.Items.Add("Date: " + persrip.date.ToShortDateString() + "\t" + "Drug: " + persrip.medicine + "\t" + "Dosage: " + persrip.strength); 
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
                MessageBox.Show(this, "Drug Name : " + perscription[PerscriptionLb.SelectedIndex].medicine.ToString() + "\nDate :  " + perscription[PerscriptionLb.SelectedIndex].date.ToString() +  "\nDosage" + perscription[PerscriptionLb.SelectedIndex].strength.ToString(), patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + " takes" + perscription[PerscriptionLb.SelectedIndex].medicine.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PerscriptionLb.SelectedIndex!=-1)
            {
                easyPrint PerscriptionPrint = new easyPrint();
                PerscriptionPrint.PrintString("\tMedical prescription \n" + "the following drug is issued to:/n" + patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + "\nname of medicine:" + perscription[PerscriptionLb.SelectedIndex].medicine.ToString() + "\nDosage" + perscription[PerscriptionLb.SelectedIndex].strength.ToString() + "\nDoctor: ___________________________________ " + perscription[PerscriptionLb.SelectedIndex].doctor.ToString());
            }
            else
            {
                MessageBox.Show("No Prescription selected to print", "Print Error", MessageBoxButtons.OK);

            }
            }

        private void btAddPrescription_Click(object sender, EventArgs e)
        {
            Perscription perscription = new Perscription();
            perscription.doctorId = CurrentUser.StaffIDk__BackingField;
            perscription.amount_ml = Convert.ToInt32(this.lbvolume.Text);
            perscription.amount_pills = Convert.ToInt32(this.lbnumPils.Text);
            perscription.medicine = this.lbMedicne.Text;
            perscription.strength = Convert.ToInt32(this.tbstrength.Text);
            int choosenConsultationID;
            if (comboBox1.Enabled)
            {
                choosenConsultationID = consultationsIDs[comboBox1.SelectedIndex];
            }
            else 
            {
                if (newConsultation)
                {
                    newConsultation = false;
                    
                    proxy.addConsultion( currentConsultation);
                   
                }
                choosenConsultationID = currentConsultation.consultationID;

            }
             proxy.addPerscription(choosenConsultationID, perscription );

        }

        private void pastConsultations_CheckedChanged(object sender, EventArgs e)
        {
            if (pastConsultations.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }
         ~PatientDetails()
        {
            if (!newConsultation)
            {
                currentConsultation.end_date = DateTime.Now;
                proxy.updateConsultion_End_Date( currentConsultation);
            
            }
        
        }
    }
}
