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
        public int StaffID { get; private set; }
        public StaffType Function { get; private set; }
        public int Specialization { get; private set; }
        public int RoomNumber { get; private set; }
    }
}
