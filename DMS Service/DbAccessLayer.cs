using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using DMS_Service.database_connection;
using DMS_Service.Structs;
using System.IO;

namespace DMS_Service
{
    /// <summary>
    ///  a class containing functions to generate sql statements
    /// </summary>
    public class DbAccessLayer
    {
        private db_connection dbConnection;

        public DbAccessLayer()
        {
            dbConnection = new db_connection("gds_mis");
        }
        /// <summary>
        /// finds informantions about persons containing parts of the Last name and date of birth, 
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns> all informations about persons which containspart of the passed lastname and date of birth  </returns>
        public DataTable SearchPatient_lastName_dateOfBirth(string lastName, string dateOfBirth)
        {
            string query = string.Format("SELECT * " +
                                        "FROM person " +
                                        "WHERE last_name = @lastName " +
                                        "AND date_of_birth = @dateOfBirth");
            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@lastName", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(lastName);
            sqlParameters[1] = new MySqlParameter("@dateOfBirth", MySqlDbType.Date);
            sqlParameters[1].Value = Convert.ToString(dateOfBirth);
            return dbConnection.SelectQuery(query, sqlParameters);
        }
        /// <summary>
        /// these funktion returns all personal information about person of a specified id
        /// </summary>
        /// <param name="id"> the id identifying the person</param>
        /// <returns>all the information about the person</returns>
        public DataTable SearchPatientById(int id)
        {
            string query = string.Format("SELECT * " +
                                          "FROM patients " +
                                          "Where person_id = @id");
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            sqlParameters[0].Value = id.ToString();
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// these funktion is the query for the search functions and finds all people how could 
        /// be related with the parameters
        /// </summary>
        /// <param name="firstName">contains the first name or parts of the first name to search in the database</param>
        /// <param name="lastName">contains the last name or parts of the last name to search in the database</param>
        /// <param name="dateOfBirth">contains the date of birth  or parts of the date of birth to search in the database<</param>
        /// <param name="insurance">contains the insurance number or parts of the insurance number to search in the database<</param>
        /// <returns> returns all people and there data which could be ment with the search parameters</returns>
        public DataTable SearchPatientsList(string firstName, string lastName, DateTime dateOfBirth, string insurance)
        {
            string parameters = "";
            string query = "Select * from patients pt join person per on per.person_id = pt.person_id ";
            if (firstName.Length > 0 || lastName.Length > 0 || dateOfBirth.GetDateTimeFormats('d')[0] != DateTime.Now.GetDateTimeFormats('d')[0] || (insurance.Length > 0 && insurance != "0"))
            {
                query += " WHERE";
                if (firstName.Length > 0)
                {
                    query += " per.first_name like @firstName";
                    parameters += "f";
                }
                if (lastName.Length > 0)
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " per.last_name like @lastName";
                    parameters += "l";
                }
                if (dateOfBirth.GetDateTimeFormats('d')[0] != DateTime.Now.GetDateTimeFormats('d')[0])
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " per.date_of_birth = @date";
                    parameters += "d";
                }
                if (insurance.Length > 0 && insurance != "0")
                {
                    if (!parameters.Equals("")) query += " AND";
                    query += " per.insurance_number like @insurance";
                    parameters += "i";
                }
            }

