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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    
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
            timer.Interval = 60 * 1000;
            timer.Start();

        }

        /// <summary>
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
                if (serverWasOffline)
                {
                    byte[] gds_mis = System.IO.File.ReadAllBytes(@"c:\wamp\bin\mysql\mysql5.6.12\bin\mysqldump");
                    byte[] gds_mis_auth = System.IO.File.ReadAllBytes(@"c:\wamp\bin\mysql\mysql5.6.12\bin\mysqldump");
                    byte[] gds_mis_agenda = System.IO.File.ReadAllBytes(@"c:\wamp\bin\mysql\mysql5.6.12\bin\mysqldump");
                    
                    //restore backup, if it is successfull only then mark other server as online
                    if (proxy.setBackup(gds_mis, gds_mis_auth, gds_mis_agenda))
                    {
                        serverWasOffline = false;
                    }
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
        /// <summary>
        /// dummy funktion to satisfy the interface
        /// </summary>
        /// <param name="patient"></param>

        void ISynchronise.addPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dummy funktion to satisfy the interface
        /// </summary>
        /// <param name="appointment"></param>
        void ISynchronise.addAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dummy funktion to satisfy the interface
        /// </summary>
        /// <param name="staff"> saff to be edit</param>
        void ISynchronise.addStaff(Staff staff)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dummy funktion to satisfy the interface
        /// </summary>
        /// <param name="consult">consultation to be edit</param>
        void ISynchronise.addConsultation(Consultation consult)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// dummy funktion to satisfy the interface
        /// </summary>
        /// <param name="patient">patients to be edit</param>
        void ISynchronise.editPatientByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///dummy funktion to satisfy the interface 
        /// </summary>
        /// <param name="appointment"> appointments to be edit </param>
        void ISynchronise.editPatientByAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Receives 3 sql files as aparameters, saves the files, then updates the database
        /// </summary>
        /// <param name="gds_mis">Byte array of the gds_mis database.</param>
        /// <param name="gds_mis_agenda">Byte array of the gds_mis_agenda database.</param>
        /// <param name="gds_mis_auth">Byte array of the gds_mis_agenda database.</param>
        /// <returns>ture= backup sucessfull false= didn't backup</returns>
        public bool setBackup(byte[] gds_mis, byte[] gds_mis_agenda, byte[] gds_mis_auth)
        {
            try
            {
                //Save received scripts into local files
                System.IO.File.WriteAllBytes(@"received_backups\gds_mis.sql", gds_mis);
                System.IO.File.WriteAllBytes(@"received_backups\gds_mis_agenda.sql", gds_mis_agenda);
                System.IO.File.WriteAllBytes(@"received_backups\gds_mis_auth.sql", gds_mis_auth);

                //execute saved scripts
                this.dbManager.executeScript("received_backups\\gds_mis.sql");
                this.dbManager.executeScript("received_backups\\gds_mis_agenda.sql");
                this.dbManager.executeScript("received_backups\\gds_mis_auth.sql");

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Just retrns true to check if server is up
        /// </summary>
        /// <returns>always return true</returns>
        public bool ping()
        {
            return true;
        }

        /// <summary>
        /// read the files to store the database backup and sents them to restore the backup 
        /// </summary>
        /// <returns> ture= backup sucessfull false= didn't backup</returns>
        public bool forcePushBackup()
        {
            byte[] gds_mis = System.IO.File.ReadAllBytes(@"c:\wamp\bin\mysql\backup_gds_mis.sql");
            byte[] gds_mis_auth = System.IO.File.ReadAllBytes(@"c:\wamp\bin\mysql\backup_gds_mis_agenda.sql");
            byte[] gds_mis_agenda = System.IO.File.ReadAllBytes(@"c:\wamp\bin\mysql\backup_gds_mis_auth.sql");
            //restore backup
            return this.setBackup(gds_mis, gds_mis_agenda, gds_mis_auth);
        }

     
    }
}