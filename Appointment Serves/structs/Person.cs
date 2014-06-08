using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Appointment_Serves
{
    [Serializable]
    public abstract class Person
    {
        //getter and setter for the person id
        public int PersonId { get; set; }

        //getter and setter for first name of the person
        public string FirstName { get; set; }

        //getter and setter for the last name of the person
        public string LastName { get; set; }

        //getter and setter for the date of birth of the person
        public DateTime DateOfBirth { get; set; }

        //getter and setter for the email of the person
        public string Email { get; set; }

        //getter and setter for the mobile number of the person
        public string MobileNumber { get; set; }

        //getter and setter for the landline number of the person
        public string LandLineNumber { get; set; }

        //getter and setter for the address of the person
        public string Address { get; set; }

        //getter and setter for the gender of the person
        public char Gender { get; set; }

        //getter and setter for the insurance number of the person
        public string InsuranceNumber { get; set; }


       

    }

}
