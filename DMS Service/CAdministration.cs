using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS_Service.Structs;

namespace DMS_Service
{
    public class CAdministration : IAdministration
    {
        /// <summary>
        /// The database access layer class.
        /// </summary>
        private DbAccessLayer db;

        /// <summary>
        /// Defines the administration tasks users can perform.
        /// </summary>
        public enum task { select, update, insert, delete };

        /// <summary>
        /// Constructor.
        /// </summary>
        public CAdministration()
        {
            db = new DbAccessLayer();
        }

        /// <summary>
        /// Inserts a new person in the database.
        /// </summary>
        /// <param name="person">The person object to insert.</param>
        /// <returns>True on success | False on failure</returns>
        public bool addPerson(Person person)
        {
         
            return db.personExists(person.FirstName, person.LastName, person.DateOfBirth) ? false : db.addPerson(person);
        }

        /// <summary>
        /// Updates the data of a given person.
        /// </summary>
        /// <param name="person">The person object to update.</param>
        /// <returns>True on success | False on failure</returns>
        public bool editPerson(Person person)
        {
            return db.updatePerson(person);
        }

        /// <summary>
        /// Inserts a new patient in the database.
        /// If the person record for that patient is not yet created, it will be!
        /// muahahaha...
        /// </summary>
        /// <param name="patient">The patient object to insert.</param>
        /// <returns>True on success | False on failure</returns>
        public bool addPatient(Patient patient)
        {
            bool result = false;
            // Check if a person with the same first+last name and d.o.b. exists.
            try
            {
                int id = getpersonId(patient);

                if (id > 0)
                {
                    patient.PersonId = id;
                    result = db.addPatient(patient);
                }
                else
                {
                    result = db.addPerson((Person)patient);
                    patient.PersonId = getpersonId((Person)patient);
                    if (!result || patient.PersonId < 0)
                        throw new Exception("Person id couldn't be retrieved.");
                    result = db.addPatient(patient);
                }
            }
            catch
            { return false; }

            return result;
        }

        /// <summary>
        /// Gets the database id for a given person.
        /// </summary>
        /// <param name="p">The person object to get its id.</param>
        /// <returns>-1 if non existant person. | The id of the person.</returns>
        private int getpersonId(Person p)
        {
            return db.getPersonId(p.FirstName, p.LastName, p.DateOfBirth);
        }

        /// <summary>
        /// Updates the data of a given patient.
        /// </summary>
        /// <param name="patient">The patient object to update.</param>
        /// <returns>True on success | False on failure</returns>
        public bool editPatient(Patient patient)
        {
            return db.updatePatient(patient);
        }

        /// <summary>
        /// Inserts a staff member in the db.
        /// If the person record for this person doesn't exist, it will be created.
        /// </summary>
        /// <param name="staff">The staff object to insert.</param>
        /// <returns>True on success | False on failure</returns>
        public bool addStaff(Staff staff)
        {
            return db.personExists(staff.FirstName, staff.LastName, staff.DateOfBirth) ? false : db.addStaff(staff);
        }

        /// <summary>
        /// Updates the data of a given staff memeber.
        /// </summary>
        /// <param name="staff">The staff object to update.</param>
        /// <returns>True on success | False on failure</returns>
        public bool editStaff(Staff staff)
        {
            return db.updateStaff(staff);
        }

        /// <summary>
        /// Function that removes the given staff record from the db.
        /// The staff member is checked if it's also a patient,
        /// if not it removes the person record as well.
        /// </summary>
        /// <param name="staff">The staff object to delete.</param>
        /// <returns>True on success | False on failure</returns>
        public bool removeStaff(Staff staff)
        {
            if (db.deleteStaff(staff.PersonId, staff.StaffID) > 0)
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// gives all information about all staffmember
        /// </summary>
        /// <returns> a list with the information off all staffmembers</returns>
        public List<Staff> getAllStaff()
        {
            System.Data.DataTable dt = db.getAllStaff();
            List<Staff> staff = new List<Staff>();

            if (dt == null || dt.Rows.Count <= 0)
                return staff;

            foreach (System.Data.DataRow dr in dt.Rows)
            {
                Staff s = new Staff();
                s.StaffID = Convert.ToInt32(dr["Staff_id"]);
                s.Specialization = dr["specialization"].ToString();
                var rn = dr["room_number"];
                try { s.RoomNumber = rn.ToString(); }
                catch { s.RoomNumber = "unassigned"; }
                s.PersonId = Convert.ToInt32(dr["person_id"]);
                s.MobileNumber = dr["mobile_number"].ToString();
                s.LastName = dr["last_name"].ToString();
                s.LandLineNumber = dr["landline_number"].ToString();
                s.InsuranceNumber = dr["insurance_number"].ToString();
                // TODO: Make a function for the function type.
                s.Function = dr["function"].ToString();
                s.FirstName = dr["first_name"].ToString();
                s.Email = dr["email_address"].ToString();
                s.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]);
                s.Address = dr["home_address"].ToString();
                staff.Add(s);
            }
            return staff;
        }

        /// <summary>
        /// Get a Staff object by a given staff id.
        /// </summary>
        /// <param name="staffId">The staff Id</param>
        /// <returns>NULL if non existant, Staff Object</returns>
        public Staff getStaffById(int staffId)
        {
            List<Staff> staff = this.getAllStaff();
            Staff returnable = null;
            try
            {
                int index = staff.FindIndex(member => member.StaffID == staffId);
                returnable = staff[index];
            }
            catch { return null; }
            return returnable;
        }
    }
}
