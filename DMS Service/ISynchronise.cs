using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DMS_Service.Structs;

namespace DMS_Service
{
    [ServiceContract]
    public interface ISynchronise
    {
        [OperationContract]
        void addPatient(Patient patient);

        [OperationContract]
        void addAppointment(Appointment appointment);

        [OperationContract]
        void addStaff(Staff staff);

        [OperationContract]
        void addConsultation(Consultation consult);

        [OperationContract]
        void editPatientByPatient(Patient patient);

        [OperationContract]
        void editPatientByAppointment(Appointment appointment);

        [OperationContract]
        bool ping();

        [OperationContract]
        bool setBackup(byte[] gds_mis, byte[] gds_mis_agenda, byte[] gds_mis_auth);

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
