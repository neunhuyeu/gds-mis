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
    public struct Perscription
    {
       
           //why has prescription date? do mean when the medicine is prescribed to the patient? then it needs to be added to the database design also.
       [DataMember]
        private string drug;
       [DataMember]
        private int dosage;
       [DataMember]
        private DateTime date;
       [DataMember]
        private string doctor;

        //I made this getters and setters because, I didn't know if I should change the above to public or not....
        //also changed doctor and drug from int to string
        public string Drug { get { return drug; } set { drug = value; } }
        public int Dosage { get { return dosage; } set { dosage = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
	// Changed something
   }
}
