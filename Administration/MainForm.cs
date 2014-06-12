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
using Administration.serverAdministration;

namespace Administration
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The user that logged in to the administration service.
        /// </summary>
        private Administration.MedicalInformation.Staff loggedInUser;

        /* Keep a list of the searched staff and patients. */

        /// <summary>
        /// Patients array as returned from the Medical service.
        /// </summary>
        private MedicalInformation.Patient[] patientsFound;

        /// <summary>
        /// Staff array as returned from Administration service.
        /// </summary>
        private serverAdministration.Staff[] staffFound;

        /// <summary>
        /// Appointments array as returned from Appointments(aka. Agenda) service.
        /// </summary>
        private Appointments.Appointment[] appointmentsFound;

        /* Keep the users last selection for convenience. */

        /// <summary>
        /// The Patient object the user selected last.
        /// </summary>
        MedicalInformation.Patient lastSelectedPatient = null;

        /// <summary>
        /// The Staff object the user selected last.
        /// </summary>
        serverAdministration.Staff lastSelectedStaff = null;

        Appointments.Appointment lastSelectedAppointment = new Appointments.Appointment();

        /* Define the service access points. */

        /// <summary>
        /// Medical Information service.
        /// </summary>
        MedicalInformation.DoctorClient medical = new MedicalInformation.DoctorClient();

        /// <summary>
        /// Administration service.
        /// </summary>
        serverAdministration.AdministrationClient admin = new serverAdministration.AdministrationClient();

        /// <summary>
        /// Agenda service.
        /// </summary>
        Appointments.AppointmentClient agenda = new Appointments.AppointmentClient();

        /// <summary>
        /// A dialog result object holding the users reply.
        /// </summary>
        DialogResult dr;

        /// <summary>
        /// Main form constructor.
        /// </summary>
        /// <param name="staff">The staff object that logged in sucssefully.</param>
        public MainForm(MedicalInformation.Staff staff)
        {
            InitializeComponent();
            this.loggedInUser = staff;
            this.lbl_userGreeting.Text = loggedInUser.FirstNamek__BackingField;
            this.lbl_dateNow.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            this.DOBSearch.Value = DateTime.Now.Date;
            this.btn_editPatient.Hide();
            this.btn_updatePatient.Hide();
        }

        /// <summary>
        /// Logs out the user and exits the main form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_logout(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Auto search event for patients.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_searchPatients(object sender, EventArgs e)
        {
            this.event_clearPatients(null, null);
            searchListLB.Items.Clear();
            if (tbSearchFirstName.Text.Length + tbInsuranceSearch.Text.Length + DOBSearch.Text.Length + tbSearchLastName.Text.Length > 0)
            {
                if (((patientsFound = medical.SearchPatients(tbSearchFirstName.Text, tbSearchLastName.Text, DOBSearch.Value, tbInsuranceSearch.Text)) != null))
                {
                    foreach (MedicalInformation.Patient patient in patientsFound)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", patient.FirstNamek__BackingField, patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1], patient.InsuranceNumberk__BackingField));

                    }
                }
            }
        }

        /// <summary>
        /// Event that fires on selection of a patient.
        /// Redirect the user to the edit info page and updates the labels with the patients details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_selectedPatient(object sender, EventArgs e)
        {
            this.event_clearPatients(null, null);
            if (this.searchListLB.SelectedIndex < 0)
                return;
            lastSelectedPatient = patientsFound[this.searchListLB.SelectedIndex];
            this.btn_editPatient.Show();
            this.tabControlPatients.SelectedTab = tb_infoEditPatient;
            populateInfoPatientTab(lastSelectedPatient);
            this.event_getAppointments(null, null);
        }

        /// <summary>
        /// Event to search for staff members.
        /// If an id is given for the search, it ignores the names of the users.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_searchStaff(object sender, EventArgs e)
        {
            lstbx_staff.Items.Clear();

            if (
            this.tbx_sSearchFname.Text.Length +
            this.tbx_sSearchLname.Text.Length +
            this.tbx_sSearchStaffId.Text.Length == 0)
            {
                staffFound = admin.getAllStaff();
            }
            else
            {
                    if (this.tbx_sSearchStaffId.Text.Length > 0)
               {
                    int id = -1;
                    try { id = Convert.ToInt32(this.tbx_sSearchStaffId.Text); }
                    catch (FormatException)
                    {
                        MessageBox.Show("The given input is not in the right format.", "Error");
                        return;
                    }
                    staffFound = admin.searchStaff("", "", id);
                }
                else { staffFound = admin.searchStaff(this.tbx_sSearchFname.Text, this.tbx_sSearchLname.Text, -1); }
            }
            if (staffFound != null)
            {
                foreach (serverAdministration.Staff staff in staffFound)
                {
                    lstbx_staff.Items.Add(String.Format("{0,-5} {1,-25} {2,-25} {3,-5}", staff.StaffIDk__BackingField, staff.FirstNamek__BackingField, staff.LastNamek__BackingField, staff.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1]));
                }
            }
        }

        /// <summary>
        /// Event that fires when a staff person is selected.
        /// Redirects the user to the info page and fills in the appropriate labels with his details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_selectedStaff(object sender, EventArgs e)
        {
            this.event_clearStaff(null, null);
            if (this.lstbx_staff.SelectedIndex < 0)
                return;
            lastSelectedStaff = staffFound[this.lstbx_staff.SelectedIndex];
            this.btn_editStaff.Show();
            this.tabControlDoctors.SelectedTab = tb_infoEditStaff;
            populateInfoStaffTab(lastSelectedStaff);
        }

        /// <summary>
        /// Convention function to opulate the info staff page.
        /// </summary>
        /// <param name="s"></param>
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

        /// <summary>
        /// Populates the add staff tab with a selected staff members data in order to edit them.
        /// </summary>
        /// <param name="staff"></param>
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

        /// <summary>
        /// Populates the add patient tab with a selected patient members data in order to edit them.
        /// </summary>
        /// <param name="patient"></param>
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

        /// <summary>
        /// Resets all the patient details and clears all the fields from the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_clearPatients(object sender, EventArgs e)
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

        /// <summary>
        /// Resets all the form fields of the staff tab and clears the staff related variables.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_clearStaff(object sender, EventArgs e)
        {
            lastSelectedStaff = null;
            // Clear the search tab.
            this.tbx_sSearchFname.Text = "";
            this.tbx_sSearchLname.Text = "";
            this.tbx_sSearchStaffId.Text = "";
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
            lbl_sfname.Text = ""; ;
            lbl_slname.Text = ""; ;
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

        /// <summary>
        /// Populates the info patient tab with a given patients details. 
        /// </summary>
        /// <param name="p">Patient Object</param>
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

        /// <summary>
        /// Connects to the service and tries to insert a new patient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_addPatient(object sender, EventArgs e)
        {
            // Create a new Patient.
            Administration.serverAdministration.Patient newPatient = getUserInputFromAddPatientTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = admin.addPatient(newPatient))
            {
                MessageBox.Show(this, String.Format("The new Patient with name: {0} , was added succesfully.", newPatient.FirstNamek__BackingField), "Success");
                // this.btn_cancelPatient_Click(null, null);
            }
            else
                MessageBox.Show(this, "There was a problem with adding the new Patient.", "Error");
        }

        /// <summary>
        /// Event that fires when a user chooses to edit a patient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_editPatient(object sender, EventArgs e)
        {
            if (this.lastSelectedPatient == null)
                return;
            this.editPatient(lastSelectedPatient);
            this.tabControlPatients.SelectedTab = tb_addPatient;
        }

        /// <summary>
        /// Connects to the service and tries to update a patient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_updatePatient(object sender, EventArgs e)
        {
            // Create a new Patient.
            Administration.serverAdministration.Patient updatedPatient = getUserInputFromAddPatientTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = admin.editPatient(updatedPatient))
            {
                MessageBox.Show(this, String.Format("The Patient with name: {0} , was updated succesfully.", updatedPatient.FirstNamek__BackingField), "Success");
                // this.btn_cancelPatient_Click(null, null);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "There was a problem while updating the patient information.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                    this.event_updatePatient(null, null);
            }
        }

        /// <summary>
        /// Gets the user input from the add patient tab fields.
        /// </summary>
        /// <returns>A patient Object</returns>
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

        /// <summary>
        /// Event that fires when the user chooses to edit a staff member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_editStaff(object sender, EventArgs e)
        {
            if (this.lastSelectedStaff == null)
                return;
            this.editStaff(lastSelectedStaff);
            this.tabControlDoctors.SelectedTab = tb_addStaff;
        }

        /// <summary>
        /// Connects to the service and tries to insert a new staff member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_addStaff(object sender, EventArgs e)
        {

            // Create a new Patient.
            Administration.serverAdministration.Staff newStaff = getUserInputFromAddStaffTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = admin.addStaff(newStaff))
            {
                MessageBox.Show(this, String.Format("The new Staff member with name: {0} , was added succesfully.", newStaff.FirstNamek__BackingField), "Success");
                // this.btn_cancelPatient_Click(null, null);
            }
            else
                MessageBox.Show(this, "There was a problem while adding the new Staff member.", "Error");

        }

        /// <summary>
        /// Gets the user input from the add patient tab.
        /// </summary>
        /// <returns>A Staff Object</returns>
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
            staff.Functionk__BackingField = cmb_function.SelectedItem.ToString();
            staff.Specializationk__BackingField = tbx_sspecialization.Text;
            staff.RoomNumberk__BackingField = tbx_roomNo.Text;
            // Send the object to the caller.
            return staff;
        }

        /// <summary>
        /// Connects to the service and tries to update a staff member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_updateStaff(object sender, EventArgs e)
        {
            // Create a new Patient.
            Administration.serverAdministration.Staff updatedStaff = getUserInputFromAddStaffTab();

            bool result;
            // Send the request for new patient to the server.
            if (result = admin.editStaff(updatedStaff))
            {
                MessageBox.Show(this, String.Format("The staff member with name: {0} , was updated succesfully.", updatedStaff.FirstNamek__BackingField), "Success");
                // this.btn_cancelStaff_Click(null, null);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "There was a problem while updating the new Staff.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                    this.event_updateStaff(null, null);
            }
        }

        /// <summary>
        /// Connects to the server and tries to delete a staff member.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_deleteStaff(object sender, EventArgs e)
        {
            // Get the chosen staff memebr.
            if (this.lastSelectedStaff == null)
            {
                MessageBox.Show("No staff selected..\nDroping the request.");
                return;
            }
            else
            {
                dr = MessageBox.Show(string.Format("Are you sure you want to DELETE the staff member: {0} with ID {1}", this.lastSelectedStaff.LastNamek__BackingField, this.lastSelectedStaff.StaffIDk__BackingField.ToString()), "Notice", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else if (dr == DialogResult.Cancel)
                {
                    this.event_clearStaff(null, null);
                }
            }
            bool result;
            // Send the request for new patient to the server.
            if (result = admin.removeStaff(this.lastSelectedStaff))
            {
                MessageBox.Show(this, String.Format("The staff member with staff ID: {0} , was deleted succesfully.", this.lastSelectedStaff.StaffIDk__BackingField), "Success");
                this.event_clearStaff(null, null);
            }
            else
            {
                dr = MessageBox.Show(this, "There was a problem while deleting the Staff mamber.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Retry)
                    this.event_deleteStaff(null, null);
            }
        }

        /// <summary>
        /// Connects to the service and retrieves all appointments for a given patient.
        /// If a date is chosen from the datepicker. It will search for appointmets on that date only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_getAppointments(object sender, EventArgs e)
        {

            if (this.lastSelectedPatient == null)
            {
                this.clearAppointments();
                return;
            }
            this.clearAppointments(false);
            string date = "";
            if (sender != null && sender.Equals(this.clndr_appointments))
            {
                date = this.clndr_appointments.SelectionStart.Date.ToString();
            }
            this.appointmentsFound = agenda.getAppointmentsListbyPatientId(this.lastSelectedPatient.PatientIDk__BackingField, date);

            if (appointmentsFound != null && appointmentsFound.Length > 0)
            {
                foreach (Administration.Appointments.Appointment ap in appointmentsFound)
                {
                    this.lstbx_patientAppointments.Items.Add(string.Format("{0}\t{1}\t{2}\t{3}", ap.appointmentID, ap.start_date, ap.end_date, ap.staff_id));
                    this.clndr_appointments.AddBoldedDate(ap.start_date);
                }
            }
            else
            {
                this.clearAppointments();
            }
        }

        /// <summary>
        /// Fires when the user selects an appointment from the list.
        /// Populates the doctor related fields associated with the appointment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_selectedAppointment(object sender, EventArgs e)
        {
            this.event_clearStaff(null, null);
            if (this.lstbx_patientAppointments.SelectedIndex < 0)
                return;
            lastSelectedAppointment = appointmentsFound[this.lstbx_patientAppointments.SelectedIndex];
            showAppointmentInfo(lastSelectedAppointment);
        }

        /// <summary>
        /// Fills in the staff info on the appointments details tab for a given appointment object.
        /// </summary>
        /// <param name="lastSelectedAppointment">An appointment object</param>
        private void showAppointmentInfo(Appointments.Appointment lastSelectedAppointment)
        {
            serverAdministration.Staff s = admin.getStaffById(lastSelectedAppointment.staff_id);
            if (s == null)
                return;
            this.lbl_apDoctor.Text = string.Format("{0} {1}", s.LastNamek__BackingField, s.FirstNamek__BackingField);
            this.lbl_apFunction.Text = s.Functionk__BackingField.ToString();
            this.lbl_apRoomNr.Text = s.RoomNumberk__BackingField.ToString();
            this.lbl_apSpecialization.Text = s.Specializationk__BackingField.ToString();
        }

        /// <summary>
        /// Clears all the appointment related fields and variables.
        /// </summary>
        /// <param name="clearAll">(Optional) Pass FALSE to clear only the form fields, not the variables</param>
        private void clearAppointments(bool clearAll = true)
        {
            if (clearAll)
            {
                this.lastSelectedAppointment = new Appointments.Appointment();
                this.appointmentsFound = null;
                this.clndr_appointments.RemoveAllBoldedDates();
            }
            this.lstbx_patientAppointments.Items.Clear();
            this.lbl_apDoctor.Text = "";
            this.lbl_apFunction.Text = "";
            this.lbl_apRoomNr.Text = "";
            this.lbl_apSpecialization.Text = "";
        }

        /// <summary>
        /// Event that controls the users navigation when being on the patients section.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_onTabPatientsSelection(object sender, EventArgs e)
        {
            if (tabControlPatients.SelectedTab == tb_patientDetails)
            {
                serverAdministration.Staff[] allStaff = admin.getAllStaff();
                foreach (serverAdministration.Staff s in allStaff)
                {
                    if (s.Specializationk__BackingField != null)
                    {
                        this.cmb_addAppointmentDoctor.Items.Add(string.Format("{0} : {1}", s.Specializationk__BackingField, s.LastNamek__BackingField));
                    }
                }
                this.dt_addAppointment.Value = DateTime.Now;
                if (tabControlPatientsDetails.SelectedTab == tabAppointments)
                    this.event_getAppointments(null, null);
                else
                {
                    this.clearAppointments();
                }
            }
        }

        /// <summary>
        /// Connects to the agenda service and tries to add a new appointment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void event_addAppointment(object sender, EventArgs e)
        {
            if (validateAddAppointmentInput() == false)
            {
                return;
            }

            string staffName = admin.getAllStaff()[this.cmb_addAppointmentDoctor.SelectedIndex].LastNamek__BackingField;
            string startTime = new DateTime(dt_addAppointment.Value.Date.Year, dt_addAppointment.Value.Month, dt_addAppointment.Value.Day, Convert.ToInt32(cmb_addAppointmentStartTime.SelectedItem.ToString().Split(':')[0]), Convert.ToInt32(cmb_addAppointmentStartTime.SelectedItem.ToString().Split(':')[1]), 0).ToString();
            string endTime = new DateTime(dt_addAppointment.Value.Date.Year, dt_addAppointment.Value.Month, dt_addAppointment.Value.Day, Convert.ToInt32(cmb_addAppointmentEndTime.SelectedItem.ToString().Split(':')[0]), Convert.ToInt32(cmb_addAppointmentEndTime.SelectedItem.ToString().Split(':')[1]), 0).ToString();

            if (agenda.AddAppointment(staffName, lastSelectedPatient.Emailk__BackingField, startTime, endTime))
            {
                MessageBox.Show("Succesfully added the appointment.");
            }
            else
            {
                MessageBox.Show("Appointment was NOT added. Try different dates.");
            }

        }

        /// <summary>
        /// Gets and validates the user input from the add appointments section.
        /// If input is invalid, the user is notified.
        /// </summary>
        /// <returns>True on correct input | False otherwise</returns>
        private bool validateAddAppointmentInput()
        {
            if (this.lastSelectedPatient == null)
            {
                MessageBox.Show("No patient record is defined.");
                return false;
            }
            if (this.cmb_addAppointmentDoctor.SelectedIndex < 0)
            {
                MessageBox.Show("You need to select a doctor first.");
                return false;
            }
            if (this.dt_addAppointment.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Only future dates are available for booking.");
                return false;
            }
            if (this.cmb_addAppointmentStartTime.SelectedIndex + this.cmb_addAppointmentEndTime.SelectedIndex < 0)
            {
                MessageBox.Show("You Have to select both start and end time.");
                return false;
            }
            if (Convert.ToDateTime(this.cmb_addAppointmentEndTime.SelectedItem) < Convert.ToDateTime(this.cmb_addAppointmentStartTime.SelectedItem))
            {
                MessageBox.Show("End time cannot be earlier than the start time.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Actions to take when the main tab is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Common functionality.
            this.event_clearPatients(null, null);
            this.event_clearStaff(null, null);
            this.clearAppointments();

            if (tabControlMain.SelectedTab == tb_main)
            {
            }
            else if (tabControlMain.SelectedTab == tb_patients)
            {
                this.event_searchPatients(null, null);
            }
            else if (tabControlMain.SelectedTab == tb_staff)
            {
                this.event_searchStaff(null, null);
            }
            else 
            {}

        }
    }

}
