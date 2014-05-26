using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DMS_Service.Structs;
using System.Timers;

namespace DMS_Service
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class CSynchronise : ISynchronise
    {
        /// DbAccessLayer object for saving changes to the database.
        private DbAccessLayer dbManager;
        private Timer timer = new Timer();
        //was the other server offline?
        private bool serverWasOffline;
        //create the sync proxy
        DMS_Service.MySynchroniseService.SynchroniseClient proxy;
       
        
        /// <summary>
        /// Constructor
        /// </summary>
        public CSynchronise()
        {
            this.dbManager = new DbAccessLayer();
            proxy = new MySynchroniseService.SynchroniseClient();
            //other server was offline
            serverWasOffline = false;
            timer.Elapsed += timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            //Interval of Synchronise Timer is 15 mins * 60 seconds * 1000 miliseconds
            timer.Interval =  15 * 60 * 1000;
            timer.Start();
            
        }

        /// <summary>
        /// JP.
        /// Adds new patient from the parameter to the database
        /// </summary>
        public void addPatient(Patient patient)
        {
            this.dbManager.addPatient(patient);
        }

        public void addAppointment(Appointment appointment)
        {
            this.dbManager.addAppointment(appointment);
        }

        public void removePatient()
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

        /// <summary>
        /// Event handler for periodically backup on timer elapse.+
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //create sql dump
            this.backup();
            
            try
            {
                //Check if other server is online
                proxy.ping();
                
                //If it is online (no exception), but it was offline before, then restore backup
                if(serverWasOffline)
                {
                    //restore backup

                    serverWasOffline = false;
                }

            }
            catch
            {
                serverWasOffline = true;
            }
        }
        /// <summary>
        /// Method to send unsynced changes to the other server
        /// </summary>
        /// <returns>true if backup went through</returns>
        private void backup()
        {
            //runs batch file which backs up databases
            System.Diagnostics.Process.Start("..\\..\\backup.bat");
        }


        void ISynchronise.addPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        void ISynchronise.addAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        void ISynchronise.addStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        void ISynchronise.addConsultation(Consultation consult)
        {
            throw new NotImplementedException();
        }

        void ISynchronise.editPatientByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        void ISynchronise.editPatientByAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Just retrns true to check if server is up
        /// </summary>
        /// <returns>always return true</returns>
        public bool ping()
        {
            return true;
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

    /* Old code
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
         */ 
}