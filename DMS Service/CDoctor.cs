using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMS_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IDoctor" in both code and config file together.
    public class CDoctor : IDoctor
    {

        public BusinessLayer businessLayer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void getPatient()
        {
            throw new System.NotImplementedException();
        }

        
        public Patient getPatientOverview(int patientID)
        {
            throw new System.NotImplementedException();
        }

        
        public List<string> getPatientDiseases(int patientID)
        {
            throw new System.NotImplementedException();
        }

        
        public List<Appointment> getPatientAppointments(int patientID)
        {
            throw new System.NotImplementedException();
        }

        
        public List<Perscription> getPatientPerscriptions(int patientID)
        {
            throw new System.NotImplementedException();
        }

        
        public Staff login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        
        public void logout(string email)
        {
            throw new System.NotImplementedException();
        }

        
        public List<Patient> search(string name, string dateOfBirth, string insuranceNumber)
        {
            throw new System.NotImplementedException();
        }

        
        public string setPerscription(int appointmentID, Perscription perscription)
        {
            throw new System.NotImplementedException();
        }

        public void registerPatient()
        {
            throw new System.NotImplementedException();
        }
    }
}
