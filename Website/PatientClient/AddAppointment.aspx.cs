using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class AddAppointment : System.Web.UI.Page
{
    AppointmentClient proxy;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new AppointmentClient();
        FillInDoctorsList(proxy);
        BindXml();
    }

    protected void calDate_SelectionChanged(object sender, EventArgs e)
    {
        txtDate.Text = calDate.SelectedDate.ToString("d");
    }

    void FillInDoctorsList(AppointmentClient prox)
    {
        dt = prox.getDoctorsList();
        DoctorsList.DataSource = dt;
        DoctorsList.DataTextField = "last_name";
        DoctorsList.DataBind();
    }

    private void BindXml()
    {
        string filePath = Server.MapPath("~/OpeningHours.xml");
        using (DataSet ds = new DataSet())
        {
            ds.ReadXml(filePath);
            TimeList.DataSource = ds;
            TimeList.DataTextField = "Period_Text";
            TimeList.DataBind();
        }
    }
    protected void Confirm_Click(object sender, EventArgs e)
    {

    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Appointments.aspx");
    }
}