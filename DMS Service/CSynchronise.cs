using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMS_Service
{
    public class CSynchronise : ISynchronise
    {
        
        /// <summary>
        /// JP.
        /// DbAccessLayer object for saving changes to the database.
        /// </summary>
        private DbAccessLayer dbManager;

        /// <summary>
        /// JP.
        /// Constructor
        /// </summary>
        public CSynchronise()
        {
            this.dbManager = new DbAccessLayer();
        }


        /// <summary>
        /// JP.
        /// Checks wether the server is alive and responds fast enough.
        /// </summary>
        public bool checkServerStatus()
        {
            return true;
        }

        /// <summary>
        /// Pings a domain and (eventually will..) measures the average response time.
        /// 
        /// </summary>
        /// <param name="domain">The domain to ping, If none is given, the loopback domain is used.</param>
        private void pingDomain(string domain = null)
        {
            // Domain parameter has to be the domain OR the IP of the other server.
            // For now I'll leave the loopback.
            if (domain == null)
                domain = "127.0.0.1";

            Ping pingy = new Ping();
            UserToken token = new UserToken() { Destination = domain, InitiatedTime = DateTime.Now };
            pingy.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
            pingy.SendAsync(domain, token);

        }
        /// <summary>
        /// Callback of the ping function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
        {
            UserToken token = (UserToken)e.UserState;
            Debug.Assert(true, string.Format("Reply from {0} with the status {1}", token.Destination, e.Reply.Status));
        }

        /// <summary>
        /// JP.
        /// Adds new patient from the parameter to the database
        /// </summary>
        public void addPatient(Patient patient)
        {
            this.dbManager.addPatient(patient);
        }

        public void removePatient()
        {
            throw new System.NotImplementedException();
        }

        public void syncAppointments()
        {
            // ???????????
            throw new System.NotImplementedException();
        }

        public void syncAppointment()
        {
            throw new System.NotImplementedException();
        }

        public void addStaff(Staff staff)
        {
            throw new System.NotImplementedException();
        }

        public void removeStaff()
        {
            throw new System.NotImplementedException();
        }

    }

    /// <summary>
    /// Class to help with the ping mechanism.
    /// </summary>
    public class UserToken
    {
        public string Destination { get; set; }
        public DateTime InitiatedTime { get; set; }
    }
}