/*
Created: 17-Apr-14
Modified: 19-Apr-14
Model: MIS
Database: MySQL 5.5
*/

-- Create DB Section-----------------------------------

CREATE DATABASE gds_mis_auth;

GRANT ALL PRIVILEGES on gds_mis_auth.* to 'gds'@'%';

FLUSH PRIVILEGES;

-- Create tables section -------------------------------------------------

-- Table user_auth

CREATE TABLE  IF NOT EXISTS user_auth
(
  email_address Char(50) NOT NULL,
  password Char(25) NOT NULL,
  user_name Char(25) NOT NULL,
  PRIMARY KEY (email_address),
  UNIQUE email_address (email_address)
);

  
-- Populate tables section ------------------------------------------------------ 

-- user_auth

INSERT INTO user_auth (email_address, password, user_name) VALUES
('name_one@mail.com', 'name_one', 'name_one'),
('name_two@mail.com', 'name_two', 'name_tow');