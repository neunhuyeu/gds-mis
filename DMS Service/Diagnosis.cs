using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DMS_Service
{
    [DataContract]
    public struct Diagnosis
    {

        [DataMember]
        private int diagnosis_id;
        [DataMember]
        private int consultation_id;
        [DataMember]
        private string symptoms;
        [DataMember]
        private string diagnosis;
        public int Diagnosis_id { get { return diagnosis_id; } set { diagnosis_id = value; } }
        public int Consultation_id { get { return consultation_id; } set { consultation_id = value; } }
        public string Symptoms { get { return symptoms; } set { symptoms = value; } }
        public string Diagnosises { get { return diagnosis; } set { diagnosis = value; } }
      
    }
}
