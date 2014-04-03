using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DMS_Service
{

       [DataContract]
    public struct Appointment
    {
           [DataMember]
        public DateTime startTime { get; set; }
           [DataMember]
        public DateTime endTime { get;  set; }
           [DataMember]
        public bool canceled { get; set; }
           [DataMember]
        public string notes { get; private set; }
           [DataMember]
        public List<Perscription> perscriptions { get; private set; }
          [DataMember]
        public List<String> symptoms { get; private set; }
           [DataMember]
        public List<String> Diagnosis { get; private set; }
        [DataMember]
        public Patient Patient
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
           [DataMember]
        public Staff Staff
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Perscription Perscription
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
