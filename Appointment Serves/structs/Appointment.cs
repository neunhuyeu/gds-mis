using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Appointment_Serves
{
    [Serializable]
    public struct Appointment
    {
        //contains the appointment ID
        [DataMember]
        private int appointmentID;

        //contains the appointment start date
        [DataMember]
        private DateTime start_date;

        //contains the appointment end date
        [DataMember]
        private DateTime end_date;

        //contains the patient id of the appointment
        [DataMember]
        private int patient_id;

        //contains the staff id of the appointment
        [DataMember]
        private int staff_id;


        //getter and setter for the appointment id
        public int AppointmentID { get { return appointmentID; } set { appointmentID = value; } }

        //getter and setter for the appointment start date
        public DateTime Start_date { get { return start_date; } set { start_date = value; } }

        //getter and setter for the appointment end date
        public DateTime End_date { get { return end_date; } set { end_date = value; } }

        //getter and setter for the patient id of the appointment
        public int Patient_id { get { return patient_id; } set { patient_id = value; } }

        //getter and setter for the staff id of the appointment
        public int Staff_id { get { return staff_id; } set { staff_id = value; } }


    }
}
