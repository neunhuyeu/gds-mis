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
        ServerConnection.Consultation[] consultations;
        List<string[]> stringList;
        string[] Appoint;
        DateTime[] DatetimeBold;

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

                if (((potentualPatients = proxy.SearchPatients(tbSearchFirstName.Text, tbSearchLastName.Text, DOBSearch.Value, tbInsuranceSearch.Text)) != null))
                { 
                    foreach (Patient patient in potentualPatients)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", patient.FirstNamek__BackingField, patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1], patient.InsuranceNumberk__BackingField));

                    }
                }


            }
        }

        private void getConsultationsoftheDay()
        {
            stringList = new List<string[]>();
            ServerConnection.DoctorClient proxy = new ServerConnection.DoctorClient();
            if (((consultations = proxy.getConsultationOfToday(currentUser.StaffIDk__BackingField)) != null))
            {
                foreach (Consultation consul in consultations)
                {
                    stringList.Add(new string[] { Convert.ToString(consul.start_date), Convert.ToString(consul.end_date), Convert.ToString(consul.patient_id) });

                }
            }
           
        }

        private DateTime[] getConsultationsHistorybyStaffid()
        {
            
            ServerConnection.DoctorClient proxy = new ServerConnection.DoctorClient();
            if (((consultations = proxy.SearchconsultionHistoryByStaffID(currentUser.StaffIDk__BackingField)) != null))
            {
                DatetimeBold = new DateTime[consultations.Length];

                for (int i = 0; i < consultations.Length; i++)
                {
                    DatetimeBold[i] = consultations[i].start_date;
                }

            }

            return DatetimeBold;

        }

        private void Client_Load(object sender, EventArgs e)
        {



            this.monthCalendar1.AnnuallyBoldedDates = getConsultationsHistorybyStaffid();




            
            searchPatients();
            getConsultationsoftheDay();

            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].Name = "start date";
            dataGridView2.Columns[1].Name = "end date";
            dataGridView2.Columns[2].Name = "patient ID";         

            foreach (string[] item in stringList)
            {
                dataGridView2.Rows.Add(item);
            }
                     
        }

        private void logoubtn_Click(object sender, EventArgs e)
        {
          this.Close();

        }

        private void searchListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientDetails Patient = new PatientDetails(potentualPatients[searchListLB.SelectedIndex],currentUser);
            this.Visible = false;
            Patient.ShowDialog();
            this.Visible=true;
        }

      

        private void btn_searchPatients_Click(object sender, EventArgs e)
        {
            searchPatients();
        }

        private void tbSearchFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            searchPatients();
        }

        private void getConsultationsbyspecificDate(DateTime date)
        {
            int i = 0;
           
            ServerConnection.DoctorClient proxy = new ServerConnection.DoctorClient();
            if (((potentualPatients = proxy.SearchConsultationsbyDate(date,currentUser.StaffIDk__BackingField)) != null))
            {
                Appoint = new string[potentualPatients.Length];
                foreach (Patient patient in potentualPatients)
                {
                    
                    Appoint[i] = ("PersonId: " + patient.PersonIdk__BackingField.ToString() + " Name: " + patient.FirstNamek__BackingField +" " + patient.LastNamek__BackingField + " born:" + patient.DateOfBirthk__BackingField.ToString());
                    i++;
                    

                }
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            agendaList.Items.Clear();
            getConsultationsbyspecificDate(monthCalendar1.SelectionRange.Start);
            if (Appoint != null)
            {
                agendaList.Items.Clear();
                foreach (string item in Appoint)
                {
                    agendaList.Items.Add(item);
                }
                Appoint = null;
            }
           
        }

        private void btn_editPatient_Click(object sender, EventArgs e)
        {
            //should the Doctor add a patient or should the administration  could be doing that.
        }

 
    }
}
