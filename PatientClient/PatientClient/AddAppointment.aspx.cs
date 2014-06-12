using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using ServiceReference1;
using System.Globalization;

public partial class AddAppointment : System.Web.UI.Page
{
    AppointmentClient proxy;
    DataTable DT;

    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new AppointmentClient();
        //FillInDoctorsList(proxy);
        //BindXml();
    }

    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = calDate.SelectedDate.ToString("d");
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        string appDate = txtDate.Text;

        string time = TimeList.SelectedValue;

        DateTime dt = DateTime.ParseExact(appDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        if (dt > DateTime.Now && dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
        {
            appDate = dt.ToString("yyyy-MM-dd");

            string appStart = appDate + " " + time + ":00";

            string appEnd = appDate + " " + GetTimeEndAppointment(time) + ":00";

            bool reserved = proxy.AddAppointment(DoctorsList.SelectedValue, Session["username"].ToString(), appStart, appEnd);

            if (reserved)
                ReservationMessage.Text = "Your appointment has been confirmed on " + appStart;
            else
                ReservationMessage.Text = "Doctor is not available, try another time or other days!";
        }
        else
            ReservationMessage.Text = "You can not select a day in the past or in the weekend for an appointment!";

    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Appointments.aspx");
    }

    string GetTimeEndAppointment(string t)
    {
        int hour = Convert.ToInt32(t.Substring(0, 2));
        int min = Convert.ToInt32(t.Substring(3, 2));

        if (min == 0)
        {
            min = 30;
            if(hour > 9)
                return t = hour.ToString() + ":" + min.ToString();
            else
                return t = "0" + hour.ToString() + ":" + min.ToString();
        }
        else
        {
            hour++;
            if (hour > 9)
                return t = hour.ToString() + ":00";
            else
                return t = "0" + hour.ToString() + ":00";
        }
    }
}