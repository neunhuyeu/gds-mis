using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DMS_Service.Structs
{
    /// <summary>
    /// structure to store staff informations
    /// </summary>
    [Serializable]
    public class Staff : Person
    {
        //changed spezialization to string, it was int...
        public int StaffID { get; set; }
        public string Function { get;  set; }
        public string Specialization { get;  set; }
        public string RoomNumber { get;  set; }
        /// <summary>
        /// empty constuctor
        /// </summary>
        public Staff() { }
        /// <summary>
        /// constructor converting a person to a staff member
        /// </summary>
        /// <param name="p"> the person to be converted</param>
        public Staff(Person p)
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
