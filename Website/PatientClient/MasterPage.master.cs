using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public String Username
    {
        get { return (String)ViewState["username"]; }
        set { ViewState["username"] = value; }
    }

    void Page_Init(Object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            Username = "Welcome " + Session["username"];
            loggedIn.Visible = true;
            loggedOff.Visible = false;
        }
        //else
        //{
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            patientName.Text = Username;
            patientName.Visible = true;
            if (Username != null)
            {
                hyperlinkLogIn.Visible = false;
                ButtonLogOff.Visible = true;
            }
            else
            {
                hyperlinkLogIn.Visible = true;
            }
        }
        //else
        //{
        //    patientName.Text = "";
        //    patientName.Visible = false;
        //}
    }


    protected void ButtonLogOff_Click(object sender, EventArgs e)
    {
        hyperlinkLogIn.Visible = true;
        ButtonLogOff.Visible = false;
        Session["username"] = null;
        Username = " ";
        Response.Redirect("~/Home.aspx");
    }


}