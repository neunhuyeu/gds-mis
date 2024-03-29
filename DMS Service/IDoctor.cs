﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DMS_Service.Structs;
using DMS_Service.wiki;

namespace DMS_Service
{
    /// <summary>
    /// stucture for the storage of informations about a doctor
    /// </summary>
    [ServiceContract]
    public interface IDoctor
    {
        [OperationContract]
        Patient GetPatient_by_lastName_DateOfBirth(string lastName, string dateOfBirth);
        [OperationContract]
        int getnextConsultationID();
        [OperationContract]
        List<Consultation> getConsultationHistorybyPatient(int Patientid);
        [OperationContract]
        List<Consultation> SearchconsultionHistoryByStaffID(int staffId);
        [OperationContract]
        List<Consultation> getConsultationOfToday(int staffID);
        
        [OperationContract]
        List<Diagnosis> getDiagnosisHistoryByPersionID(int Patientid);
        [OperationContract]
        Staff Login(string Email, string Passward);

        [OperationContract]
        Patient GetPatientOverview(int personID);
        [OperationContract]
        bool updateConsultion_End_Date(Consultation currentConultion);
        [OperationContract]
        bool addConsultion(Consultation currentConsultation);
        [OperationContract]
        Staff GetStaff_by_staff_id(int id);

        [OperationContract]
        Staff GetStaff_by_Personid(int id);

       
        
        [OperationContract]
        List<Perscription> getPatientPerscriptions(int patientID);

        [OperationContract]
        List<Patient> SearchPatients(string first, string last, DateTime dateOfBirth, string insurance);

        
        [OperationContract]
        bool addPerscription(int appointmentID, Perscription perscription);
        [OperationContract]
        bool addDiagnosis(Diagnosis diagnosis);

        //methods for interacting with the wiki
        [OperationContract]
        List<Disease> get_all_diseases();
        [OperationContract]
        List<Disease> search_disease(string name, string symptoms, string classification);
        [OperationContract]
        List<Medicine> get_all_medicines();
        [OperationContract]
        List<Medicine> search_medicine(string name, string side_effects, string classification);

        //Methods for testing Synchronization
        [OperationContract]
        void addTestPatient();

        [OperationContract]
        void addTestAppointment();
    }
}
