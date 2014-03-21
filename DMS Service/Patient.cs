using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS_Service
{
    [Serializable]
    public class Patient : Person
    {
        public int PatientID {get ; private set;}
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public int BloodType { get; private set; }
        public int Smoker { get; private set; }
        public int InsuranceNumber { get; private set; }

    }
}
