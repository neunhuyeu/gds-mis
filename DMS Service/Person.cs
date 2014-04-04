using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DMS_Service
{
    [Serializable]
    public abstract class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string LandLineNumber { get; set; }
        public string Address { get; set; }

        //this is type char in the database...so I changed it from int to char.
        public char Gender { get; set; }

    }

}
