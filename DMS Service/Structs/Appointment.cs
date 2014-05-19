using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DMS_Service.Structs
{
    [Serializable]
    public struct Appointment
    {
           
        public DateTime startTime { get; set; }
          
        public DateTime endTime { get;  set; }
           
        public bool canceled { get; set; }
           
        public string notes { get; private set; }
           
        public List<Perscription> perscriptions { get; private set; }
         
        public List<String> symptoms { get; private set; }
           
        public List<String> Diagnosis { get; private set; }
        
        public Patient Patient
        {
            get
            {
                return null;
                //return Patient;
            }
            set
            {
                //Patient = value;
            }
        }
        
        public Staff Staff
        {
            get
            {
                return null;
                //return Staff;
            }
            set
            {
                //Staff = value;
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
