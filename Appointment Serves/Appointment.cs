using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.ServiceModel;


namespace Appointment_Serves
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Appointment : IAppointment
    {
        private Appointment_database_acess dbAcess;
        int staffId;
        public Appointment()
        {
            dbAcess = new Appointment_database_acess();
            
        }

        public List<Patient> SearchappointmentsbyDate(DateTime date ,int staffId)
        { 
       
           List<Patient> mypersons = new List<Patient>();
           DataTable dataTable = dbAcess.SearchConsultationsbyDate(date, staffId);

           foreach (DataRow row in dataTable.Rows)
           {
               Patient person = new Patient();

               person.PersonId = Convert.ToInt32(row["person_id"]);
               person.FirstName = Convert.ToString(row["first_name"]);
               person.LastName = Convert.ToString(row["last_name"]);
               person.DateOfBirth = Convert.ToDateTime(row["date_of_birth"]);
              
               mypersons.Add(person);
           }
           return mypersons;
       
        }
    }
}
