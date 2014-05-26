﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appointment_Serves
{
    [Serializable]
    public class Patient : Person
    {
        public int PatientID {get ;  set;}
        public int DiagnosisId { get; set; }
        public int ConsultationId { get; set; }
        public int PrescriptionId { get; set; }

        public int Height { get;  set; }
        public int Weight { get;  set; }

        //smoker should be a bool, not an int
        //InsuranceNumber was not in the database design, it should be in the table patient. or person table
        //bloodtype should be char not int.
        public string BloodType { get;  set; }
        public bool Smoker { get;  set; }
        public int SmokingFrequency { get; set; }

    }
}
