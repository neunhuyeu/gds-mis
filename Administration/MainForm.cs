using System;
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
using Administration.Appointments;

namespace Administration
{
    public partial class MainForm : Form
    {
        private MedicalInformation.Patient[] patientsFound;
        private serverAdministration.Staff[] staffFound;

        MedicalInformation.Patient lastSelectedPatient = null;
        serverAdministration.Staff lastSelectedStaff = null;

        MedicalInformation.DoctorClient proxy = new MedicalInformation.DoctorClient();
        serverAdministration.AdministrationClient server = new serverAdministration.AdministrationClient();

        public MainForm(Staff staff)
        {
            InitializeComponent();
            this.lbl_userGreeting.Text = staff.FirstNamek__BackingField;
            this.lbl_dateNow.Text = DateTime.Now.Date.ToString();
            this.DOBSearch.Value = DateTime.Now.Date;
            this.btn_editPatient.Hide();
            this.btn_updatePatient.Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_searchPatient_Click(object sender, EventArgs e)
        {
            this.btn_cancelPatient_Click(null, null);
            searchListLB.Items.Clear();
            if (tbSearchFirstName.Text.Length + tbInsuranceSearch.Text.Length + DOBSearch.Text.Length + tbSearchLastName.Text.Length > 0)
            {
                if (((patientsFound = proxy.SearchPatients(tbSearchFirstName.Text, tbSearchLastName.Text, DOBSearch.Value, tbInsuranceSearch.Text)) != null))
                {
                    foreach (MedicalInformation.Patient patient in patientsFound)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", patient.FirstNamek__BackingField, patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1], patient.InsuranceNumberk__BackingField));

                    }
                }
            }
        }

