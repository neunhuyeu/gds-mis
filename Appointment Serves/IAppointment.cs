using System;
using System.Collections.Generic;
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
        List<Patient> SearchappointmentsbyDate(DateTime date,int staffId);
        [OperationContract]
        List<Patient> getAppointmnetsOfToday(int staffID);
        [OperationContract]
        List<Appointment> SearchAppointmentsByStaffID(int staffId);
        [OperationContract]
        List<Appointment> getAppointmentsHistorybyPatient(int personId);
    }
}
