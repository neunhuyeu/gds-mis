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
using Doctor_Client.ServerConnectionagenda;
using System.Threading;

namespace Doctor_Client
{
    
    public partial class Client : Form
    {
        ServerConnectionMedicalInformation.Staff currentUser;
        ServerConnectionMedicalInformation.Patient[] potentualPatients;
        ServerConnectionagenda.Appointment[] agendaAppointments;
        ServerConnectionagenda.Patient[] appointments;
        List<string[]> stringList;
        string[] Appoint;
        DateTime[] DatetimeBold;
        int lastTabIndex;
        public Client(Staff user)
        {
            InitializeComponent();
            currentUser = user;
            userNamelb.Text = " Welcome: " + user.FirstNamek__BackingField + " " + user.LastNamek__BackingField;
            DOBSearch.Value = DateTime.Now.Date;
            lastTabIndex = 0;


        }

        private void searchPatients()
        {
            searchListLB.Items.Clear();
            if (tbSearchFirstName.Text.Length + tbInsuranceSearch.Text.Length + DOBSearch.Text.Length + tbSearchLastName.Text.Length > 0)
            {
                ServerConnectionMedicalInformation.DoctorClient proxy = new ServerConnectionMedicalInformation.DoctorClient();

                if (((potentualPatients = proxy.SearchPatients(tbSearchFirstName.Text, tbSearchLastName.Text, DOBSearch.Value, tbInsuranceSearch.Text)) != null))
                {
                    foreach (ServerConnectionMedicalInformation.Patient patient in potentualPatients)
                    {
                        searchListLB.Items.Add(String.Format("{0,-11}  {1,-11}   {2,8} {0,25}", patient.FirstNamek__BackingField, patient.LastNamek__BackingField, patient.DateOfBirthk__BackingField.GetDateTimeFormats('d')[1], patient.InsuranceNumberk__BackingField));

                    }
                }


            }
        }


        private void getAppointmentsoftheDay()
        {
            stringList = new List<string[]>();
            ServerConnectionagenda.AppointmentClient proxy = new ServerConnectionagenda.AppointmentClient();
            if ((appointments = proxy.getAppointmnetsOfToday(currentUser.StaffIDk__BackingField)) != null)
            {
                foreach (ServerConnectionagenda.Patient appoint in appointments)
                {
                    stringList.Add(new string[] { Convert.ToString(appoint.PatientIDk__BackingField), Convert.ToString(appoint.InsuranceNumberk__BackingField), Convert.ToString(appoint.FirstNamek__BackingField), Convert.ToString(appoint.LastNamek__BackingField), Convert.ToString(appoint.DateOfBirthk__BackingField), Convert.ToString(appoint.MobileNumberk__BackingField) });

                }
            }

        }


        private DateTime[] getAppointmentsHistorybyStaffid()
        {

            ServerConnectionagenda.AppointmentClient proxy = new ServerConnectionagenda.AppointmentClient();
            if (((agendaAppointments = proxy.SearchAppointmentsByStaffID(currentUser.StaffIDk__BackingField)) != null))
            {
                DatetimeBold = new DateTime[agendaAppointments.Length];

                for (int i = 0; i < agendaAppointments.Length; i++)
                {
                    DatetimeBold[i] = agendaAppointments[i].start_date;
                }

            }
            return DatetimeBold;

        }

        private void Client_Load(object sender, EventArgs e)
        {



           this.monthCalendar1.AnnuallyBoldedDates = getAppointmentsHistorybyStaffid();


            searchPatients();
            getAppointmentsoftheDay();

            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = "Patient ID";
            dataGridView2.Columns[1].Name = "Insurance Number";
            dataGridView2.Columns[2].Name = "First Name";
            dataGridView2.Columns[3].Name = "Last Name";
            dataGridView2.Columns[4].Name = "Date of Birth";
            dataGridView2.Columns[5].Name = "Phone Number";
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
            PatientDetails Patient = new PatientDetails(potentualPatients[searchListLB.SelectedIndex], currentUser);
            this.Visible = false;
            Patient.ShowDialog();
            this.Visible = true;
        }



        private void btn_searchPatients_Click(object sender, EventArgs e)
        {
            searchPatients();
        }

        private void tbSearchFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            searchPatients();
        }

        private void getAppointmentsbyspecificDate(DateTime date)
        {
            int i = 0;

            ServerConnectionagenda.AppointmentClient proxy = new ServerConnectionagenda.AppointmentClient();
            ServerConnectionagenda.Patient[] agendaPatients;
            if (((agendaPatients = proxy.SearchappointmentsbyDate(date, currentUser.StaffIDk__BackingField)) != null))
            {
                Appoint = new string[agendaPatients.Length];
                foreach (ServerConnectionagenda.Patient patient in agendaPatients)
                {

                    Appoint[i] = ("PatientID: " + patient.PatientIDk__BackingField.ToString() + " InsuranceNumber: " + patient.InsuranceNumberk__BackingField + " Name: " + patient.FirstNamek__BackingField + " " + patient.LastNamek__BackingField + " born:" + patient.DateOfBirthk__BackingField.ToString());
                    i++;


                }
            }

        }

        

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            agendaList.Items.Clear();
             getAppointmentsbyspecificDate(monthCalendar1.SelectionRange.Start);
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

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedIndex == 3)
            {
                tabs.SelectedIndex = lastTabIndex;
                Wiki wiki = new Wiki();
                wiki.isclosed = false;
                wiki.Show();
                //Thread t1 = new Thread(NewWiki);
                //t1.Name = "wiki Thread";
                //t1.IsBackground = true;
                //t1.Start();
            }
            else 
            {
                lastTabIndex = tabs.SelectedIndex;
            }
        }
       
        public void NewWiki()
        {
      
         Wiki wiki = new Wiki();
         wiki.isclosed=false;
         wiki.Show();
           while(!wiki.isclosed)
            {
                
               Application.DoEvents();
            }
}
        

     



       




        }
    }

