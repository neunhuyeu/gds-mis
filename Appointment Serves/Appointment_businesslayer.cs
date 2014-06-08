using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DMS_Service;
using System.ServiceModel;
using DMS_Service.user_auth;

namespace Appointment_Serves
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Appointment_businesslayer : IAppointment
    {
        private Appointment_database_acess dbAcess;

        //constructor
        public Appointment_businesslayer()
        {
            dbAcess = new Appointment_database_acess();

        }

        /// <summary>
        /// Method for searching appointments by a certain date and staff Id
        /// </summary>
        /// <param name="date">a specific date</param>
        /// <param name="staffId">a specific staff Id</param>
        /// <returns>List of patients with their details that have an appointment on that date with that staff Id </returns>
        public List<Patient> SearchappointmentsbyDate(DateTime date, int staffId)
        {
            List<Patient> mypersons = new List<Patient>();
            DataTable dataTable = dbAcess.SearchAppointmentsbyDate(date, staffId);

            foreach (DataRow row in dataTable.Rows)
            {
                Patient person = new Patient();

                person.FirstName = Convert.ToString(row["first_name"]);
                person.LastName = Convert.ToString(row["last_name"]);
                person.DateOfBirth = Convert.ToDateTime(row["date_of_birth"]);
                person.InsuranceNumber = Convert.ToString(row["insurance_number"]);
                person.PatientID = Convert.ToInt32(row["patient_id"]);

                mypersons.Add(person);
            }
            return mypersons;

        }

        /// <summary>
        /// Method for getting all the appointments of a certain staff
        /// </summary>
        /// <param name="staffId">a specific staff Id</param>
        /// <returns>List of appointments</returns>
        public List<Appointment> SearchAppointmentsByStaffID(int staffId)
        {
            List<Appointment> myappointments = new List<Appointment>();
            DataTable dataTable = dbAcess.SearchAppointmentsByStaffID(staffId);

            foreach (DataRow row in dataTable.Rows)
            {
                Appointment appointment = new Appointment();

                appointment.Start_date = Convert.ToDateTime(row["start_date"]);
                appointment.AppointmentID = Convert.ToInt32(row["appointment_id"]);

                myappointments.Add(appointment);
            }
            return myappointments;
        }

        /// <summary>
        /// Method for getting the appointments of today for a certain staff
        /// </summary>
        /// <param name="staffID">a specific staff Id</param>
        /// <returns>List of patients with their details that have an appointment today with that staff</returns>
        public List<Patient> getAppointmnetsOfToday(int staffID)
        {
            List<Patient> myappointments = new List<Patient>();
            DataTable dataTable = dbAcess.SearchAppointmentsOfToday(staffID);

            foreach (DataRow row in dataTable.Rows)
            {
                Patient appointment = new Patient();

                appointment.FirstName = Convert.ToString(row["first_name"]);
                appointment.LastName = Convert.ToString(row["last_name"]);
                appointment.DateOfBirth = Convert.ToDateTime(row["date_of_birth"]);
                appointment.InsuranceNumber = Convert.ToString(row["insurance_number"]);
                appointment.PatientID = Convert.ToInt32(row["patient_id"]);
                appointment.MobileNumber = Convert.ToString(row["mobile_number"]);

                myappointments.Add(appointment);
            }
            return myappointments;
        }

        Patient IAppointment.Login(string email, string password)
        {
            Patient p = new Patient();
            DataTable dataTable = new DataTable();

            user_auth_business user_auth = new user_auth_business();

            if (user_auth.login(email, password))
            {
                dataTable = dbAcess.SearchPatientByEmail(email);
            }
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    p.FirstName = row["first_name"].ToString();
                    p.LastName = row["last_name"].ToString();
                    p.PersonId = Convert.ToInt32(row["patient_id"]);
                }
                return p;
            }
            return null;
        }

        /// <summary>
        /// Method for getting the appointments history of a certain patient by username
        /// </summary>
        /// <param name="un">a specific username</param>
        /// <returns>a datatable containing the appointments history of a certain patient</returns>
        public DataTable getAppointmentsHistorybyPatient(string un)
        {
            DataTable dataTable = dbAcess.SearchAppointmentsByPatientUsername(un);
            return dataTable;
        }

        /// <summary>
        /// Method for getting the appointments history of a certain patient by id
        /// </summary>
        /// <param name="ID">a specific patient ID</param>
        /// <returns>a datatable containing the appointments history of a certain patient</returns>
        public DataTable getAppointmentsHistorybyPatientID(int ID)
        {
            DataTable dataTable = dbAcess.SearchAppointmentsByPersonID(ID);
            return dataTable;
        }

        /// <summary>
        /// Method for validating an appointment
        /// </summary>
        /// <param name="start_date">a specific start date</param>
        /// <returns>true if the appointment has successfully been validated. or else returns false</returns>
        bool ValidateAppointment(DateTime start_date)
        {
            DataTable dt = dbAcess.GetAppointmentStartDates();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.ItemArray[0].ToString() == start_date.ToString())
                    return false;

            }
            return true;
        }

        /// <summary>
        /// Method for adding an appointment to the database
        /// </summary>
        /// <param name="staffLastName">a specific staff last name</param>
        /// <param name="patientMail">a specific patient email</param>
        /// <param name="startDate">a specific start date</param>
        /// <param name="endDate">a specific end date</param>
        /// <returns>true if the appointment has successfully been added. or else returns false</returns>
        public bool AddAppointment(string staffLastName, string patientMail, string startDate, string endDate)
        {
            DateTime date;
            IFormatProvider culture = new System.Globalization.CultureInfo("en-US", true);
            date = DateTime.Parse(startDate, culture);

            if (ValidateAppointment(date))
            {
                int staffId = dbAcess.GetStaffId(staffLastName);
                int patientId = dbAcess.GetPatientId(patientMail);

                return dbAcess.addAppointmrnt(staffId, patientId, startDate, endDate);
            }
            else
                return false;
        }
    }
}
