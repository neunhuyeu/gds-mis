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
        void adConsultation(Consultation consult);

        [OperationContract]
        void editPatient(Patient patient);

        [OperationContract]
        void editPatient(Appointment appointment);



       
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "DMS_Service.ContractType".
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
