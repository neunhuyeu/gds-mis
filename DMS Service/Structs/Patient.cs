using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS_Service.Structs
{
    [Serializable]
    public class Patient : Person
    {
        public int PatientID { get; set; }
        public int DiagnosisId { get; set; }
        public int ConsultationId { get; set; }
        public int PrescriptionId { get; set; }

        public int Height { get; set; }
        public int Weight { get; set; }

        //smoker should be a bool, not an int
        //InsuranceNumber was not in the database design, it should be in the table patient. or person table
        //bloodtype should be char not int.
        public char BloodType { get; set; }
        public bool Smoker { get; set; }
        public int SmokingFrequency { get; set; }
        public bool hard_drugs { get; set; }
        public int hard_drugs_frequency { get; set; }
        public string InsuranceNumber { get; set; }

        public Patient(){ }
        public Patient(Person p)
        {
            base.Address = p.Address;
            base.DateOfBirth = p.DateOfBirth;
            base.Email = p.Email;
            base.FirstName = p.FirstName;
            base.Gender = p.Gender;
            base.InsuranceNumber = p.InsuranceNumber;
            base.LandLineNumber = p.LandLineNumber;
            base.LastName = p.LastName;
            base.MobileNumber = p.MobileNumber;
            base.PersonId = p.PersonId;
        }
    }
}
