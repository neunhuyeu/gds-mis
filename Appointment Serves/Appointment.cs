using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Appointment_Serves
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Appointment : IAppointment
    {
        private Appointment_database_connection dbAcess;
        public Appointment()
        {
            dbAcess = new Appointment_database_connection("");
        }

    }
}
