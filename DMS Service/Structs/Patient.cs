using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS_Service.Structs
{
    /// <summary>
    /// class holding all information about patients
    /// </summary>
    [Serializable]
    public class Patient : Person
    {
        public int PatientID { get; set; }
        public int DiagnosisId { get; set; }
        public int ConsultationId { get; set; }
        public int PrescriptionId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string BloodType { get; set; }
        public bool Smoker { get; set; }
        public int SmokingFrequency { get; set; }
        public bool hard_drugs { get; set; }
        public int hard_drugs_frequency { get; set; }

        /// <summary>
        /// empty constructor
        /// </summary>
        public Patient() { }
        /// <summary>
        /// constructor converts a person to an patient
        /// </summary>
        /// <param name="p"> person to be converted</param>
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
