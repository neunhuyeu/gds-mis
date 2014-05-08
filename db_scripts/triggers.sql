-- I couldn't get the triggers to work ....

-- Drop Trigger Section --------------------------------------------------------- 

DROP TRIGGER IF EXISTS after_patient_insert;
DROP TRIGGER IF EXISTS after_patient_update;
DROP TRIGGER IF EXISTS after_staff_insert;
DROP TRIGGER IF EXISTS after_staff_update;

-- Create Trigger Section ------------------------------------------------------- 
-- this trigger is not working
-- CREATE TRIGGER gafter_patient_insert
-- AFTER INSERT ON gds_mis.patients
-- FOR EACH ROW BEGIN
-- INSERT INTO gds_mis_agenda.patient_info (patient_id,first_name,last_name,date_of_birth,email_address,mobile_number,landline_number,home_address,insurance_number ) VALUES 
-- (NEW.patient_id,(SELECT pat.patient_id,first_name,last_name,date_of_birth,email_address,mobile_number,landline_number,home_address,insurance_number 
-- FROM gds_mis.person per, gds_mis.patients pat 
-- WHERE per.person_id = pat.person_id 
-- and pat.patient_id = NEW.patient_id;))
-- END;