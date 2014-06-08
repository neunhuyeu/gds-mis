using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doctor_Client.ServerConnectionMedicalInformation;
using System.Threading;

namespace Doctor_Client
{
    public partial class PatientDetails : Form
    {
        //contains the patient
        Patient patient;

        //contains the doctor client
        DoctorClient proxy;

        //contains an array of prescriptions
        Perscription[] perscription;

        //contains a list of consultation id's
        List<Int32> consultationsIDs;

        //contains the current staff user
        Staff CurrentUser;
        int lastTabIndex;

        //contains a list of appointments history
        List<string> appointmentHistory;

        //contains current consultation
        Consultation currentConsultation;
        bool newConsultation;

        /// <summary>
        /// constructor, shows the details of a patient. sets the consultations,prescriptions and diagnosis
        /// </summary>
        /// <param name="pateint">a specific patient</param>
        /// <param name="currentUser">the staff user</param>
        public PatientDetails(Patient Pateint, Staff currentUser)
        {
            InitializeComponent();
            lastTabIndex = 0;
            proxy = new DoctorClient();
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
            getAppointmentsHistoryofPatient(patient.PatientIDk__BackingField);
            FillAppointmentstab();

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

        //method refreshes the diagnosis list, and shows the diagnosis history of the patient
        private void RefrashDiagnosis()
        {
            DiagnosisHistory.Items.Clear();
            foreach (Diagnosis diagnose in proxy.getDiagnosisHistoryByPersionID(patient.PatientIDk__BackingField))
            {

                DiagnosisHistory.Items.Add(diagnose.date.GetDateTimeFormats('d')[0] + "- Doctor " + diagnose.doctorName + " diagnosed " + diagnose.diagnosis + " upon symptoms" + diagnose.symptoms);
            }
        }


        //method refreshes the prescription list, and shows the patient's prescription
        private void RefreashPrescription()
        {
            PrescriptionLb.Items.Clear();
            perscription = proxy.getPatientPerscriptions(patient.PersonIdk__BackingField);
            foreach (ServerConnectionMedicalInformation.Perscription persrip in perscription)
            {
                PrescriptionLb.Items.Add("Date: " + persrip.date.ToShortDateString() + "\t" + "Drug: " + persrip.medicine + "\t" + "Dosage: " + persrip.strength + " Perscriber: " + persrip.doctor);
            }
        }


        //method refreshes consultations list, and shows the consultations history of the patient
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

        //method converts the date of birth of the patient to int age.
        //returns int age of the patient
        private int DOBtoAge(DateTime DOB)
        {
            DateTime Now = DateTime.Now;
            int Age = Now.Year - DOB.Year;
            if ((Now.Month * 100 + Now.Day) < (DOB.Month * 100 + DOB.Day))
            {
                Age--;
            }
            return Age;
        }

        //method correctly fixes gender of patient. m to male, f to female
        //returns string gender
        private string fixGender(char genval)
        {
            string result;
            switch (genval)
            {
                case 'm':
                case 'M':
                    result = "Male";
                    break;
                case 'f':
                case 'F':
                    result = "Female";
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }


        //method gets the current consultation id, and returns this
        private int currentconsultationID
        {
            get
            {
                if (newConsultation)
                {
                    newConsultation = false;
                    proxy.addConsultion(currentConsultation);
                }
                return currentConsultation.consultationID;
            }
        }


        //method shows messagebox with prescription detail when a prescription is selected in the listbox
        private void PerscriptionLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PrescriptionLb.SelectedIndex > -1)
            {
                MessageBox.Show(this, "Drug Name : " + perscription[PrescriptionLb.SelectedIndex].medicine.ToString() + "\nDate :  " + perscription[PrescriptionLb.SelectedIndex].date.ToString() + "\nDosage" + perscription[PrescriptionLb.SelectedIndex].strength.ToString(), patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + " takes" + perscription[PrescriptionLb.SelectedIndex].medicine.ToString());
            }
        }


