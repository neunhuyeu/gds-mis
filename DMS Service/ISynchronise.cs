using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DMS_Service.Structs;

namespace DMS_Service
{
    /// <summary>
    /// an interface which specifieces the communication for the syncronisation service 
    /// </summary>
    [ServiceContract]
    public interface ISynchronise
    {
        [OperationContract]
        bool addPatient(Patient patient);

        [OperationContract]
        bool addAppointment(string staffLastName, string patientMail, string startDate, string endDate);

        [OperationContract]
        bool editPatient(Patient patient);

        [OperationContract]
        bool addPrescription(int appointmentId, Perscription per);

        [OperationContract]
        bool ping();

        [OperationContract]
        bool setBackup(byte[] gds_mis, byte[] gds_mis_agenda, byte[] gds_mis_auth);

        //temporary for debugging
        [OperationContract]
        bool forcePushBackup();
    }

}
