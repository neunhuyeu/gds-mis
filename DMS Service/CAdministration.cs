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
            // TODO: Add better handling if database fails to insert.
            return db.personExists(person) ? false : db.addPerson(person);
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
        /// Removes a given person from the database,
        /// only if there are no patient records.
        /// </summary>
        /// <param name="person">The person object to delete.</param>
        /// <param name="completely">If true it will also delete existing patient of staff member records.</param>
        /// <returns>True on success | False on failure</returns>
        public bool removePerson(Person person, bool completely = false)
        {
            throw new NotImplementedException();
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
        /// Removes the data for a given patient.
        /// The person record is not affected.
        /// </summary>
        /// <param name="patient">The patient object to delete.</param>
        /// <returns>True on success | False on failure</returns>
        public bool removePatient(Patient patient)
        {
            throw new NotImplementedException();
            //return db.deletePatient(patient.PatientID);
        }

        /// <summary>
        /// Inserts a staff member in the db.
        /// If the person record for this person doesn't exist, it will be created.
        /// </summary>
        /// <param name="staff">The staff object to insert.</param>
        /// <returns>True on success | False on failure</returns>
        public bool addStaff(Staff staff)
        {
            return db.personExists(staff) ? false : db.addStaff(staff);
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
        /// Not Implemented yet. (Everyone has permissions)
        /// Checks whether a given id (patient, staff, person) can manage specific tasks.
        /// </summary>
        /// <param name="id">The users id, as is stored in the database.</param>
        /// <param name="t">The task the user is trying to perform.</param>
        /// <returns></returns>
        public bool hasPermissions(int id, task t = task.select)
        {
            // Go to the db, fetch the permissions for that id and test
            // them against the task (t) the user wants to perform.
            return true;
        }

        public List<Staff> getStaff()
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
    }
}
