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
using System.Data;
using System.IO;

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
            timer.Interval = 15 * 60 * 1000;
            timer.Start();

        }

        /// <summary>
        /// Adds new patient from the parameter to the database
        /// </summary>
        public bool addPatient(Patient patient)
        {
            bool result = false;
            // Check if a person with the same first+last name and d.o.b. exists.
            try
            {
                int id = getpersonId(patient);

                if (id > 0)
                {
                    patient.PersonId = id;
                    result = dbManager.addPatient(patient);
                }
                else
                {
                    result = dbManager.addPerson((Person)patient);
                    patient.PersonId = getpersonId((Person)patient);
                    if (!result || patient.PersonId < 0)
                        throw new Exception("Person id couldn't be retrieved.");
                    result = dbManager.addPatient(patient);
                }
            }
            catch
            { return false; }

            return result;
        }

        /// <summary>
        /// Add new appoinment
        /// </summary>
        /// <param name="staffLastName">Doctor's last name</param>
        /// <param name="patientMail">Patient's e-mail</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool addAppointment(string staffLastName, string patientMail, string startDate, string endDate)
        {
            DateTime date;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            date = DateTime.Parse(startDate, culture);

            if (ValidateAppointment(date))
            {
                int staffId = dbManager.GetStaffId(staffLastName);
                int patientId = dbManager.GetPatientId(patientMail);

                return dbManager.addAppointment(staffId, patientId, startDate, endDate);
            }
            else
            {
                return false;
            }
           
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
 

        bool ISynchronise.addPrescription(int appointmentId, Perscription per)
        {
            return dbManager.addPrescrption(per, appointmentId);
        }
       
       
        /// <summary>
        /// dummy funktion to satisfy the interface
        /// </summary>
        /// <param name="patient">patients to be edit</param>
        bool ISynchronise.editPatient(Patient patient)
        {
            return dbManager.updatePatient(patient);
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
                Directory.CreateDirectory("received_backups");
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
            return proxy.setBackup(gds_mis, gds_mis_agenda, gds_mis_auth);
        }

        /// <summary>
        /// Gets the database id for a given person.
        /// </summary>
        /// <param name="p">The person object to get its id.</param>
        /// <returns>-1 if non existant person. | The id of the person.</returns>
        private int getpersonId(Person p)
        {
            return dbManager.getPersonId(p.FirstName, p.LastName, p.DateOfBirth);
        }

        /// <summary>
        /// Method for validating an appointment
        /// </summary>
        /// <param name="start_date">a specific start date</param>
        /// <returns>true if the appointment has successfully been validated. or else returns false</returns>
        bool ValidateAppointment(DateTime start_date)
        {
            DataTable dt = dbManager.GetAppointmentStartDates();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0].ToString() == start_date.ToString())
                    return false;

            }
            return true;
        }
     
    }
}