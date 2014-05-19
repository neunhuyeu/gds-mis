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
        private MedicalInformation.Patient[] patientsFound; //  patientsFound;

        public MainForm(Staff staff)
        {
            InitializeComponent();
            this.lbl_userGreeting.Text = staff.FirstNamek__BackingField;
            this.lbl_dateNow.Text = DateTime.Now.Date.ToString();
            this.DOBSearch.Value = DateTime.Now.Date;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_searchPatient_Click(object sender, EventArgs e)
        {
            searchListLB.Items.Clear();
            if (tbSearchFirstName.Text.Length + tbInsuranceSearch.Text.Length + DOBSearch.Text.Length + tbSearchLastName.Text.Length > 0)
            {
                MedicalInformation.DoctorClient proxy = new MedicalInformation.DoctorClient();

                if (((patientsFound = proxy.SearchPatients(tbSearchFirstName.Text, tbSearchLastName.Text, DOBSearch.Value, tbInsuranceSearch.Text)) != null))
                {
                    foreach (MedicalInformation.Patient patient in patientsFound)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", patient.FirstNamek__BackingField, patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1], patient.InsuranceNumberk__BackingField));

                    }
                }
            }
        }

        private void btn_searchStaff_Click(object sender, EventArgs e)
        {
        }

        private void searchListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbx_pfname.Text = patientsFound[this.searchListLB.SelectedIndex].FirstNamek__BackingField;
            this.tbx_plname.Text = patientsFound[this.searchListLB.SelectedIndex].LastNamek__BackingField;
            this.dt_pdob.Value = patientsFound[this.searchListLB.SelectedIndex].DateOfBirthk__BackingField;
            this.tbx_pemail.Text = patientsFound[this.searchListLB.SelectedIndex].Emailk__BackingField;
            this.tbx_pmnumber.Text = patientsFound[this.searchListLB.SelectedIndex].MobileNumberk__BackingField;
            this.tbx_plnumber.Text = patientsFound[this.searchListLB.SelectedIndex].LandLineNumberk__BackingField;
            this.tbx_paddress.Text = patientsFound[this.searchListLB.SelectedIndex].Addressk__BackingField;
            this.tbx_pinsurance.Text = patientsFound[this.searchListLB.SelectedIndex].InsuranceNumberk__BackingField;
            if (patientsFound[this.searchListLB.SelectedIndex].Genderk__BackingField == 'm')
                this.rd_pmale.Checked = true;
            else
                this.rd_pfemale.Checked = true;
            this.tbx_height.Text = patientsFound[this.searchListLB.SelectedIndex].Heightk__BackingField.ToString();
            this.tbx_weight.Text = patientsFound[this.searchListLB.SelectedIndex].Weightk__BackingField.ToString();
            this.tbx_bloodType.Text = patientsFound[this.searchListLB.SelectedIndex].BloodTypek__BackingField.ToString() ;
            this.chk_smoker.Checked= patientsFound[this.searchListLB.SelectedIndex].Smokerk__BackingField;
            this.trck_druggy.Value = patientsFound[this.searchListLB.SelectedIndex].SmokingFrequencyk__BackingField;
            this.chk_druggy.Checked = patientsFound[this.searchListLB.SelectedIndex].hard_drugsk__BackingField;
            this.trck_druggy.Value = patientsFound[this.searchListLB.SelectedIndex].hard_drugs_frequencyk__BackingField;
            this.tabControlPatients.SelectedTab = tb_addPatient;
        }

        private void btn_cancelPatient_Click(object sender, EventArgs e)
        {
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
            this.tabControlPatients.SelectedTab = tb_searchPatients;
        }
    }
}
