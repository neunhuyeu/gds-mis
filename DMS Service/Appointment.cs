using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS_Service
{
    public struct Appointment
    {
        public DateTime startTime { get; private set; }
        public DateTime endTime { get; private set; }

        public bool canceled { get; private set; }

        public string notes { get; private set; }
        public List<Perscription> perscriptions { get; private set; }
        public List<String> symptoms { get; private set; }
        public List<String> Diagnosis { get; private set; }
        
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
