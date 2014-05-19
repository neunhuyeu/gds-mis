using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;
using System.Data;
using DayPilot.Utils;
using DayPilot.Web.Ui;


namespace WebApplication1
{
    public partial class Appointments : Page
    {
        AppointmentClient proxy;
        DataTable appointmentsTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}