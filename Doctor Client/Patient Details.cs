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
            RefrashDiagnosis();
          

            //current Consultation
            currentConsultation.start_date = DateTime.Now;
            currentConsultation.patient_id = patient.PatientIDk__BackingField;
            currentConsultation.consultationID = proxy.getnextConsultationID();
            currentConsultation.staff_id = currentUser.StaffIDk__BackingField;
            newConsultation = true;

            RefreashConsultations();
                //percriptions
            RefreashPrescription();
        }

            private void RefrashDiagnosis()
            {
                DiagnosisHistory.Items.Clear();
                foreach (Diagnosis diagnose in proxy.getDiagnosisHistoryByPersionID(patient.PatientIDk__BackingField))
                {

                    DiagnosisHistory.Items.Add(diagnose.date.GetDateTimeFormats('d')[0]+"- Doctor "+diagnose.doctorName+" diagnosed " + diagnose.diagnosis + " upon symptoms" + diagnose.symptoms);
                }
            }

            private void RefreashPrescription()
            {
                PerscriptionLb.Items.Clear();
                perscription = proxy.getPatientPerscriptions(patient.PersonIdk__BackingField);
                foreach (ServerConnection.Perscription persrip in perscription)
                {
                    PerscriptionLb.Items.Add("Date: " + persrip.date.ToShortDateString() + "\t" + "Drug: " + persrip.medicine + "\t" + "Dosage: " + persrip.strength);
                }
            }

            private void RefreashConsultations()
            {
                cBconsultationID.Items.Clear();
            
                consultationsIDs = new List<int>();
                foreach (Consultation item in proxy.getConsultationHistorybyPatient(patient.PersonIdk__BackingField))
                {
                    consultationsIDs.Add(item.consultationID);

                    cBconsultationID.Items.Add(item.start_date.GetDateTimeFormats('d')[0]);
              
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
            try
            {
                Perscription aperscription = new Perscription();
                aperscription.doctorId = CurrentUser.StaffIDk__BackingField;
                aperscription.amount_ml = Convert.ToInt32(this.tbVolume.Text);
                aperscription.amount_pills = Convert.ToInt32(this.tbNumPills.Text);
                aperscription.medicine = this.tbMedicine.Text;
                aperscription.strength = Convert.ToInt32(this.tbstrength.Text);
            
            int choosenConsultationID;
            if (cBconsultationID.Enabled)
            {
                choosenConsultationID = consultationsIDs[cBconsultationID.SelectedIndex];
            }
            else 
            {
                consultationEvent();
                choosenConsultationID = currentConsultation.consultationID;

            }
            proxy.addPerscription(choosenConsultationID, aperscription);
            }
            catch (FormatException) 
            {
                MessageBox.Show(this, "Same fields in the imput area are empty or contain wrong information", "Invaled Input add prescription",MessageBoxButtons.OK);
            }
             RefreashPrescription();
        }

        private void consultationEvent()
        {
             
            if (newConsultation)
            {
             newConsultation = false;

                proxy.addConsultion(currentConsultation);

            }
        }

        private void pastConsultations_CheckedChanged(object sender, EventArgs e)
        {

        }
         ~PatientDetails()
        {
            if (!newConsultation)
            {
                currentConsultation.end_date = DateTime.Now;
                proxy.updateConsultion_End_Date( currentConsultation);
            
            }

        }

         private void pastConsultations_CheckedChanged_1(object sender, EventArgs e)
         {
             if (pastConsultations.Checked)
             {
                 cBconsultationID.Enabled = true;
             }
             else
             {
                 cBconsultationID.Enabled = false;
             }
         }
    }
}
