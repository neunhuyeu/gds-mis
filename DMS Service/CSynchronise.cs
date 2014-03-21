using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DMS_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CSynchronise : ISynchronise
    {

        public DbAccessLayer DatabaseManager1
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void checkServerStatus()
        {
            throw new System.NotImplementedException();
        }

        public bool addPatient()
        {
            throw new System.NotImplementedException();
        }

        public void removePatient()
        {
            throw new System.NotImplementedException();
        }

        public void createAppointment()
        {
            throw new System.NotImplementedException();
        }

        public void editAppointment()
        {
            throw new System.NotImplementedException();
        }

        public bool addStaff()
        {
            throw new System.NotImplementedException();
        }

        public void removeStaff()
        {
            throw new System.NotImplementedException();
        }
    }
}
