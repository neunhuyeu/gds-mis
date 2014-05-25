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
            // Check if a person with the same first+last name and d.o.b. exists.
            try
            {
                int id = getpersonId(patient);

                if (id > 0)
                {
                    patient.PersonId = id;
                    db.addPatient(patient);
                }
                else
                {
                    db.addPerson((Person)patient);
                    patient.PersonId = getpersonId((Person)patient);
                    if (!Convert.ToBoolean(patient.PersonId))
                        throw new Exception("Person id couldn't be retrieved.");
                    db.addPatient(patient);
                }
            }
            catch
            { return false; }

            return true;
        }

        /// <summary>
        /// Gets the database id for a given person.
        /// </summary>
        /// <param name="p">The person object to get its id.</param>
        /// <returns>-1 if non existant person. | The id of the person.</returns>
        private int getpersonId(Person p)
        {
            var result = db.getPersonId(p.FirstName, p.LastName, p.DateOfBirth).Rows[0]["id"];
            return (result == null) ? -1 : (int)result;
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
        /// Removes the given staff record from the db.
        /// The person record of that member is not affected.
        /// </summary>
        /// <param name="staff">The staff object to delete.</param>
        /// <returns>True on success | False on failure</returns>
        public bool removeStaff(Staff staff)
        {
            throw new NotImplementedException();
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
    }
}
