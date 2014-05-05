/*
Created: 27-Feb-14
Modified: 21-Mar-14
Model: MIS
Database: MySQL 5.5
*/

-- Create DB Section-----------------------------------

CREATE DATABASE gds_mis;

CREATE User 'gds'@'%' IDENTIFIED BY 'gds-m1s-r00t!';

GRANT ALL PRIVILEGES on gds_mis.* to 'gds'@'%';

FLUSH PRIVILEGES;

-- Create tables section -------------------------------------------------

-- Table person

CREATE TABLE  IF NOT EXISTS person
(
  person_id Int NOT NULL AUTO_INCREMENT,
  first_name Char(50) NOT NULL,
  last_name Char(50) NOT NULL,
  date_of_birth Date NOT NULL,
  email_address Char(50) NOT NULL,
  mobile_number Char(25),
  landline_number Char(25),
  home_address Char(50) NOT NULL,
  insurance_number Char(10) NOT NULL,
 PRIMARY KEY (person_id),
 UNIQUE person_id (person_id)
)
;

-- Table patients

CREATE TABLE patients
(
  patient_id Int NOT NULL AUTO_INCREMENT,
  gender Char(10) NOT NULL,
  height_cm Int NOT NULL,
  weight_kg Int NOT NULL,
  blood_type Char(10) NOT NULL,
  smoking Bool NOT NULL,
  smoking_frequency Int,
  hard_drugs Bool NOT NULL,
  hard_drugs_frequency Int,
  person_id Int NOT NULL,
 PRIMARY KEY (patient_id,person_id),
 UNIQUE patient_id (patient_id)
)
;

-- Table prescribtion

CREATE TABLE prescribtion
(
  prescribtion_id Int NOT NULL AUTO_INCREMENT,
  medicine Char(50) NOT NULL,
  strength_mg Int NOT NULL,
  amount_pills Int,
  ammount_ml Int,
  consultation_id Int NOT NULL,
 PRIMARY KEY (prescribtion_id,consultation_id),
 UNIQUE prescribtion_id (prescribtion_id)
)
;

-- Table diagnosis

CREATE TABLE diagnosis
(
  diagnosis_id Int NOT NULL AUTO_INCREMENT,
  consultation_id Int NOT NULL,
  symptoms Char(250) NOT NULL,
  diagnosis Char(250) NOT NULL,
 PRIMARY KEY (diagnosis_id),
 UNIQUE diagnosis_id (diagnosis_id)
)
;

-- Table consultations

CREATE TABLE consultations
(
  consultation_id Int NOT NULL,
  start_date Datetime NOT NULL,
  end_date Datetime NOT NULL,
  patient_id Int NOT NULL,
  Staff_id Int NOT NULL
)
;

ALTER TABLE consultations ADD PRIMARY KEY (consultation_id,patient_id,Staff_id)
;

ALTER TABLE consultations ADD UNIQUE Key8 (consultation_id)
;

-- Table Staff_members

CREATE TABLE Staff_members
(
  Staff_id Int NOT NULL AUTO_INCREMENT,
  function Char(30) NOT NULL,
  specialization Char(30) NOT NULL,
  room_number Char(20) NOT NULL,
  person_id Int NOT NULL,
 PRIMARY KEY (Staff_id,person_id),
 UNIQUE Staff_id (Staff_id)
)
;

-- Create relationships section ------------------------------------------------- 

ALTER TABLE patients ADD CONSTRAINT patients_personID_fk FOREIGN KEY (person_id) REFERENCES person (person_id) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE diagnosis ADD CONSTRAINT diagnosis_consultationID_fk FOREIGN KEY (consultation_id) REFERENCES consultations (consultation_id) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE consultations ADD CONSTRAINT consultations_patientID_fk FOREIGN KEY (patient_id) REFERENCES patients (patient_id) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE Staff_members ADD CONSTRAINT Staff_members_personID_fk FOREIGN KEY (person_id) REFERENCES person (person_id) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE consultations ADD CONSTRAINT consultations_staffID_fk FOREIGN KEY (Staff_id) REFERENCES Staff_members (Staff_id) ON DELETE NO ACTION ON UPDATE NO ACTION
;

ALTER TABLE prescribtion ADD CONSTRAINT prescribtion_consultationID_fk FOREIGN KEY (consultation_id) REFERENCES consultations (consultation_id) ON DELETE NO ACTION ON UPDATE NO ACTION
;

-- Populate tables section ------------------------------------------------------ 

-- person

