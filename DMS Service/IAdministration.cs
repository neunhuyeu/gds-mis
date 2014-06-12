using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using DMS_Service.Structs;

namespace DMS_Service
{
    /// <summary>
    /// an interface for the communication with he adminestration client
    /// </summary>
    [ServiceContract]
    public interface IAdministration
    {
        [OperationContract]
        bool addPerson(Person person);
        [OperationContract]
        bool editPerson(Person person);

        [OperationContract]
        bool addPatient(Patient patient);
        [OperationContract]
        bool editPatient(Patient patient);

        [OperationContract]
        bool addStaff(Staff staff);
        [OperationContract]
        bool editStaff(Staff staff);
        [OperationContract]
        bool removeStaff(Staff staff);

        [OperationContract]
        List<Staff> getAllStaff();

        [OperationContract]
        Staff getStaffById(int staffId);
        [OperationContract]
        List<Staff> searchStaff(string fname, string lname, int staffId = -1);

    }
}
