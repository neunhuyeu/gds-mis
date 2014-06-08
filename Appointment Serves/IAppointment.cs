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
        //method for logging in a user
        [OperationContract]
        Patient Login(string email, string password);

        //method for searching the appointments by a certain date and staff Id
        [OperationContract]
        List<Patient> SearchappointmentsbyDate(DateTime date, int staffId);

        //method for getting the appointments of the day for a certain staff id
        [OperationContract]
        List<Patient> getAppointmnetsOfToday(int staffID);

        //mehod for seaching appointments by staff id
        [OperationContract]
        List<Appointment> SearchAppointmentsByStaffID(int staffId);

        //method for getting the appointments history by patient id
        [OperationContract]
        DataTable getAppointmentsHistorybyPatientID(int ID);

        //method for getting appointments history by patient username
        [OperationContract]
        DataTable getAppointmentsHistorybyPatient(string un);

        /// <summary>
        /// Retrieves all the appointments of a Patient with a given patient ID.
        /// </summary>
        /// <param name="ID">The patient ID to look for appointments</param>
        /// <param name="date">(Optional) If string representation is given, it will limit the appointments in that date.</param>
        /// <returns>A list of patients (Actually an Array)</returns>
        [OperationContract]
        List<Appointment> getAppointmentsListbyPatientId(int ID, string date = "");

        //method for adding an appointment
        [OperationContract]
        bool AddAppointment(string staffLastName, string patientMail, string startDate, string endDate);
    }
}
