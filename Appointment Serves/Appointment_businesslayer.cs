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


        public Appointment_businesslayer()
        {
            dbAcess = new Appointment_database_acess();

        }

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



        //public List<Appointment> getAppointmentsHistorybyPatient(int personId)
        //{
        //    List<Appointment> myappointments = new List<Appointment>();
        //    DataTable dataTable = dbAcess.SearchAppointmentsByPersionID(personId);

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        Appointment appointment = new Appointment();

        //        appointment.Start_date = Convert.ToDateTime(row["start_date"]);
        //        appointment.AppointmentID = Convert.ToInt32(row["appointment_id"]);

        //        myappointments.Add(appointment);
        //    }
        //    return myappointments;
        //}

        // We don't need this function.

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

        public DataTable getAppointmentsHistorybyPatient(string un)
        {
            DataTable dataTable = dbAcess.SearchAppointmentsByPatientUsername(un);
            return dataTable;
        }
    }
}
