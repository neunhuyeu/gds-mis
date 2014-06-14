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
                    
                    //Add to other server
                    try
                    {
                        DMS_Service.MySynchroniseService.SynchroniseClient proxy;
                        proxy = new DMS_Service.MySynchroniseService.SynchroniseClient();
                        DMS_Service.MySynchroniseService.Patient dude = new DMS_Service.MySynchroniseService.Patient();

                        //convert type
                        dude.FirstNamek__BackingField = patient.FirstName;
                        dude.LastNamek__BackingField = patient.LastName;
                        dude.DateOfBirthk__BackingField = patient.DateOfBirth;
                        dude.Emailk__BackingField = patient.Email;
                        dude.MobileNumberk__BackingField = patient.MobileNumber;
                        dude.LandLineNumberk__BackingField = patient.LandLineNumber;
                        dude.Addressk__BackingField = patient.Address;
                        dude.InsuranceNumberk__BackingField = patient.InsuranceNumber;
                        dude.Genderk__BackingField = patient.Gender;
                        dude.Heightk__BackingField = patient.Height;
                        dude.Weightk__BackingField = patient.Weight;
                        dude.BloodTypek__BackingField = patient.BloodType;
                        dude.Smokerk__BackingField = patient.Smoker;
                        dude.SmokingFrequencyk__BackingField = patient.SmokingFrequency;
                        dude.hard_drugsk__BackingField = patient.hard_drugs;
                        dude.hard_drugs_frequencyk__BackingField = patient.hard_drugs_frequency;
                    
                        proxy.addPatient(dude);
                    }
                    catch
                    {

                    }
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
            if (this.editPerson((Person)patient))
            {
                return db.updatePatient(patient);
            }
            else { return false; }
        }

        /// <summary>
        /// Inserts a staff member in the db.
        /// If the person record for this person doesn't exist, it will be created.
        /// </summary>
        /// <param name="staff">The staff object to insert.</param>
        /// <returns>True on success | False on failure</returns>
        public bool addStaff(Staff staff)
        {
            // Check if a person with the same first+last name and d.o.b. exists.
            bool result = false;
            try
            {
                int id = getpersonId(staff);
                if (id > 0)
                {
                    staff.PersonId = id;
                    result = db.addStaff(staff);
                }
                else
                {
                    result = db.addPerson((Person)staff);
                    staff.PersonId = getpersonId((Person)staff);
                    if (!result || staff.PersonId < 0)
                        throw new Exception("Staff id couldn't be retrieved.");
                    result = db.addStaff(staff);
                }
            }
            catch
            { return false; }

            return result;
        }

        /// <summary>
        /// Updates the data of a given staff memeber.
        /// </summary>
        /// <param name="staff">The staff object to update.</param>
        /// <returns>True on success | False on failure</returns>
        public bool editStaff(Staff staff)
        {
            if (this.editPerson((Person)staff))
            {
                return db.updateStaff(staff);
            }
            else {
                return false;
            }
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
                staff.Add(getStaffFromDataRow(dr));
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

        /// <summary>
        /// Queries the DB for a staff member with a given first name, last name OR staff id.
        /// If a staff id is passed, it will only search for a staff member with the given ID.
        /// </summary>
        /// <param name="fname">First name.</param>
        /// <param name="lname">Last name</param>
        /// <param name="staffId">(Optional)Staff id.</param>
        /// <returns></returns>
        public List<Staff> searchStaff(string fname, string lname, int staffId = -1)
        {
            List<Staff> staff = new List<Staff>();
            System.Data.DataTable dt;
            if (staffId > 0)
            {
                dt = db.searchStaff(fname, lname, staffId);
            }
            else { dt = db.searchStaff(fname, lname); }

            if (dt == null || dt.Rows.Count <= 0)
                return staff;

            foreach (System.Data.DataRow dr in dt.Rows)
            {

                staff.Add(getStaffFromDataRow(dr));
            }
            return staff;
        }

        /// <summary>
        /// Creates a new Staff object from a given DataRow object.
        /// </summary>
        /// <param name="dr">The DataRow object that contains all the person and staff info.</param>
        /// <returns>Staff Object</returns>
        private Staff getStaffFromDataRow(System.Data.DataRow dr)
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
            s.Function = dr["function"].ToString();
            s.FirstName = dr["first_name"].ToString();
            s.Email = dr["email_address"].ToString();
            s.DateOfBirth = Convert.ToDateTime(dr["date_of_birth"]);
            s.Address = dr["home_address"].ToString();
            return s;
        }
    }
}
