using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appointment_Serves
{
    [Serializable]
    public class Patient : Person
    {
        //getter and setter for the patient id
        public int PatientID {get ;  set;}

        //getter and setter for the diagnosis id of the patient
        public int DiagnosisId { get; set; }

        //getter and setter for the consultation id of the patient
        public int ConsultationId { get; set; }

        //getter and setter for the prescription id of the patient
        public int PrescriptionId { get; set; }

        //getter and setter for the height of the patient
        public int Height { get;  set; }

        //getter and setter for the weight of the patient
        public int Weight { get;  set; }

        //getter and setter for the bloodtype of the patient
        public string BloodType { get;  set; }

        //getter and setter for the bool (if the patient smokes or not)
        public bool Smoker { get;  set; }

        //getter and setter for the smoking frequency of the patient
        public int SmokingFrequency { get; set; }

    }
}
