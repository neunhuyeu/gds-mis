using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace DMS_Service.Structs
{
    /// <summary>
    /// structure to store prescription informations
    /// </summary>
    [DataContract]
    public struct Perscription
    {

        
        [DataMember]
        private string medicine;
        [DataMember]
        private int amount_pills;
        [DataMember]
        private int amount_ml;
        [DataMember]
        private int strength;
        [DataMember]
        private DateTime date;
        [DataMember]
        private string doctor;
        [DataMember]
        private int doctorId;


        public string Medicine { get { return medicine; } set { medicine = value; } }
        public int Amount_pills { get { return amount_pills; } set { amount_pills = value; } }
        public int Amount_ml { get { return amount_ml; } set { amount_ml = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
        public int DoctorId { get { return doctorId; } set { doctorId = value; } }
        public int Strength { get { return strength; } set { strength = value; } }

 
    }
}