        //method for print button to print the prescription
        private void button2_Click(object sender, EventArgs e)
        {
            if (PrescriptionLb.SelectedIndex != -1)
            {
                easyPrint PerscriptionPrint = new easyPrint();
                PerscriptionPrint.PrintString("\tMedical prescription \n" + "the following drug is issued to:/n" + patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + "\nname of medicine:" + perscription[PrescriptionLb.SelectedIndex].medicine.ToString() + "\nDosage" + perscription[PrescriptionLb.SelectedIndex].strength.ToString() + "\nDoctor: ___________________________________ " + perscription[PrescriptionLb.SelectedIndex].doctor.ToString());
            }
            else
            {
                MessageBox.Show("No Prescription selected to print", "Print Error", MessageBoxButtons.OK);

            }
        }


        //method for adding a prescription. gets data from the filled in inputs
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

                    choosenConsultationID = currentconsultationID;

                }
                proxy.addPerscription(choosenConsultationID, aperscription);
            }
            catch (FormatException)
            {
                MessageBox.Show(this, "Same fields in the imput area are empty or contain wrong information", "Invaled Input add prescription", MessageBoxButtons.OK);
            }
            RefreashPrescription();
        }




        ~PatientDetails()
        {
            if (!newConsultation)
            {
                currentConsultation.end_date = DateTime.Now;
                proxy.updateConsultion_End_Date(currentConsultation);

            }

        }

        //method for when you click past consultations it enables choosing consultation id, else it disables it
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

        //method for button to clear the diagnose editor
        private void button3_Click(object sender, EventArgs e)
        {

            clearDiagnoseEditor();
        }

        //method clears the diagnose editor
        private void clearDiagnoseEditor()
        {
            tbinputSyntoms.Text = "";
            tbInputDiagnosis.Text = "";
        }

        //method saves a new diagnosis of the patient and adds it to the database
        private void btSave_Click(object sender, EventArgs e)
        {
            Diagnosis diagnosis = new Diagnosis();
            diagnosis.consultation_id = currentconsultationID;
            diagnosis.diagnosis = tbInputDiagnosis.Text.Replace("/n", " ");
            diagnosis.symptoms = tbinputSyntoms.Text.Replace("/n", ",");
            proxy.addDiagnosis(diagnosis);
        }

        //opens the wiki form when clicked on the wiki tab
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedIndex == 4)
            {
                tabs.SelectedIndex = lastTabIndex;
                Thread t1 = new Thread(NewWiki);
                t1.Name = "wiki Thread";
                t1.IsBackground = true;
                t1.Start();
            }
            else
            {
                lastTabIndex = tabs.SelectedIndex;
            }
        }

        //method makes a new wiki
        public void NewWiki()
        {
            Wiki wiki = new Wiki();
            wiki.isclosed = false;
            wiki.Show();
            while (!wiki.isclosed)
            {
                
            }
        }

        private void PatientDetails_Load(object sender, EventArgs e)
        {

        }

        //method gets the appointment history of the patient by his/her patient id
        private void getAppointmentsHistoryofPatient(int id)
        {
            
            ServerConnectionagenda.AppointmentClient proxy = new ServerConnectionagenda.AppointmentClient();
            DataTable table;
            if (((table = proxy.getAppointmentsHistorybyPatientID(patient.PatientIDk__BackingField)) ) != null)
            {
                appointmentHistory = new List<string>();
                foreach (DataRow row in table.Rows)
            {
                
                    String appointment = "ID: " + row["appointment_id"].ToString() + " " + row["start_date"].ToString() + " " + row["end_date"].ToString() + " Docter: " + row["first_name"].ToString() + " " + row["last_name"].ToString() + " roomnumber: " + row["room_number"].ToString();
                appointmentHistory.Add(appointment);
            }
              
            }

        }

        //method fills the patientdetails listbox with the appointments history
        private void FillAppointmentstab()
        {
            foreach (string item in appointmentHistory)
            {
                PatientDetailsListbox.Items.Add(item);
            }
        }
    }
}
