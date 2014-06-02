using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class Meetings
{
    public int appointmentNumber { get; set; }
    public DateTime startDate { get; set; }
}

public partial class Appointments : System.Web.UI.Page
{
    AppointmentClient proxy;
    DataTable dt;
    public Appointment[] appointments { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new AppointmentClient();

        string un = Session["username"].ToString();

        dt = proxy.getAppointmentsHistorybyPatient(un);

        CustomizeColumns();

        GetFutureAppointments();

        if (!IsPostBack)
            DayPilotCalendar1.DataBind();

        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    private void GetFutureAppointments()
    {
        DayPilotCalendar1.DataSource = dt;
        DayPilotCalendar1.DataStartField = "Start Date";
        DayPilotCalendar1.DataEndField = "End Date";
        DayPilotCalendar1.DataTextField = "Doctor";
        DayPilotCalendar1.DataValueField = "Appointment Number";
        DayPilotCalendar1.StartDate = DateTime.Now;
        DayPilotCalendar1.Days = 7;
    }

    private void CustomizeColumns()
    {
        dt.Columns["appointment_id"].ColumnName = "Appointment Number";
        dt.Columns["start_date"].ColumnName = "Start Date";
        dt.Columns["end_date"].ColumnName = "End Date";
        dt.Columns["last_name"].ColumnName = "Doctor";
    }
}