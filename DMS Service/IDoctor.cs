using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMS_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDoctor
    {
        [OperationContract]
        Patient getPatientOverview(int patientID);

        [OperationContract]
        List<string> getPatientDiseases(int patientID);

        [OperationContract]
        List<Appointment> getPatientAppointments(int patientID);

        [OperationContract]
        List<Perscription> getPatientPerscriptions(int patientID);

        [OperationContract]
        Staff login(string email, string password);

        [OperationContract]
        void logout(string email);

        [OperationContract]
        List<Patient> search(string name, string dateOfBirth, string insuranceNumber);

        [OperationContract]
        string setPerscription(int appointmentID, Perscription perscription);

        // TODO: Add your service operations here
    }


}
