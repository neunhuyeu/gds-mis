﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Doctor_Client.ServerConnection {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/DMS_Service")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Doctor_Client.ServerConnection.Staff))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Doctor_Client.ServerConnection.Patient))]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string Addressk__BackingFieldField;
        
        private string DateOfBirthk__BackingFieldField;
        
        private string Emailk__BackingFieldField;
        
        private string FirstNamek__BackingFieldField;
        
        private char Genderk__BackingFieldField;
        
        private string LandLineNumberk__BackingFieldField;
        
        private string LastNamek__BackingFieldField;
        
        private string MobileNumberk__BackingFieldField;
        
        private int PersonIdk__BackingFieldField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Address>k__BackingField", IsRequired=true)]
        public string Addressk__BackingField {
            get {
                return this.Addressk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Addressk__BackingFieldField, value) != true)) {
                    this.Addressk__BackingFieldField = value;
                    this.RaisePropertyChanged("Addressk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<DateOfBirth>k__BackingField", IsRequired=true)]
        public string DateOfBirthk__BackingField {
            get {
                return this.DateOfBirthk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.DateOfBirthk__BackingFieldField, value) != true)) {
                    this.DateOfBirthk__BackingFieldField = value;
                    this.RaisePropertyChanged("DateOfBirthk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Email>k__BackingField", IsRequired=true)]
        public string Emailk__BackingField {
            get {
                return this.Emailk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Emailk__BackingFieldField, value) != true)) {
                    this.Emailk__BackingFieldField = value;
                    this.RaisePropertyChanged("Emailk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<FirstName>k__BackingField", IsRequired=true)]
        public string FirstNamek__BackingField {
            get {
                return this.FirstNamek__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNamek__BackingFieldField, value) != true)) {
                    this.FirstNamek__BackingFieldField = value;
                    this.RaisePropertyChanged("FirstNamek__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Gender>k__BackingField", IsRequired=true)]
        public char Genderk__BackingField {
            get {
                return this.Genderk__BackingFieldField;
            }
            set {
                if ((this.Genderk__BackingFieldField.Equals(value) != true)) {
                    this.Genderk__BackingFieldField = value;
                    this.RaisePropertyChanged("Genderk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<LandLineNumber>k__BackingField", IsRequired=true)]
        public string LandLineNumberk__BackingField {
            get {
                return this.LandLineNumberk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.LandLineNumberk__BackingFieldField, value) != true)) {
                    this.LandLineNumberk__BackingFieldField = value;
                    this.RaisePropertyChanged("LandLineNumberk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<LastName>k__BackingField", IsRequired=true)]
        public string LastNamek__BackingField {
            get {
                return this.LastNamek__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNamek__BackingFieldField, value) != true)) {
                    this.LastNamek__BackingFieldField = value;
                    this.RaisePropertyChanged("LastNamek__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<MobileNumber>k__BackingField", IsRequired=true)]
        public string MobileNumberk__BackingField {
            get {
                return this.MobileNumberk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.MobileNumberk__BackingFieldField, value) != true)) {
                    this.MobileNumberk__BackingFieldField = value;
                    this.RaisePropertyChanged("MobileNumberk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<PersonId>k__BackingField", IsRequired=true)]
        public int PersonIdk__BackingField {
            get {
                return this.PersonIdk__BackingFieldField;
            }
            set {
                if ((this.PersonIdk__BackingFieldField.Equals(value) != true)) {
                    this.PersonIdk__BackingFieldField = value;
                    this.RaisePropertyChanged("PersonIdk__BackingField");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Staff", Namespace="http://schemas.datacontract.org/2004/07/DMS_Service")]
    [System.SerializableAttribute()]
    public partial class Staff : Doctor_Client.ServerConnection.Person {
        
        private Doctor_Client.ServerConnection.Staff.StaffType Functionk__BackingFieldField;
        
        private int RoomNumberk__BackingFieldField;
        
        private string Specializationk__BackingFieldField;
        
        private int StaffIDk__BackingFieldField;
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Function>k__BackingField", IsRequired=true)]
        public Doctor_Client.ServerConnection.Staff.StaffType Functionk__BackingField {
            get {
                return this.Functionk__BackingFieldField;
            }
            set {
                if ((this.Functionk__BackingFieldField.Equals(value) != true)) {
                    this.Functionk__BackingFieldField = value;
                    this.RaisePropertyChanged("Functionk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<RoomNumber>k__BackingField", IsRequired=true)]
        public int RoomNumberk__BackingField {
            get {
                return this.RoomNumberk__BackingFieldField;
            }
            set {
                if ((this.RoomNumberk__BackingFieldField.Equals(value) != true)) {
                    this.RoomNumberk__BackingFieldField = value;
                    this.RaisePropertyChanged("RoomNumberk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Specialization>k__BackingField", IsRequired=true)]
        public string Specializationk__BackingField {
            get {
                return this.Specializationk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Specializationk__BackingFieldField, value) != true)) {
                    this.Specializationk__BackingFieldField = value;
                    this.RaisePropertyChanged("Specializationk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<StaffID>k__BackingField", IsRequired=true)]
        public int StaffIDk__BackingField {
            get {
                return this.StaffIDk__BackingFieldField;
            }
            set {
                if ((this.StaffIDk__BackingFieldField.Equals(value) != true)) {
                    this.StaffIDk__BackingFieldField = value;
                    this.RaisePropertyChanged("StaffIDk__BackingField");
                }
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name="Staff.StaffType", Namespace="http://schemas.datacontract.org/2004/07/DMS_Service")]
        public enum StaffType : int {
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            physician = 0,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            assistant = 1,
            
            [System.Runtime.Serialization.EnumMemberAttribute()]
            secretary = 2,
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Patient", Namespace="http://schemas.datacontract.org/2004/07/DMS_Service")]
    [System.SerializableAttribute()]
    public partial class Patient : Doctor_Client.ServerConnection.Person {
        
        private char BloodTypek__BackingFieldField;
        
        private int ConsultationIdk__BackingFieldField;
        
        private int DiagnosisIdk__BackingFieldField;
        
        private int Heightk__BackingFieldField;
        
        private int InsuranceNumberk__BackingFieldField;
        
        private int PatientIDk__BackingFieldField;
        
        private int PrescriptionIdk__BackingFieldField;
        
        private bool Smokerk__BackingFieldField;
        
        private int SmokingFrequencyk__BackingFieldField;
        
        private int Weightk__BackingFieldField;
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<BloodType>k__BackingField", IsRequired=true)]
        public char BloodTypek__BackingField {
            get {
                return this.BloodTypek__BackingFieldField;
            }
            set {
                if ((this.BloodTypek__BackingFieldField.Equals(value) != true)) {
                    this.BloodTypek__BackingFieldField = value;
                    this.RaisePropertyChanged("BloodTypek__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<ConsultationId>k__BackingField", IsRequired=true)]
        public int ConsultationIdk__BackingField {
            get {
                return this.ConsultationIdk__BackingFieldField;
            }
            set {
                if ((this.ConsultationIdk__BackingFieldField.Equals(value) != true)) {
                    this.ConsultationIdk__BackingFieldField = value;
                    this.RaisePropertyChanged("ConsultationIdk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<DiagnosisId>k__BackingField", IsRequired=true)]
        public int DiagnosisIdk__BackingField {
            get {
                return this.DiagnosisIdk__BackingFieldField;
            }
            set {
                if ((this.DiagnosisIdk__BackingFieldField.Equals(value) != true)) {
                    this.DiagnosisIdk__BackingFieldField = value;
                    this.RaisePropertyChanged("DiagnosisIdk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Height>k__BackingField", IsRequired=true)]
        public int Heightk__BackingField {
            get {
                return this.Heightk__BackingFieldField;
            }
            set {
                if ((this.Heightk__BackingFieldField.Equals(value) != true)) {
                    this.Heightk__BackingFieldField = value;
                    this.RaisePropertyChanged("Heightk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<InsuranceNumber>k__BackingField", IsRequired=true)]
        public int InsuranceNumberk__BackingField {
            get {
                return this.InsuranceNumberk__BackingFieldField;
            }
            set {
                if ((this.InsuranceNumberk__BackingFieldField.Equals(value) != true)) {
                    this.InsuranceNumberk__BackingFieldField = value;
                    this.RaisePropertyChanged("InsuranceNumberk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<PatientID>k__BackingField", IsRequired=true)]
        public int PatientIDk__BackingField {
            get {
                return this.PatientIDk__BackingFieldField;
            }
            set {
                if ((this.PatientIDk__BackingFieldField.Equals(value) != true)) {
                    this.PatientIDk__BackingFieldField = value;
                    this.RaisePropertyChanged("PatientIDk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<PrescriptionId>k__BackingField", IsRequired=true)]
        public int PrescriptionIdk__BackingField {
            get {
                return this.PrescriptionIdk__BackingFieldField;
            }
            set {
                if ((this.PrescriptionIdk__BackingFieldField.Equals(value) != true)) {
                    this.PrescriptionIdk__BackingFieldField = value;
                    this.RaisePropertyChanged("PrescriptionIdk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Smoker>k__BackingField", IsRequired=true)]
        public bool Smokerk__BackingField {
            get {
                return this.Smokerk__BackingFieldField;
            }
            set {
                if ((this.Smokerk__BackingFieldField.Equals(value) != true)) {
                    this.Smokerk__BackingFieldField = value;
                    this.RaisePropertyChanged("Smokerk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<SmokingFrequency>k__BackingField", IsRequired=true)]
        public int SmokingFrequencyk__BackingField {
            get {
                return this.SmokingFrequencyk__BackingFieldField;
            }
            set {
                if ((this.SmokingFrequencyk__BackingFieldField.Equals(value) != true)) {
                    this.SmokingFrequencyk__BackingFieldField = value;
                    this.RaisePropertyChanged("SmokingFrequencyk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Weight>k__BackingField", IsRequired=true)]
        public int Weightk__BackingField {
            get {
                return this.Weightk__BackingFieldField;
            }
            set {
                if ((this.Weightk__BackingFieldField.Equals(value) != true)) {
                    this.Weightk__BackingFieldField = value;
                    this.RaisePropertyChanged("Weightk__BackingField");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Appointment", Namespace="http://schemas.datacontract.org/2004/07/DMS_Service")]
    [System.SerializableAttribute()]
    public partial struct Appointment : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] DiagnosisField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Doctor_Client.ServerConnection.Patient PatientField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Doctor_Client.ServerConnection.Staff StaffField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool canceledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime endTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string notesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Doctor_Client.ServerConnection.Perscription[] perscriptionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime startTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] symptomsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Diagnosis {
            get {
                return this.DiagnosisField;
            }
            set {
                if ((object.ReferenceEquals(this.DiagnosisField, value) != true)) {
                    this.DiagnosisField = value;
                    this.RaisePropertyChanged("Diagnosis");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Doctor_Client.ServerConnection.Patient Patient {
            get {
                return this.PatientField;
            }
            set {
                if ((object.ReferenceEquals(this.PatientField, value) != true)) {
                    this.PatientField = value;
                    this.RaisePropertyChanged("Patient");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Doctor_Client.ServerConnection.Staff Staff {
            get {
                return this.StaffField;
            }
            set {
                if ((object.ReferenceEquals(this.StaffField, value) != true)) {
                    this.StaffField = value;
                    this.RaisePropertyChanged("Staff");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool canceled {
            get {
                return this.canceledField;
            }
            set {
                if ((this.canceledField.Equals(value) != true)) {
                    this.canceledField = value;
                    this.RaisePropertyChanged("canceled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime endTime {
            get {
                return this.endTimeField;
            }
            set {
                if ((this.endTimeField.Equals(value) != true)) {
                    this.endTimeField = value;
                    this.RaisePropertyChanged("endTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string notes {
            get {
                return this.notesField;
            }
            set {
                if ((object.ReferenceEquals(this.notesField, value) != true)) {
                    this.notesField = value;
                    this.RaisePropertyChanged("notes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Doctor_Client.ServerConnection.Perscription[] perscriptions {
            get {
                return this.perscriptionsField;
            }
            set {
                if ((object.ReferenceEquals(this.perscriptionsField, value) != true)) {
                    this.perscriptionsField = value;
                    this.RaisePropertyChanged("perscriptions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime startTime {
            get {
                return this.startTimeField;
            }
            set {
                if ((this.startTimeField.Equals(value) != true)) {
                    this.startTimeField = value;
                    this.RaisePropertyChanged("startTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] symptoms {
            get {
                return this.symptomsField;
            }
            set {
                if ((object.ReferenceEquals(this.symptomsField, value) != true)) {
                    this.symptomsField = value;
                    this.RaisePropertyChanged("symptoms");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Perscription", Namespace="http://schemas.datacontract.org/2004/07/DMS_Service")]
    [System.SerializableAttribute()]
    public partial struct Perscription : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string doctorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int dosageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string drugField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime date {
            get {
                return this.dateField;
            }
            set {
                if ((this.dateField.Equals(value) != true)) {
                    this.dateField = value;
                    this.RaisePropertyChanged("date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string doctor {
            get {
                return this.doctorField;
            }
            set {
                if ((object.ReferenceEquals(this.doctorField, value) != true)) {
                    this.doctorField = value;
                    this.RaisePropertyChanged("doctor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int dosage {
            get {
                return this.dosageField;
            }
            set {
                if ((this.dosageField.Equals(value) != true)) {
                    this.dosageField = value;
                    this.RaisePropertyChanged("dosage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string drug {
            get {
                return this.drugField;
            }
            set {
                if ((object.ReferenceEquals(this.drugField, value) != true)) {
                    this.drugField = value;
                    this.RaisePropertyChanged("drug");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServerConnection.IDoctor")]
    public interface IDoctor {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetPatient_by_lastName_DateOfBirth", ReplyAction="http://tempuri.org/IDoctor/GetPatient_by_lastName_DateOfBirthResponse")]
        Doctor_Client.ServerConnection.Patient GetPatient_by_lastName_DateOfBirth(string lastName, System.DateTime dateOfBirth);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetPatient_by_lastName_DateOfBirth", ReplyAction="http://tempuri.org/IDoctor/GetPatient_by_lastName_DateOfBirthResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Patient> GetPatient_by_lastName_DateOfBirthAsync(string lastName, System.DateTime dateOfBirth);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetPatientOverview", ReplyAction="http://tempuri.org/IDoctor/GetPatientOverviewResponse")]
        Doctor_Client.ServerConnection.Patient GetPatientOverview(int personID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetPatientOverview", ReplyAction="http://tempuri.org/IDoctor/GetPatientOverviewResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Patient> GetPatientOverviewAsync(int personID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetStaff_by_id", ReplyAction="http://tempuri.org/IDoctor/GetStaff_by_idResponse")]
        Doctor_Client.ServerConnection.Staff GetStaff_by_id(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetStaff_by_id", ReplyAction="http://tempuri.org/IDoctor/GetStaff_by_idResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Staff> GetStaff_by_idAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetPatientDiseases", ReplyAction="http://tempuri.org/IDoctor/GetPatientDiseasesResponse")]
        string[] GetPatientDiseases(int patientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/GetPatientDiseases", ReplyAction="http://tempuri.org/IDoctor/GetPatientDiseasesResponse")]
        System.Threading.Tasks.Task<string[]> GetPatientDiseasesAsync(int patientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/getPatientAppointments", ReplyAction="http://tempuri.org/IDoctor/getPatientAppointmentsResponse")]
        Doctor_Client.ServerConnection.Appointment[] getPatientAppointments(int patientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/getPatientAppointments", ReplyAction="http://tempuri.org/IDoctor/getPatientAppointmentsResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Appointment[]> getPatientAppointmentsAsync(int patientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/getPatientPerscriptions", ReplyAction="http://tempuri.org/IDoctor/getPatientPerscriptionsResponse")]
        Doctor_Client.ServerConnection.Perscription[] getPatientPerscriptions(int patientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/getPatientPerscriptions", ReplyAction="http://tempuri.org/IDoctor/getPatientPerscriptionsResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Perscription[]> getPatientPerscriptionsAsync(int patientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/search", ReplyAction="http://tempuri.org/IDoctor/searchResponse")]
        Doctor_Client.ServerConnection.Patient[] search(string name, string dateOfBirth, string insuranceNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/search", ReplyAction="http://tempuri.org/IDoctor/searchResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Patient[]> searchAsync(string name, string dateOfBirth, string insuranceNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/setPerscription", ReplyAction="http://tempuri.org/IDoctor/setPerscriptionResponse")]
        string setPerscription(int appointmentID, Doctor_Client.ServerConnection.Perscription perscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/setPerscription", ReplyAction="http://tempuri.org/IDoctor/setPerscriptionResponse")]
        System.Threading.Tasks.Task<string> setPerscriptionAsync(int appointmentID, Doctor_Client.ServerConnection.Perscription perscription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/login", ReplyAction="http://tempuri.org/IDoctor/loginResponse")]
        Doctor_Client.ServerConnection.Staff login(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDoctor/login", ReplyAction="http://tempuri.org/IDoctor/loginResponse")]
        System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Staff> loginAsync(string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDoctorChannel : Doctor_Client.ServerConnection.IDoctor, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DoctorClient : System.ServiceModel.ClientBase<Doctor_Client.ServerConnection.IDoctor>, Doctor_Client.ServerConnection.IDoctor {
        
        public DoctorClient() {
        }
        
        public DoctorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DoctorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DoctorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DoctorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Doctor_Client.ServerConnection.Patient GetPatient_by_lastName_DateOfBirth(string lastName, System.DateTime dateOfBirth) {
            return base.Channel.GetPatient_by_lastName_DateOfBirth(lastName, dateOfBirth);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Patient> GetPatient_by_lastName_DateOfBirthAsync(string lastName, System.DateTime dateOfBirth) {
            return base.Channel.GetPatient_by_lastName_DateOfBirthAsync(lastName, dateOfBirth);
        }
        
        public Doctor_Client.ServerConnection.Patient GetPatientOverview(int personID) {
            return base.Channel.GetPatientOverview(personID);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Patient> GetPatientOverviewAsync(int personID) {
            return base.Channel.GetPatientOverviewAsync(personID);
        }
        
        public Doctor_Client.ServerConnection.Staff GetStaff_by_id(int id) {
            return base.Channel.GetStaff_by_id(id);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Staff> GetStaff_by_idAsync(int id) {
            return base.Channel.GetStaff_by_idAsync(id);
        }
        
        public string[] GetPatientDiseases(int patientID) {
            return base.Channel.GetPatientDiseases(patientID);
        }
        
        public System.Threading.Tasks.Task<string[]> GetPatientDiseasesAsync(int patientID) {
            return base.Channel.GetPatientDiseasesAsync(patientID);
        }
        
        public Doctor_Client.ServerConnection.Appointment[] getPatientAppointments(int patientID) {
            return base.Channel.getPatientAppointments(patientID);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Appointment[]> getPatientAppointmentsAsync(int patientID) {
            return base.Channel.getPatientAppointmentsAsync(patientID);
        }
        
        public Doctor_Client.ServerConnection.Perscription[] getPatientPerscriptions(int patientID) {
            return base.Channel.getPatientPerscriptions(patientID);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Perscription[]> getPatientPerscriptionsAsync(int patientID) {
            return base.Channel.getPatientPerscriptionsAsync(patientID);
        }
        
        public Doctor_Client.ServerConnection.Patient[] search(string name, string dateOfBirth, string insuranceNumber) {
            return base.Channel.search(name, dateOfBirth, insuranceNumber);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Patient[]> searchAsync(string name, string dateOfBirth, string insuranceNumber) {
            return base.Channel.searchAsync(name, dateOfBirth, insuranceNumber);
        }
        
        public string setPerscription(int appointmentID, Doctor_Client.ServerConnection.Perscription perscription) {
            return base.Channel.setPerscription(appointmentID, perscription);
        }
        
        public System.Threading.Tasks.Task<string> setPerscriptionAsync(int appointmentID, Doctor_Client.ServerConnection.Perscription perscription) {
            return base.Channel.setPerscriptionAsync(appointmentID, perscription);
        }
        
        public Doctor_Client.ServerConnection.Staff login(string email, string password) {
            return base.Channel.login(email, password);
        }
        
        public System.Threading.Tasks.Task<Doctor_Client.ServerConnection.Staff> loginAsync(string email, string password) {
            return base.Channel.loginAsync(email, password);
        }
    }
}
