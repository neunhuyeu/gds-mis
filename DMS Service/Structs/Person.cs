using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DMS_Service.Structs
{
    /// <summary>
    /// structure to store person informations
    /// </summary>
    [Serializable]
    public abstract class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string LandLineNumber { get; set; }
        public string Address { get; set; }
        public char Gender { get; set; }
        public string InsuranceNumber { get; set; }
        public Person() { }
    }

}
