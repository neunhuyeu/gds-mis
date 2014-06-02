using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class LogIn : System.Web.UI.Page
{
    AppointmentClient proxy;
    Patient patient { set; get; }

    protected void Page_Load(object sender, EventArgs e)
    {
        proxy = new AppointmentClient();
    }

    protected void MyLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string us = LoginControl1.UserName;
        string pas = LoginControl1.Password;

        if (Log(us, pas))
        {
            e.Authenticated = true;
            Session["username"] = us;
        }
        else
        {
            e.Authenticated = false;
        }
    }

    bool Log(string us, string pas)
    {
        patient = proxy.Login(LoginControl1.UserName, LoginControl1.Password);
        if (patient != null)
        {
            return true;
        }
        else return false;
    }
}