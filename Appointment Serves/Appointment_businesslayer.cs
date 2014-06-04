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
