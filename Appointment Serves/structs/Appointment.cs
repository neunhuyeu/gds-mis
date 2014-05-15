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
        [DataMember]
        private int appointmentID;
        [DataMember]
        private DateTime start_date;
        [DataMember]
        private DateTime end_date;
        [DataMember]
        private int patient_id;
        [DataMember]
        private int staff_id;



        public int AppointmentID { get { return appointmentID; } set { appointmentID = value; } }
        public DateTime Start_date { get { return start_date; } set { start_date = value; } }
        public DateTime End_date { get { return end_date; } set { end_date = value; } }
        public int Patient_id { get { return patient_id; } set { patient_id = value; } }
        public int Staff_id { get { return staff_id; } set { staff_id = value; } }


    }
}
