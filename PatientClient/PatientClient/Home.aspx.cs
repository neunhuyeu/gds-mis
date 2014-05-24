using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        AppointmentClient proxy;
        Patient patient { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            proxy = new AppointmentClient();
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string pass = txtPwd.Text;

            if (username.Length > 7 && pass.Length > 2)
            {
                patient = proxy.Login(username, pass);
                if (patient != null)
                {
                    this.FormLogin.Visible = false;
                    this.patientName.Text = "Welcome, " + patient.FirstNamek__BackingField;
                }
            }
            Global.patient.PatientIDk__BackingField = patient.PersonIdk__BackingField;
            Global.patient.FirstNamek__BackingField = patient.FirstNamek__BackingField;
        }
    }
}