INSERT INTO person (person_id, first_name, last_name, date_of_birth,email_address,mobile_number,landline_number,home_address, insurance_number) VALUES
(1 ,'name_one','last_one','1990-01-01','name_one@mail.com','1234567890','0987654321','12a home_street 1234PC town_name','1234567890'),
(2 ,'name_two','last_two','1990-02-01','name_two@mail.com','1234567890','0987654321','13a home_street 1234PC town_name','1234567891'),
(3 ,'name_three','last_three','1990-03-01','name_three@mail.com','1234567890','0987654321','14a home_street 1234PC town_name','1234567892'),
(4 ,'name_four','last_four','1990-04-01','name_four@mail.com','1234567890','0987654321','15a home_street 1234PC town_name','1234567893'),
(5 ,'name_five','last_five','1990-05-01','name_five@mail.com','1234567890','0987654321','16a home_street 1234PC town_name','1234567894'),
(6 ,'name_six','last_six','1990-06-01','name_six@mail.com','1234567890','0987654321','17a home_street 1234PC town_name','1234567895'),
(7 ,'name_seven','last_seven','1990-07-01','name_seven@mail.com','1234567890','0987654321','18a home_street 1234PC town_name','1234567896'),
(8 ,'name_eight','last_eight','1990-08-01','name_eight@mail.com','1234567890','0987654321','19a home_street 1234PC town_name','1234567897'),
(9 ,'name_nine','last_nine','1990-09-01','name_nine@mail.com','1234567890','0987654321','20a home_street 1234PC town_name','1234567898'),
(10 ,'name_ten','last_ten','1990-10-01','name_ten@mail.com','1234567890','0987654321','21a home_street 1234PC town_name','1234567899');

-- Staff_members

INSERT INTO Staff_members (Staff_id,function,specialization,room_number,person_id) VALUES
(1,'doctor','GP','a1.123',1),
(2,'doctor','sports_injuries','a1.124',2),
(3,'nurse','GN','a1.125',3),
(4,'nurse','trauma','a1.125',4),
(5,'secretary','N.A','a1.122',5);

-- patients

INSERT INTO patients (patient_id,gender,height_cm,weight_kg,blood_type,smoking,smoking_frequency,hard_drugs,hard_drugs_frequency,person_id) VALUES
(1,'male',170,80,'a+',TRUE,5,FALSE,NULL,6), 
(2,'female',160,60,'o-',FALSE,NULL,FALSE,NULL,7),
(3,'male',171,70,'o+',FALSE,NULL,FALSE,NULL,8),
(4,'female',159,50,'o+',TRUE,10, FALSE,NULL,9),
(5,'male',165,60,'a+',FALSE,NULL,FALSE,NULL,10);

-- consultations

INSERT INTO consultations (consultation_id,start_date,end_date,patient_id,Staff_id) VALUES
(1 ,'2014-01-20 09:30:00','2014-01-20 10:00:00',1,1),
(2 ,'2014-01-20 09:30:00','2014-01-20 10:00:00',2,2),
(3 ,'2014-01-20 10:00:00','2014-01-20 10:30:00',3,1),
(4 ,'2014-01-21 10:30:00','2014-01-21 11:00:00',4,1),
(5 ,'2014-01-21 10:30:00','2014-01-21 11:00:00',5,2);

-- diagnosis

INSERT INTO diagnosis (diagnosis_id,consultation_id,symptoms,diagnosis) VALUES
(1,1,'head aches, facial swelling','allergic reaction'),
(2,2,'fever, light-headed','scarlet fever'),
(3,3,'cronic sneezing','snifflelys'),
(4,4,'nausia, headaches, vomitting','immenent death'),
(5,5,'constant fatigue, low apitite','nutrition deficiency');

-- prescribtion

INSERT INTO prescribtion (prescribtion_id,medicine,strength_mg,amount_pills,ammount_ml,consultation_id) VALUES
(1,'anti inflamation things',50,14,NULL,1),
(2,'anitdote',500,NULL,500,2),
(3,'healing potion',100,NULL,500,2),
(4,'sinus disinfectus',100,21,NULL,3),
(5,'resurection tablets',10000,1,NULL,4),
(6,'vitamens',1000,60,NULL,5);

-- Test queries section --------------------------------------------------

select pp.first_name, d.diagnosis, s.function, ppp.medicine  from diagnosis d , consultations c, patients p, person pp , Staff_members s, prescribtion ppp
where c.patient_id = p.patient_id and d.consultation_id = c.consultation_id 
and pp.person_id = p.person_id and c.Staff_id = s.Staff_id and ppp.consultation_id = c.consultation_id;

-- Drop tables section ---------------------------------------------------

Drop table prescribtion;
Drop table diagnosis;
Drop table consultations;
Drop table patients;
Drop table Staff_members;
Drop table person;