            MySqlParameter[] sqlParameters = null;
            if (parameters.Length > 0)
            {
                int index = 0;

                sqlParameters = new MySqlParameter[parameters.Length];
                parameters = parameters.PadRight(4, '#');

                if (parameters[index] == 'f')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@firstName", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + firstName + "%");
                }
                if (parameters[index] == 'l')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@lastName", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + lastName + "%");
                }
                if (parameters[index] == 'd')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@date", MySqlDbType.DateTime);
                    sqlParameters[index - 1].Value = Convert.ToDateTime(dateOfBirth);
                }
                if (parameters[index] == 'i')
                {
                    index++;
                    sqlParameters[index - 1] = new MySqlParameter("@insurance", MySqlDbType.VarChar);
                    sqlParameters[index - 1].Value = Convert.ToString("%" + insurance + "%");
                }
                query = string.Format(query);

                return dbConnection.SelectQuery(query, sqlParameters);
            }
            return dbConnection.SelectQuery(query);
        }
        /// <summary>
        /// displayes all information about a prescription regarding a prescription id
        /// </summary>
        /// <param name="id"> the prescription id of prescription to be searched</param>
        /// <returns>all information about a prescription</returns>
        public DataTable SearchprescriptionListByID(int id)
        {
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@pt_id", MySqlDbType.Int32);
            sqlParameters[0].Value = id;
            string query = string.Format("SELECT con.Staff_id, pre.medicine, pre.strength_mg, con.end_date as date_prescribed " +
                                         "FROM prescribtion pre " +
                                         "JOIN consultations con " +
                                         "ON pre.consultation_id = con.consultation_id " +
                                         "WHERE con.patient_id = (select patient_id from patients where person_id = @pt_id)");
            return dbConnection.SelectQuery(query, sqlParameters);
        }
        /// <summary>
        /// returns all information about every employee
        /// </summary>
        /// <returns>all information about every employee </returns>
        public DataTable getAllStaff()
        {
            string query = "SELECT * FROM Staff_members sm join person per on per.person_id = sm.person_id ";
            return dbConnection.SelectQuery(query);
        }
        /// <summary>
        /// gets all information about a stuffmenber of a specific id
        /// </summary>
        /// <param name="id">the person identifcation number of the staff to look for</param>
        /// <returns>the stored information about the stuff</returns>
        public DataTable SearchStaffByPersonId(int id)
        {
            string query = "SELECT * FROM Staff_members WHERE person_id = @id";
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(id);
            return dbConnection.SelectQuery(query, sqlParameters);
        }
        /// <summary>
        /// gets all information about a stuffmenber of a specific id
        /// </summary>
        /// <param name="id">the staff identifcation number of the staff to look for</param>
        /// <returns>the stored information about the staff member</returns>
        public DataTable SearchStaffByStaffId(int id)
        {
            string query = "SELECT * " +
                          " FROM person " +
                          " WHERE person_id = (select person_id from Staff_members where Staff_id = @Staff_id)";
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@Staff_id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(id);
            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// gets all information about a stuffmenber with a specific e-mail
        /// </summary>
        /// <param name="e-mail">the E-mail address of the staff to look for</param>
        /// <returns>the stored information about the staff member</returns>
        public DataTable SearchStaffByEmail(string email)
        {
            try
            {
                string query = "SELECT * " +
                                "FROM person per " +
                                "JOIN staff_members staf " +
                                "ON per.person_id = staf.person_id " +
                                "WHERE email_address = @email";
                MySqlParameter[] sqlParameters = new MySqlParameter[1];
                sqlParameters[0] = new MySqlParameter("@email", MySqlDbType.String);
                sqlParameters[0].Value = Convert.ToString(email);
                return dbConnection.SelectQuery(query, sqlParameters);
            }
            catch
            { return null; }
        }

        /// <summary>
        /// gets the person id of of a person with a specified name and date of birth
        /// </summary>
        /// <param name="firstName">the first name of the person to find the person if from</param>
        /// <param name="lastName">the Last name of the person to find the person if from</param>
        /// <param name="dob">the date of birth of the person to find the person if from</param>
        /// <returns></returns>
        public int getPersonId(string firstName, string lastName, DateTime dob)
        {
            string query = "SELECT person_id as id FROM person where first_name = ?fname AND last_name = ?lname AND date_of_birth = ?dob";
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?fname", MySqlDbType.VarChar);
            sqlParameters[0].Value = firstName;
            sqlParameters[1] = new MySqlParameter("?lname", MySqlDbType.VarChar);
            sqlParameters[1].Value = lastName;
            sqlParameters[2] = new MySqlParameter("?dob", MySqlDbType.Date);
            sqlParameters[2].Value = dob;
            DataTable result;
            try
            {
                result = dbConnection.SelectQuery(query, sqlParameters);
                if (result.Rows.Count == 0)
                {
                    throw new Exception("No id was found");
                }
            }
            catch
            { return -1; }
            return Convert.ToInt32(result.Rows[0]["id"]);
        }

        /// <summary>
        /// converts person id to patient id
        /// </summary>
        /// <param name="patientId">patientid to be converted to personid</param>
        /// <returns> person id of the target person</returns>
        public int getPersonIdFromPatientId(int patientId)
        {
            string query = "SELECT person_id as id FROM patients where patient_id=?patient_id";
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?patient_id", MySqlDbType.VarChar);
            sqlParameters[0].Value = patientId;
            DataTable result;
            try
            {
                result = dbConnection.SelectQuery(query, sqlParameters);
                if (result.Rows.Count == 0)
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            { return -1; }
            return Convert.ToInt32(result.Rows[0]["person_id"]);
        }

        /// <summary>
        /// gets the related person id of a staff id
        /// </summary>
        /// <param name="staffId"> Staff id</param>
        /// <returns> Person id</returns>
        public int getPersonIdFromStaffId(int staffId)
        {
            string query = "SELECT person_id as id FROM Staff_members where Staff_id=?Staff_id";
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?Staff_id", MySqlDbType.VarChar);
            sqlParameters[0].Value = staffId;
            DataTable result;
            try
            {
                result = dbConnection.SelectQuery(query, sqlParameters);
                if (result.Rows.Count == 0)
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            { return -1; }
            return Convert.ToInt32(result.Rows[0]["person_id"]);
        }

        /// <summary>
        /// converts personid to staff id
        /// </summary>
        /// <param name="personId">person id to be converted</param>
        /// <returns>Staff id of the specified person id</returns>
        public int getStaffIdFromPersonId(int personId)
        {
            string query = "SELECT Staff_id as id FROM Staff_members where person_id=?person_id";
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?person_id", MySqlDbType.VarChar);
            sqlParameters[0].Value = personId;
            DataTable result;
            try
            {
                result = dbConnection.SelectQuery(query, sqlParameters);
                if (result.Rows.Count == 0)
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            { return -1; }
            return Convert.ToInt32(result.Rows[0]["Staff_id"]);
        }

        /// <summary>
        /// converts PatientID to person id
        /// </summary>
        /// <param name="personId"> person id to find the patient id from</param>
        /// <returns>returns the patient id of the related patient id</returns>
        public int getPatientIdFromPersonId(int personId)
        {
            string query = "SELECT patient_id as id FROM patients where person_id=?person_id";
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?person_id", MySqlDbType.VarChar);
            sqlParameters[0].Value = personId;
            DataTable result;
            try
            {
                result = dbConnection.SelectQuery(query, sqlParameters);
                if (result.Rows.Count == 0)
                {
                    throw new DirectoryNotFoundException();
                }
            }
            catch
            { return -1; }
            return Convert.ToInt32(result.Rows[0]["patient_id"]);
        }

        /// <summary>
        /// Check whether a person with the given name, lastname and date of birth is stored in the database.
        /// </summary>
        /// <param name="person">A Person object</param>
        /// <returns>ture = person exists in the database, false= person doesn't exist in the database </returns>
        public bool personExists(string fname, string lname, DateTime dob)
        {
            string query = "SELECT COUNT(*) as count FROM person where first_name=?first_name AND last_name=?last_name AND date_of_birth=?date_of_birth";
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?first_name", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(fname);
            sqlParameters[1] = new MySqlParameter("?last_name", MySqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(lname);
            sqlParameters[2] = new MySqlParameter("?date_of_birth", MySqlDbType.Date);
            sqlParameters[2].Value = dob;

            bool result = false;
            try
            {
                // Execute query on person table.
                result = (bool)dbConnection.SelectQuery(query, sqlParameters).Rows[0]["count"];
            }
            catch
            { result = false; }

            return result;
        }

        /// <summary>
        /// generates the array of all sql parameters needed for dealing with personal data in a database
        /// </summary>
        /// <param name="person"> the person to input into the database</param>
        /// <returns> generates the array of all sql parameters needed for dealing with personal data in a database</returns>
        private MySqlParameter[] getPersonParams(ref Person person)
        {
            // Parameters for person table.
            MySqlParameter[] sqlParameters = new MySqlParameter[9];
            sqlParameters[0] = new MySqlParameter("?first_name", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(person.FirstName);
            sqlParameters[1] = new MySqlParameter("?last_name", MySqlDbType.VarChar);
            sqlParameters[1].Value = Convert.ToString(person.LastName);
            sqlParameters[2] = new MySqlParameter("?date_of_birth", MySqlDbType.Date);
            sqlParameters[2].Value = (person.DateOfBirth);
            sqlParameters[3] = new MySqlParameter("?email_address", MySqlDbType.VarChar);
            sqlParameters[3].Value = Convert.ToString(person.Email);
            sqlParameters[4] = new MySqlParameter("?mobile_number", MySqlDbType.VarChar);
            sqlParameters[4].Value = Convert.ToString(person.MobileNumber);
            sqlParameters[5] = new MySqlParameter("?landline_number", MySqlDbType.VarChar);
            sqlParameters[5].Value = Convert.ToString(person.LandLineNumber);
            sqlParameters[6] = new MySqlParameter("?home_address", MySqlDbType.VarChar);
            sqlParameters[6].Value = Convert.ToString(person.Address);
            sqlParameters[7] = new MySqlParameter("?insurance_number", MySqlDbType.VarChar);
            sqlParameters[7].Value = Convert.ToString(person.InsuranceNumber);
            sqlParameters[8] = new MySqlParameter("?person_id", MySqlDbType.Int32);
            sqlParameters[8].Value = Convert.ToInt32(person.PersonId);

            return sqlParameters;
        }
        /// <summary>
        /// findes the next person id which will get generated
        /// </summary>
        /// <returns> returns the highest personit plus one</returns>
        private int newPersonId()
        {
            string query = "SELECT MAX(`person_id`)+1 as new FROM person";
            int result;
            try
            {
                // Execute query on person table.
                result = Convert.ToInt32(dbConnection.SelectQuery(query).Rows[0]["new"]);
            }
            catch { return -1; }
            return result;
        }
        /// <summary>
        /// these funkion adds a person to the database
        /// </summary>
        /// <param name="person"> all the information to be added to the database</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool addPerson(Person person)
        {
            bool result = false;
            // Query for person table.
            string query = "INSERT INTO person " +
                           "(`person_id`, `first_name`, `last_name`, `date_of_birth`, `email_address`, `mobile_number`, `landline_number`, `home_address`, `insurance_number`) " +
                           "VALUES (?person_id, ?first_name, ?last_name, ?date_of_birth, ?email_address, ?mobile_number, ?landline_number, ?home_address, ?insurance_number)";

            MySqlParameter[] sqlParameters;

            try
            {
                int pid = this.newPersonId();
                if (pid < 0)
                {
                    throw new Exception("Couldn't get new Id");
                }
                else
                {
                    person.PersonId = pid;
                    sqlParameters = getPersonParams(ref person);
                }
                // Execute query on person table.
                result = dbConnection.InsertQuery(query, sqlParameters);
            }
            catch { return false; }
            return result;
        }

        /// <summary>
        /// updates the information about a person
        /// </summary>
        /// <param name="person"> the class containing all new infromationa bout a person</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>
        public bool updatePerson(Person person)
        {
            bool result = false;
            string query = "UPDATE  person " +
                            "SET first_name=?first_name, last_name=?last_name, date_of_birth=?date_of_birth, " +
                                "email_address=?email_address, mobile_number=?mobile_number, landline_number=?landline_number, " +
                                "home_address=?home_address, insurance_number=?insurance_number " +
                            "WHERE person_id=?person_id";

            MySqlParameter[] sqlParameters = getPersonParams(ref person);

            try
            {
                result = dbConnection.UpdateQuery(query, sqlParameters);
            }
            catch { return false; }
            return result;
        }

        /// <summary>
        /// function to genrate a parameter array for an sql stament regarding a patient
        /// </summary>
        /// <param name="patient">class which contains all information about a patient</param>
        /// <returns> an array with all parameters</returns>
        private MySqlParameter[] getPatientParams(ref Patient patient)
        {
            // Parameters for patient table.
            MySqlParameter[] sqlParameters = new MySqlParameter[10];
            sqlParameters[0] = new MySqlParameter("?gender", MySqlDbType.VarChar);
            sqlParameters[0].Value = patient.Gender;
            sqlParameters[1] = new MySqlParameter("?height_cm", MySqlDbType.Int32);
            sqlParameters[1].Value = patient.Height;
            sqlParameters[2] = new MySqlParameter("?weight_kg", MySqlDbType.Int32);
            sqlParameters[2].Value = patient.Weight;
            sqlParameters[3] = new MySqlParameter("?blood_type", MySqlDbType.VarChar);
            sqlParameters[3].Value = patient.BloodType;
            sqlParameters[4] = new MySqlParameter("?smoking", MySqlDbType.Bit);
            sqlParameters[4].Value = patient.Smoker;
            sqlParameters[5] = new MySqlParameter("?smoking_frequency", MySqlDbType.Int32);
            sqlParameters[5].Value = patient.SmokingFrequency;
            sqlParameters[6] = new MySqlParameter("?hard_drugs", MySqlDbType.Bit);
            sqlParameters[6].Value = patient.hard_drugs;
            sqlParameters[7] = new MySqlParameter("?hard_drugs_frequency", MySqlDbType.Int32);
            sqlParameters[7].Value = patient.hard_drugs_frequency;
            sqlParameters[8] = new MySqlParameter("?person_id", MySqlDbType.Int32);
            sqlParameters[8].Value = patient.PersonId;
            sqlParameters[9] = new MySqlParameter("?patient_id", MySqlDbType.Int32);
            sqlParameters[9].Value = patient.PatientID;

            return sqlParameters;
        }

        /// <summary>
        /// gets the next  paient id to be genrated 
        /// </summary>
        /// <returns> gets the next generated paient id </returns>
        private int newPatientId()
        {
            string query = "SELECT MAX(`patient_id`)+1 as new FROM patients";
            int result;
            try
            {
                // Execute query on person table.
                result = Convert.ToInt32(dbConnection.SelectQuery(query).Rows[0]["new"]);
            }
            catch { return -1; }
            return result;
        }

        /// <summary>
        /// Adds a patient record after it checks if the person record already exists.
        /// If not it creates a person record first and then proceeds.
        /// </summary>
        /// <param name="patient">The patient object to add.</param>
        ///<return> true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool addPatient(Patient patient)
        {
            bool result = false;
            //query for patient table
            string query = "INSERT INTO patients(patient_id, gender, height_cm, weight_kg, blood_type, smoking, smoking_frequency, hard_drugs, hard_drugs_frequency, person_id)" +
                    "VALUES (?patient_id, ?gender, ?height_cm, ?weight_kg, ?blood_type, ?smoking, ?smoking_frequency, ?hard_drugs, ?hard_drugs_frequency, ?person_id)";


            //parameters for patient table
            MySqlParameter[] sqlParameters;
            try
            {
                int pid = this.newPatientId();
                if (pid < 0)
                {
                    throw new Exception("Couldn't get new Id");
                }
                else
                {
                    patient.PatientID = pid;
                    sqlParameters = getPatientParams(ref patient);
                }
                // Execute query on person table.
                result = dbConnection.InsertQuery(query, sqlParameters);
            }
            catch { return false; }
            return result;
        }

        /// <summary>
        /// function to update patients in the database
        /// </summary>
        /// <param name="p">the patient information to replace the old with</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool updatePatient(Patient p)
        {
            bool result = false;
            string query = "UPDATE patients" +
                            " SET gender=?gender, height_cm=?height_cm, weight_kg=?weight_kg, blood_type=?blood_type, smoking=?smoking, smoking_frequency=?smoking_frequency, hard_drugs=?hard_drugs, hard_drugs_frequency=?hard_drugs_frequency, person_id=?person_id" +
                            " WHERE patient_id=?patient_id";
            MySqlParameter[] sqlParameters = getPatientParams(ref p);

            try
            {
                result = dbConnection.UpdateQuery(query, sqlParameters);
            }
            catch { return false; }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        private MySqlParameter[] getStaffParams(ref Staff staff)
        {
            // Parameters for Staff_members table.
            MySqlParameter[] sqlParameters = new MySqlParameter[5];
            sqlParameters[0] = new MySqlParameter("?function", MySqlDbType.VarChar);
            sqlParameters[0].Value = staff.Function;
            sqlParameters[1] = new MySqlParameter("?specialization", MySqlDbType.VarChar);
            sqlParameters[1].Value = staff.Specialization;
            sqlParameters[2] = new MySqlParameter("?room_number", MySqlDbType.VarChar);
            sqlParameters[2].Value = Convert.ToString(staff.RoomNumber);
            sqlParameters[3] = new MySqlParameter("?person_id", MySqlDbType.Int32);
            sqlParameters[3].Value = Convert.ToInt32(staff.PersonId);
            sqlParameters[4] = new MySqlParameter("?Staff_id", MySqlDbType.Int32);
            sqlParameters[4].Value = Convert.ToInt32(staff.StaffID);

            return sqlParameters;
        }
        /// <summary>
        /// gets the next staff id to be generated
        /// </summary>
        /// <returns>the next staff id to be generated</returns>
        private int newStaffId()
        {
            string query = "SELECT MAX(`Staff_id`)+1 as new FROM Staff_members;";
            int result;
            try
            {
                // Execute query on person table.
                result = Convert.ToInt32(dbConnection.SelectQuery(query).Rows[0]["new"]);
            }
            catch { return -1; }
            return result;
        }
        /// <summary>
        /// creates a new stuff member in the database
        /// </summary>
        /// <param name="staff"> contains all the information about the to beadded staffmember</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool addStaff(Staff staff)
        {
            bool result = false;
            //query for patient table
            string query = "INSERT INTO Staff_members (Staff_id,function,specialization,room_number,person_id)" +
                    "VALUES (?Staff_id, ?function, ?specialization, ?room_number, ?person_id)";
            //parameters for patient table
            MySqlParameter[] sqlParameters;
            try
            {
                int sid = this.newStaffId();
                if (sid < 0)
                {
                    throw new Exception("Couldn't get new Id");
                }
                else
                {
                    staff.StaffID = sid;
                    sqlParameters = getStaffParams(ref staff);
                }
                // Execute query on person table.
                result = dbConnection.InsertQuery(query, sqlParameters);
            }
            catch { return false; }
            return result;

        }

        /// <summary>
        /// replaces the old staff information with new once
        /// </summary>
        /// <param name="staff"> holds the new staff informations</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool updateStaff(Staff staff)
        {
            bool result = false;
            string query = @"UPDATE Staff_members
                            SET `function`=?function,`specialization`=?specialization,`room_number`=?room_number
                            WHERE `Staff_id`=?Staff_id";
            MySqlParameter[] sqlParameters = getStaffParams(ref staff);

            try
            {
                result = dbConnection.UpdateQuery(query, sqlParameters);
            }
            catch { return false; }
            return result;
        }

        /// <summary>
        /// creates a new diagnisis in the database
        /// </summary>
        /// <param name="Diagnosis"> object holding all information about the new diagnosis</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool addDiagnosis(Diagnosis Diagnosis)
        {
            //query
            string query = "INSERT INTO prescribtion(diagnosis, consultation_id, symptoms) " +
                           "VALUES (@diagnosis, @consultation_id, @symptoms) ";

            //parameters
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("@diagnosis", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(Diagnosis.Diagnosises);
            sqlParameters[1] = new MySqlParameter("@consultation_id", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(Diagnosis.Consultation_id);
            sqlParameters[2] = new MySqlParameter("@symptoms", MySqlDbType.Int32);
            sqlParameters[2].Value = Convert.ToString(Diagnosis.Symptoms);

            try
            {
                //execute query on appointment table
                dbConnection.InsertQuery(query, sqlParameters);
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Adds consultation to the conusltation table.
        /// </summary>
        /// <param name="appointment">appointment to be added</param>
        public void addAppointment(Appointment appointment)
        {
            //query
            string query = "INSERT INTO consultations(start_date, end_date, patient_id, staff_id)" +
                           "VALUES (?start_date, ?end_date, ?patient_id, ?staff_id)";

            //parameters
            MySqlParameter[] sqlParameters = new MySqlParameter[4];
            sqlParameters[0] = new MySqlParameter("?start_date", MySqlDbType.DateTime);
            sqlParameters[0].Value = appointment.startTime;
            sqlParameters[1] = new MySqlParameter("?end_date", MySqlDbType.DateTime);
            sqlParameters[1].Value = appointment.endTime;
            sqlParameters[2] = new MySqlParameter("?patient_id", MySqlDbType.Int32);

            sqlParameters[2].Value = 1;
            sqlParameters[3] = new MySqlParameter("?staff_id", MySqlDbType.Int32);
            sqlParameters[3].Value = 1;

            //execute query on appointment table
            dbConnection.InsertQuery(query, sqlParameters);
        }

        /// <summary>
        /// prescription to be added
        /// </summary>
        /// <param name="perscription"> the perscription information of the to be added prescripion</param>
        /// <param name="consultationId">the consultationid of the time when the prescription were prescriped </param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool addPrescrption(Perscription perscription, int consultationId)
        {
            //query
            string query = "INSERT INTO prescribtion(medicine, amount_pills, ammount_ml,consultation_id,strength_mg)" +
                           "VALUES (@medicine, @amount_pills, @amount_ml,@consultation_id,@strength_mg)";

            //parameters
            MySqlParameter[] sqlParameters = new MySqlParameter[5];
            sqlParameters[0] = new MySqlParameter("@medicine", MySqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(perscription.Medicine);
            sqlParameters[1] = new MySqlParameter("@amount_pills", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(perscription.Amount_pills);
            sqlParameters[2] = new MySqlParameter("@amount_ml", MySqlDbType.Int32);
            sqlParameters[2].Value = Convert.ToString(perscription.Amount_ml);
            sqlParameters[3] = new MySqlParameter("@consultation_id", MySqlDbType.Int32);
            sqlParameters[3].Value = Convert.ToString(consultationId);
            sqlParameters[4] = new MySqlParameter("@strength_mg", MySqlDbType.Int32);
            sqlParameters[4].Value = Convert.ToString(perscription.Strength);

            try
            {
                //execute query on appointment table
                dbConnection.InsertQuery(query, sqlParameters);
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// gets the next to be generated consultationid
        /// </summary>
        /// <returns> the next to be generated consultationid </returns>
        public DataTable getLatestConsultationID()
        {
            try
            {
                string query = "SELECT MAX(consultation_id) As latest FROM consultations;";
                return dbConnection.SelectQuery(query);
            }
            catch
            { return null; }
        }

        /// <summary>
        ///  updates consultaion to add an end date
        /// </summary>
        /// <param name="currentConultion">the object holding all information about the current consultation</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>

        public bool updateConsultionEnd_date(Consultation currentConultion)
        {
            //query
            string query = "Update  consultations" +
                            "SET end_date =@end_date" +
                            "WHERE consultation_id = @consultation_id";

            //parameters
            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@end_date", MySqlDbType.Date);
            sqlParameters[0].Value = Convert.ToString(currentConultion.End_date);
            sqlParameters[1] = new MySqlParameter("@consultation_id", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(currentConultion.ConsultationID);

            try
            {
                //execute query on appointment table
                dbConnection.InsertQuery(query, sqlParameters);
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// adds a consultation to the database
        /// </summary>
        /// <param name="Consultation"> a class containg all information about the consultations</param>
        /// <returns>true= the sql statement was executed , false = the sql statement was not propper executed </returns>
        public bool addConsultion(Consultation Consultation)
        {
            //query
            string query = "INSERT INTO consultations( start_date, Staff_id, patient_id)" +
                           "VALUES ( @start_date, @Staff_id, @patient_id)";

            //parameters
            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("@start_date", MySqlDbType.Date);
            sqlParameters[0].Value = Convert.ToString(Consultation.Start_date);
            sqlParameters[1] = new MySqlParameter("@Staff_id", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(Consultation.Staff_id);
            sqlParameters[2] = new MySqlParameter("@patient_id", MySqlDbType.Int32);
            sqlParameters[2].Value = Convert.ToString(Consultation.Patient_id);

            try
            {
                //execute query on appointment table
                dbConnection.InsertQuery(query, sqlParameters);
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// These function gets the past diagnosis of a specified person
        /// </summary>
        /// <param name="patientID">personID to search the diagnosis history from</param>
        /// <returns> all information about the diagnosis history of the specified person</returns>
        public DataTable SearchDiagnosisHistoryByPersionID(int patientID)
        {
            string query = string.Format("SELECT * " +
                                         "FROM diagnosis dia " +
                                         "JOIN consultations con " +
                                         "ON dia.consultation_id = con.consultation_id " +
                                         "WHERE con.patient_id = patient_id " +
                                         "ORDER BY start_date DESC");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@patient_id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(patientID);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// these function returns a table of all past consultions of a specified person 
        /// </summary>
        /// <param name="personID"> the id of the person to get the consulting history from</param>
        /// <returns> all the consultions history of the specified person</returns>
        public DataTable SearchconsultionHistoryByPersionID(int personID)
        {
            string query = string.Format("SELECT * " +
                                        "FROM consultations  " +
                                        "WHERE  patient_id=(select patient_id from patients where person_id = @patient_id)  " +
                                       " ORDER BY start_date");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@patient_id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(personID);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// these function returns a table of all past consultions of a specified person 
        /// </summary>
        /// <param name="staffId"> the id of the staffmember </param>
        /// <returns> a table of all consultions</returns>
        public DataTable SearchconsultionHistoryByStaffID(int staffId)
        {
            string query = string.Format("SELECT * " +
                                        "FROM consultations  " +
                                        "WHERE  Staff_id = @StaffID  " +
                                       " ORDER BY start_date");

            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("@StaffID", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(staffId);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        /// these function  gets   all the informations regarding the appointments of this day and the specified user
        /// </summary>
        /// <param name="staffID"> the staff id of the person to get the appointments from</param>
        /// <returns> all the informations regarding the appointmentsof this day  </returns>
        public DataTable SearchconsultationsOfToday(int staffID)
        {
            string query = string.Format("SELECT * " +
                                          "FROM consultations " +
                                          "Where DATE(start_date) = @today AND Staff_id = @StaffID");

            MySqlParameter[] sqlParameters = new MySqlParameter[2];
            sqlParameters[0] = new MySqlParameter("@today", MySqlDbType.Date);
            string caseTime = DateTime.Now.ToString("yyyy/MM/dd");
            sqlParameters[0].Value = caseTime;
            sqlParameters[1] = new MySqlParameter("@StaffID", MySqlDbType.Int32);
            sqlParameters[1].Value = Convert.ToString(staffID);

            return dbConnection.SelectQuery(query, sqlParameters);
        }

        /// <summary>
        ///reads changes in the databases from a file and executes it in the database, for syncronation
        /// </summary>
        /// <param name="path"> the path of the file to load into the databae</param>
        /// <returns>true = scriped executed sucessfull false =scriped executed unsucessfull</returns>
        public bool executeScript(string path)
        {
            bool result = false;
            string contents = File.ReadAllText(path);

            try
            {
                result = dbConnection.executeScript(contents);
            }
            catch { return false; }

            return result;
        }

        /// <summary>
        /// function to delete a person by there id
        /// </summary>
        /// <param name="personId">the id of the person to delete</param>
        /// <returns>true= the person was deleted, false = person was not deleted </returns>
        public bool deletePerson(int personId)
        {
            string query = "DELETE FROM person WHERE person_id = ?person_id";
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("?person_id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(personId);
            bool result = false;
            try
            {
                result = dbConnection.DeleteQuery(query, sqlParameters);
            }
            catch { return result; }
            return result;
        }

        /// <summary>
        /// Deletes a staff member record and then deletes the person record associated to it.
        /// </summary>
        /// <param name="personId">The person Id of the staff member to delete</param>
        /// <param name="staffId">The staff Id of the staff member to delete</param>
        /// <returns>
        /// -3: Error occured.
        /// -2: Staff and person weren't deleted.
        /// -1: Person wasn't deleted but staff was.
        /// =1: Successful deletion of both records.
        ///  -: Any other value is considered abnormal.
        /// </returns>
        public int deleteStaff(int personId, int staffId)
        {
            string query = "DELETE FROM Staff_members WHERE Staff_id = ?Staff_id";
            MySqlParameter[] sqlParameters = new MySqlParameter[1];
            sqlParameters[0] = new MySqlParameter("?Staff_id", MySqlDbType.Int32);
            sqlParameters[0].Value = Convert.ToString(staffId);
            bool result = false;
            int returnable = -2;
            try
            {
                result = dbConnection.DeleteQuery(query, sqlParameters);
                if (result)
                {
                    returnable++; // -1
                    result = deletePerson(personId);
                    if (result)
                    {
                        returnable++; // 0
                    }
                }
            }
            catch { return -3; /* Error */}
            if (returnable == 0) //Success.
            {
                return 1;
            }
            else return returnable; // Abnormality
        }

        /// <summary>
        /// Search staff members according to their first name, last name and or staff id.
        /// If staff ID is passed as an argument, it will only look for a matching ID and will
        /// ignore any given name.
        /// </summary>
        /// <param name="fname">First Name</param>
        /// <param name="lname">Last Name</param>
        /// <param name="staffId">Staff ID</param>
        /// <returns>The combined information from a "staff_members" and "person" tables.</returns>
        public DataTable searchStaff(string fname, string lname, int staffId = -1)
        {
            string query = "SELECT p.*, s.* " +
                           "FROM person p, staff_members s " +
                           "WHERE p.person_id = s.person_id";

            if (staffId != -1)
            {
                query += " AND s.Staff_id = ?Staff_id";
            }
            else
            {
                query += " AND p.first_name LIKE ?first_name" +
                         " AND p.last_name LIKE ?last_name";
            }

            MySqlParameter[] sqlParameters = new MySqlParameter[3];
            sqlParameters[0] = new MySqlParameter("?first_name", MySqlDbType.VarChar);
            sqlParameters[0].Value = string.Format("%{0}%", fname);
            sqlParameters[1] = new MySqlParameter("?last_name", MySqlDbType.VarChar);
            sqlParameters[1].Value = string.Format("%{0}%", lname);
            sqlParameters[2] = new MySqlParameter("?Staff_id", MySqlDbType.Int32);
            sqlParameters[2].Value = staffId;

            return dbConnection.SelectQuery(query, sqlParameters);
        }
    }
}
