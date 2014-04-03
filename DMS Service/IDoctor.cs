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
        Patient GetPatient_by_lastName_DateOfBirth(string lastName, string dateOfBirth);

        [OperationContract]
        Staff Login(string Email, string Passward );


        [OperationContract]
        Patient GetPatientOverview(int personID);

        [OperationContract]
        Staff GetStaff_by_id(int id);

        [OperationContract]
        List<string> GetPatientDiseases(int patientID);

        [OperationContract]
        List<Appointment> getPatientAppointments(int patientID);

        [OperationContract]
        List<Perscription> getPatientPerscriptions(int patientID);

        [OperationContract]
        List<Patient> SearchPatients(string first, string last, string dateOfBirth, int insurance);

        [OperationContract]
        string setPerscription(int appointmentID, Perscription perscription);

        //Methods for testing Synchronization
       // [OperationContract]
       // void addTestPatient();

       
    }
}
