using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Appointment_Serves
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAppointment
    {
        [OperationContract]
        Patient Login(string email, string password);
        [OperationContract]
        List<Patient> SearchappointmentsbyDate(DateTime date, int staffId);
        [OperationContract]
        DataTable getAppointmentsHistorybyPatient(string un);
        [OperationContract]
        bool AddAppointment(string staffLastName, string patientMail, string startDate, string endDate);
    }
}
