using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DayPilot.Utils;
using DayPilot.Web;
using DayPilot.Web.Ui;
using WebApplication1.ServiceReference1;
using System.Data;


namespace WebApplication1
{
    public partial class Meetings
    {
        public int appointmentNumber { get; set; }
        public DateTime startDate { get; set; }
    }

    public partial class Appointments : Page
    {

        AppointmentClient proxy;
        DataTable dt;
        public Appointment[] appointments { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            proxy = new AppointmentClient();
            
            int patientId = 0;
            patientId = Global.patient.PatientIDk__BackingField;
            patientName.Text = "Welcome, " + Global.patient.FirstNamek__BackingField;

            if (patientId != 0)
            {
                dt = proxy.getAppointmentsHistorybyPatient(patientId);
            }

            dt.Columns.Remove("patient_id");
            dt.Columns.Remove("staff_id");
            dt.Columns.Add("appointment", typeof(string));

            DayPilotCalendar1.DataSource = dt;

            DayPilotCalendar1.DataStartField = "start_date";
            DayPilotCalendar1.DataEndField = "end_date";
            DayPilotCalendar1.DataTextField = "appointment";
            DayPilotCalendar1.DataValueField = "appointment_id";

            DayPilotCalendar1.StartDate = DateTime.Now;
            DayPilotCalendar1.Days = 5;

            if (!IsPostBack)
                DayPilotCalendar1.DataBind();

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        ArrayList getData()
        {

            ArrayList meetings = new ArrayList();

            for (int i = 0; i < appointments.Length; i++)
            {
                Meetings m = new Meetings();
                m.appointmentNumber = i + 1;
                m.startDate = appointments[i].start_date;
                meetings.Add(m);
            }

            return meetings;

        }

        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Appointment Number";
                e.Row.Cells[1].Text = "Start Date      ";
                e.Row.Cells[2].Text = "End Date      ";
            }
        }
        
    }

    
}