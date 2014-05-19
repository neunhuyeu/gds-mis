﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Patient", Namespace="http://schemas.datacontract.org/2004/07/Appointment_Serves")]
    [System.SerializableAttribute()]
    public partial class Patient : WebApplication1.ServiceReference1.Person {
        
        private char BloodTypek__BackingFieldField;
        
        private int ConsultationIdk__BackingFieldField;
        
        private int DiagnosisIdk__BackingFieldField;
        
        private int Heightk__BackingFieldField;
        
        private string InsuranceNumberk__BackingFieldField;
        
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
        public string InsuranceNumberk__BackingField {
            get {
                return this.InsuranceNumberk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.InsuranceNumberk__BackingFieldField, value) != true)) {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/Appointment_Serves")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WebApplication1.ServiceReference1.Patient))]
    public partial class Person : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string Addressk__BackingFieldField;
        
        private System.DateTime DateOfBirthk__BackingFieldField;
        
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
        public System.DateTime DateOfBirthk__BackingField {
            get {
                return this.DateOfBirthk__BackingFieldField;
            }
            set {
                if ((this.DateOfBirthk__BackingFieldField.Equals(value) != true)) {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Appointment", Namespace="http://schemas.datacontract.org/2004/07/Appointment_Serves")]
    [System.SerializableAttribute()]
    public partial struct Appointment : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int appointmentIDField;
        
        private System.DateTime end_dateField;
        
        private int patient_idField;
        
        private int staff_idField;
        
        private System.DateTime start_dateField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int appointmentID {
            get {
                return this.appointmentIDField;
            }
            set {
                if ((this.appointmentIDField.Equals(value) != true)) {
                    this.appointmentIDField = value;
                    this.RaisePropertyChanged("appointmentID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime end_date {
            get {
                return this.end_dateField;
            }
            set {
                if ((this.end_dateField.Equals(value) != true)) {
                    this.end_dateField = value;
                    this.RaisePropertyChanged("end_date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int patient_id {
            get {
                return this.patient_idField;
            }
            set {
                if ((this.patient_idField.Equals(value) != true)) {
                    this.patient_idField = value;
                    this.RaisePropertyChanged("patient_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int staff_id {
            get {
                return this.staff_idField;
            }
            set {
                if ((this.staff_idField.Equals(value) != true)) {
                    this.staff_idField = value;
                    this.RaisePropertyChanged("staff_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime start_date {
            get {
                return this.start_dateField;
            }
            set {
                if ((this.start_dateField.Equals(value) != true)) {
                    this.start_dateField = value;
                    this.RaisePropertyChanged("start_date");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAppointment")]
    public interface IAppointment {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/SearchappointmentsbyDate", ReplyAction="http://tempuri.org/IAppointment/SearchappointmentsbyDateResponse")]
        WebApplication1.ServiceReference1.Patient[] SearchappointmentsbyDate(System.DateTime date, int staffId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/SearchappointmentsbyDate", ReplyAction="http://tempuri.org/IAppointment/SearchappointmentsbyDateResponse")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Patient[]> SearchappointmentsbyDateAsync(System.DateTime date, int staffId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/getAppointmnetsOfToday", ReplyAction="http://tempuri.org/IAppointment/getAppointmnetsOfTodayResponse")]
        WebApplication1.ServiceReference1.Patient[] getAppointmnetsOfToday(int staffID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/getAppointmnetsOfToday", ReplyAction="http://tempuri.org/IAppointment/getAppointmnetsOfTodayResponse")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Patient[]> getAppointmnetsOfTodayAsync(int staffID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/SearchAppointmentsByStaffID", ReplyAction="http://tempuri.org/IAppointment/SearchAppointmentsByStaffIDResponse")]
        WebApplication1.ServiceReference1.Appointment[] SearchAppointmentsByStaffID(int staffId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/SearchAppointmentsByStaffID", ReplyAction="http://tempuri.org/IAppointment/SearchAppointmentsByStaffIDResponse")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Appointment[]> SearchAppointmentsByStaffIDAsync(int staffId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/getAppointmentsHistorybyPatient", ReplyAction="http://tempuri.org/IAppointment/getAppointmentsHistorybyPatientResponse")]
        WebApplication1.ServiceReference1.Appointment[] getAppointmentsHistorybyPatient(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/getAppointmentsHistorybyPatient", ReplyAction="http://tempuri.org/IAppointment/getAppointmentsHistorybyPatientResponse")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Appointment[]> getAppointmentsHistorybyPatientAsync(int personId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/Login", ReplyAction="http://tempuri.org/IAppointment/LoginResponse")]
        WebApplication1.ServiceReference1.Patient Login(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAppointment/Login", ReplyAction="http://tempuri.org/IAppointment/LoginResponse")]
        System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Patient> LoginAsync(string email, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAppointmentChannel : WebApplication1.ServiceReference1.IAppointment, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AppointmentClient : System.ServiceModel.ClientBase<WebApplication1.ServiceReference1.IAppointment>, WebApplication1.ServiceReference1.IAppointment {
        
        public AppointmentClient() {
        }
        
        public AppointmentClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AppointmentClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AppointmentClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AppointmentClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplication1.ServiceReference1.Patient[] SearchappointmentsbyDate(System.DateTime date, int staffId) {
            return base.Channel.SearchappointmentsbyDate(date, staffId);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Patient[]> SearchappointmentsbyDateAsync(System.DateTime date, int staffId) {
            return base.Channel.SearchappointmentsbyDateAsync(date, staffId);
        }
        
        public WebApplication1.ServiceReference1.Patient[] getAppointmnetsOfToday(int staffID) {
            return base.Channel.getAppointmnetsOfToday(staffID);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Patient[]> getAppointmnetsOfTodayAsync(int staffID) {
            return base.Channel.getAppointmnetsOfTodayAsync(staffID);
        }
        
        public WebApplication1.ServiceReference1.Appointment[] SearchAppointmentsByStaffID(int staffId) {
            return base.Channel.SearchAppointmentsByStaffID(staffId);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Appointment[]> SearchAppointmentsByStaffIDAsync(int staffId) {
            return base.Channel.SearchAppointmentsByStaffIDAsync(staffId);
        }
        
        public WebApplication1.ServiceReference1.Appointment[] getAppointmentsHistorybyPatient(int personId) {
            return base.Channel.getAppointmentsHistorybyPatient(personId);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Appointment[]> getAppointmentsHistorybyPatientAsync(int personId) {
            return base.Channel.getAppointmentsHistorybyPatientAsync(personId);
        }
        
        public WebApplication1.ServiceReference1.Patient Login(string email, string password) {
            return base.Channel.Login(email, password);
        }
        
        public System.Threading.Tasks.Task<WebApplication1.ServiceReference1.Patient> LoginAsync(string email, string password) {
            return base.Channel.LoginAsync(email, password);
        }
    }
}
