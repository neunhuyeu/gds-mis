using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS_Service
{
    [Serializable]
    public class Staff : Person
    {
        public Staff()
        {
            return;
        }
        public enum StaffType                                                                  
        {
            physician,
            assistant,
            secretary
        };

        //changed spezialization to string, it was int...
        public int StaffID { get; private set; }
        public StaffType Function { get;  set; }
        public string Specialization { get;  set; }
        public int RoomNumber { get;  set; }
    }
}