        private void searchListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.searchListLB.SelectedIndex < 0)
                return;
            int i = this.searchListLB.SelectedIndex;
            lastSelectedPatient = patientsFound[i];
            this.btn_editPatient.Show();
            this.tabControlPatients.SelectedTab = tb_infoEditPatient;
            populateInfoPatientTab(lastSelectedPatient);
        }

        private void btn_searchStaff_Click(object sender, EventArgs e)
        {
            this.btn_cancelPatient_Click(null, null);
            lstbx_staff.Items.Clear();

            if ((staffFound = server.getStaff()) != null)
            {
                foreach (serverAdministration.Staff staff in staffFound)
                {
                    lstbx_staff.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", staff.StaffIDk__BackingField, staff.FirstNamek__BackingField, staff.LastNamek__BackingField, staff.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1]));
                }
            }
        }

        private void lstbx_staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstbx_staff.SelectedIndex < 0)
                return;
            int i = this.lstbx_staff.SelectedIndex;
            lastSelectedStaff = staffFound[i];
            this.btn_editStaff.Show();
            this.tabControlDoctors.SelectedTab = tb_infoEditStaff;
            populateInfoStaffTab(lastSelectedStaff);
        }

        private void populateInfoStaffTab(serverAdministration.Staff s)
        {
            // Personal details.
            lbl_sPersonId.Text = s.PersonIdk__BackingField.ToString();
            lbl_sfname.Text = s.FirstNamek__BackingField;
            lbl_slname.Text = s.LastNamek__BackingField;
            lbl_sdob.Text = s.DateOfBirthk__BackingField.Date.ToString("dd/MM/yyy");
            lbl_semail.Text = s.Emailk__BackingField;
            lbl_smnmr.Text = s.MobileNumberk__BackingField;
            lbl_slnmbr.Text = s.LandLineNumberk__BackingField;
            lbl_saddrs.Text = s.Addressk__BackingField;
            lbl_sinsurance.Text = s.InsuranceNumberk__BackingField.ToString();
            // Staff details.
            lbl_sStaffId.Text = s.StaffIDk__BackingField.ToString();
            lbl_sfunction.Text = s.Functionk__BackingField.ToString();
            lbl_sspecialization.Text = s.Specializationk__BackingField;
            lbl_sroomNmbr.Text = s.RoomNumberk__BackingField.ToString();
        }

        private void editStaff(serverAdministration.Staff staff)
        {
            // Hide staff save button.
            this.btn_saveStaff.Hide();
            this.btn_updateStaff.Show();

            this.tbx_sfname.Text = staff.FirstNamek__BackingField;
            this.tbx_slname.Text = staff.LastNamek__BackingField;
            this.dt_sdob.Value = staff.DateOfBirthk__BackingField;
            this.tbx_semail.Text = staff.Emailk__BackingField;
            this.tbx_smnumber.Text = staff.MobileNumberk__BackingField;
            this.tbx_slnumber.Text = staff.LandLineNumberk__BackingField;
            this.tbx_saddress.Text = staff.Addressk__BackingField;
            this.tbx_sinsurance.Text = staff.InsuranceNumberk__BackingField;
            if (staff.Genderk__BackingField == 'm')
                this.rd_smale.Checked = true;
            else
                this.rd_sfemale.Checked = true;
            this.cmb_function.SelectedItem = staff.Functionk__BackingField;
            this.tbx_sspecialization.Text = staff.Specializationk__BackingField;
            this.tbx_roomNo.Text = staff.RoomNumberk__BackingField.ToString();
        }

        private void editPatient(MedicalInformation.Patient patient)
        {
            // Hide patients save button.
            this.btn_addNewPatient.Hide();
            this.btn_updatePatient.Show();

            this.tbx_pfname.Text = patient.FirstNamek__BackingField;
            this.tbx_plname.Text = patient.LastNamek__BackingField;
            this.dt_pdob.Value = patient.DateOfBirthk__BackingField;
            this.tbx_pemail.Text = patient.Emailk__BackingField;
            this.tbx_pmnumber.Text = patient.MobileNumberk__BackingField;
            this.tbx_plnumber.Text = patient.LandLineNumberk__BackingField;
            this.tbx_paddress.Text = patient.Addressk__BackingField;
            this.tbx_pinsurance.Text = patient.InsuranceNumberk__BackingField;
            if (patient.Genderk__BackingField == 'm')
                this.rd_pmale.Checked = true;
            else
                this.rd_pfemale.Checked = true;
            this.tbx_height.Text = patient.Heightk__BackingField.ToString();
            this.tbx_weight.Text = patient.Weightk__BackingField.ToString();
            this.tbx_bloodType.Text = patient.BloodTypek__BackingField.ToString();
            this.chk_smoker.Checked = patient.Smokerk__BackingField;
            this.trck_druggy.Value = patient.SmokingFrequencyk__BackingField;
            this.chk_druggy.Checked = patient.hard_drugsk__BackingField;
            this.trck_druggy.Value = patient.hard_drugs_frequencyk__BackingField;
        }

        private void btn_cancelPatient_Click(object sender, EventArgs e)
        {
            lastSelectedPatient = null;
            // Clear the Add Tab fields.
            this.tbx_pfname.Text = "";
            this.tbx_plname.Text = "";
            this.dt_pdob.Value = DateTime.Now.Date;
            this.tbx_pemail.Text = "";
            this.tbx_pmnumber.Text = "";
            this.tbx_plnumber.Text = "";
            this.tbx_paddress.Text = "";
            this.tbx_pinsurance.Text = "";
            this.rd_pmale.Checked = false;
            this.rd_pfemale.Checked = false;
            this.tbx_height.Text = "";
            this.tbx_weight.Text = "";
            this.tbx_bloodType.Text = "";
            this.chk_smoker.Checked = false;
            this.trck_druggy.Value = 0;
            this.chk_druggy.Checked = false;
            this.trck_druggy.Value = 0;
            // Switch to the search tab.
            this.tabControlPatients.SelectedTab = tb_searchPatients;
            // Reset the buttons.
            this.btn_editPatient.Hide();
            this.btn_updatePatient.Hide();
            this.btn_addNewPatient.Show();
            // Clear the info/edit tab labels.
            lbl_pPersonId.Text = "";
            lbl_pfname.Text = "";
            lbl_plname.Text = "";
            lbl_paddrs.Text = "";
            lbl_pblood.Text = "";
            lbl_pdob.Text = "";
            lbl_pdruggy.Text = "";
            lbl_pemail.Text = "";
            lbl_pPatientId.Text = "";
            lbl_pheight.Text = "";
            lbl_pweight.Text = "";
            lbl_psmoker.Text = "";
            lbl_pmnmbr.Text = "";
            lbl_plnmbr.Text = "";
            lbl_pinsurance.Text = "";
            lbl_psmkrfrequency.Text = "";
            lbl_druggyfrequency.Text = "";
        }

        private void btn_cancelStaff_Click(object sender, EventArgs e)
        {
            lastSelectedStaff = null;
            // Clear the Add Tab fields.
            this.tbx_sfname.Text = "";
            this.tbx_slname.Text = "";
            this.dt_sdob.Value = DateTime.Now.Date;
            this.tbx_semail.Text = "";
            this.tbx_smnumber.Text = "";
            this.tbx_slnumber.Text = "";
            this.tbx_saddress.Text = "";
            this.tbx_sinsurance.Text = "";
            this.rd_smale.Checked = false;
            this.rd_sfemale.Checked = false;
            // Switch to the search tab.
            this.tabControlDoctors.SelectedTab = tb_searchStaff;
            // Reset the buttons.
            this.btn_editStaff.Hide();
            this.btn_updateStaff.Hide();
            this.btn_saveStaff.Show();
            // Clear the info/edit tab labels.
            // Personal details.
            lbl_sPersonId.Text = "";
            lbl_sfname.Text = "";;
            lbl_slname.Text = "";;
            lbl_sdob.Text = "";
            lbl_semail.Text = "";
            lbl_smnmr.Text = "";
            lbl_slnmbr.Text = "";
            lbl_saddrs.Text = "";
            lbl_sinsurance.Text = "";
            // Staff details.
            lbl_sStaffId.Text = "";
            lbl_sfunction.Text = "";
            lbl_sspecialization.Text = "";
            lbl_sroomNmbr.Text = "";
          }

        public void populateInfoPatientTab(MedicalInformation.Patient p)
        {
            lbl_pPersonId.Text = p.PersonIdk__BackingField.ToString();
            lbl_pfname.Text = p.FirstNamek__BackingField;
            lbl_plname.Text = p.LastNamek__BackingField;
            lbl_paddrs.Text = p.Addressk__BackingField;
            lbl_pblood.Text = p.BloodTypek__BackingField.ToString();
            lbl_pdob.Text = p.DateOfBirthk__BackingField.Date.ToString("dd/MM/yyy");
            lbl_pdruggy.Text = p.hard_drugsk__BackingField ? "Yes" : "No";
            lbl_pemail.Text = p.Emailk__BackingField;
            lbl_pPatientId.Text = p.PatientIDk__BackingField.ToString();
            lbl_pheight.Text = p.Heightk__BackingField.ToString();
            lbl_pweight.Text = p.Weightk__BackingField.ToString();
            lbl_psmoker.Text = p.Smokerk__BackingField ? "Yes" : "No";
            lbl_pmnmbr.Text = p.MobileNumberk__BackingField;
            lbl_plnmbr.Text = p.LandLineNumberk__BackingField;
            lbl_pinsurance.Text = p.InsuranceNumberk__BackingField;
            lbl_psmkrfrequency.Text = p.SmokingFrequencyk__BackingField.ToString();
            lbl_druggyfrequency.Text = p.hard_drugs_frequencyk__BackingField.ToString();
        }

        private void btn_addNewPatient_Click(object sender, EventArgs e)
        {
            // Create a new Patient.
            Administration.serverAdministration.Patient newPatient = getUserInputFromAddPatientTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = server.addPatient(newPatient))
            {
                MessageBox.Show(this, String.Format("The new Patient with name: {0} , was added succesfully.", newPatient.FirstNamek__BackingField), "Success");
                // this.btn_cancelPatient_Click(null, null);
            }
            else
                MessageBox.Show(this, "There was a problem with adding the new Patient.", "Error");
        }

        private void btn_editPatient_Click(object sender, EventArgs e)
        {
            if (this.lastSelectedPatient == null)
                return;
            this.editPatient(lastSelectedPatient);
            this.tabControlPatients.SelectedTab = tb_addPatient;
        }

        private void btn_updatePatient_Click(object sender, EventArgs e)
        {
            // Create a new Patient.
            Administration.serverAdministration.Patient updatedPatient = getUserInputFromAddPatientTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = server.editPatient(updatedPatient))
            {
                MessageBox.Show(this, String.Format("The Patient with name: {0} , was updated succesfully.", updatedPatient.FirstNamek__BackingField), "Success");
                // this.btn_cancelPatient_Click(null, null);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "There was a problem while updating the patient information.", "Error",MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                    this.btn_updatePatient_Click(null, null);
            }
            }

        private serverAdministration.Patient getUserInputFromAddPatientTab()
        {
            // TODO: Add Input validation.

            // Create a new Patient.
            Administration.serverAdministration.Patient patient = new Administration.serverAdministration.Patient();
            // Fill in the details from users input.
            patient.FirstNamek__BackingField = this.tbx_pfname.Text;
            patient.LastNamek__BackingField = this.tbx_plname.Text;
            patient.DateOfBirthk__BackingField = this.dt_pdob.Value;
            patient.Emailk__BackingField = this.tbx_pemail.Text;
            patient.MobileNumberk__BackingField = this.tbx_pmnumber.Text;
            patient.LandLineNumberk__BackingField = this.tbx_plnumber.Text;
            patient.Addressk__BackingField = this.tbx_paddress.Text;
            patient.InsuranceNumberk__BackingField = this.tbx_pinsurance.Text;
            patient.Genderk__BackingField = (this.rd_pmale.Checked && !this.rd_pfemale.Checked) ? 'm' : 'f';
            patient.Heightk__BackingField = Convert.ToInt32(this.tbx_height.Text);
            patient.Weightk__BackingField = Convert.ToInt32(this.tbx_weight.Text);
            patient.BloodTypek__BackingField = this.tbx_bloodType.Text;
            patient.Smokerk__BackingField = this.chk_smoker.Checked;
            patient.SmokingFrequencyk__BackingField = (this.chk_smoker.Checked) ? this.trck_smoker.Value : 0;
            patient.hard_drugsk__BackingField = this.chk_druggy.Checked;
            patient.hard_drugs_frequencyk__BackingField = (this.chk_druggy.Checked) ? this.trck_druggy.Value : 0;
            // Send the object to the caller.
            return patient;
        }

        private void btn_editStaff_Click(object sender, EventArgs e)
        {
            if (this.lastSelectedStaff == null)
                return;
            this.editStaff(lastSelectedStaff);
            this.tabControlDoctors.SelectedTab = tb_addStaff;
        }

        private void btn_saveStaff_Click(object sender, EventArgs e)
        {

            // Create a new Patient.
            Administration.serverAdministration.Staff newStaff = getUserInputFromAddStaffTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = server.addStaff(newStaff))
            {
                MessageBox.Show(this, String.Format("The new Staff member with name: {0} , was added succesfully.", newStaff.FirstNamek__BackingField), "Success");
                // this.btn_cancelPatient_Click(null, null);
            }
            else
                MessageBox.Show(this, "There was a problem while adding the new Staff member.", "Error");
        
        }

        private serverAdministration.Staff getUserInputFromAddStaffTab()
        {
            // TODO: Add Input validation.

            // Create a new Staff.
            Administration.serverAdministration.Staff staff = new Administration.serverAdministration.Staff();
            // Fill in the details from users input.
            staff.FirstNamek__BackingField = this.tbx_sfname.Text;
            staff.LastNamek__BackingField = this.tbx_slname.Text;
            staff.DateOfBirthk__BackingField = this.dt_sdob.Value;
            staff.Emailk__BackingField = this.tbx_semail.Text;
            staff.MobileNumberk__BackingField = this.tbx_smnumber.Text;
            staff.LandLineNumberk__BackingField = this.tbx_slnumber.Text;
            staff.Addressk__BackingField = this.tbx_saddress.Text;
            staff.InsuranceNumberk__BackingField = this.tbx_sinsurance.Text;
            staff.Genderk__BackingField = (this.rd_smale.Checked && !this.rd_sfemale.Checked) ? 'm' : 'f';
            // Staff details
            // TODO: Function has to be of type: Staff.Type
            // enumerator.staff.Functionk__BackingField = cmb_function;
            staff.Specializationk__BackingField = tbx_sspecialization.Text;
            staff.RoomNumberk__BackingField = Convert.ToInt32(tbx_roomNo.Text);
            // Send the object to the caller.
            return staff;
        }

        private void btn_updateStaff_Click(object sender, EventArgs e)
        {
            // Create a new Patient.
            Administration.serverAdministration.Staff updatedStaff = getUserInputFromAddStaffTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = server.editStaff(updatedStaff))
            {
                MessageBox.Show(this, String.Format("The staff member with name: {0} , was updated succesfully.", updatedStaff.FirstNamek__BackingField), "Success");
                // this.btn_cancelStaff_Click(null, null);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "There was a problem while updating the new Staff.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                    this.btn_updateStaff_Click(null, null);
            }
        }
    }
}
