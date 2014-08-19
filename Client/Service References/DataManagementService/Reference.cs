﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.DataManagementService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class Employee : Client.DataManagementService.EmployeeIdentity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmployeeIdentity", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.DataManagementService.Remarks))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Client.DataManagementService.Employee))]
    public partial class EmployeeIdentity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EmployeeIDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EmployeeID {
            get {
                return this.EmployeeIDField;
            }
            set {
                if ((this.EmployeeIDField.Equals(value) != true)) {
                    this.EmployeeIDField = value;
                    this.RaisePropertyChanged("EmployeeID");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Remarks", Namespace="http://schemas.datacontract.org/2004/07/EmployeeManagementService")]
    [System.SerializableAttribute()]
    public partial class Remarks : Client.DataManagementService.EmployeeIdentity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateTimeNowField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateTimeNow {
            get {
                return this.DateTimeNowField;
            }
            set {
                if ((this.DateTimeNowField.Equals(value) != true)) {
                    this.DateTimeNowField = value;
                    this.RaisePropertyChanged("DateTimeNow");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataManagementService.IAddEmployee")]
    public interface IAddEmployee {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployee/AddNew", ReplyAction="http://tempuri.org/IAddEmployee/AddNewResponse")]
        bool AddNew(int EmployeeID, string FirstName, string LastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployee/AddNew", ReplyAction="http://tempuri.org/IAddEmployee/AddNewResponse")]
        System.Threading.Tasks.Task<bool> AddNewAsync(int EmployeeID, string FirstName, string LastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployee/AddRemark", ReplyAction="http://tempuri.org/IAddEmployee/AddRemarkResponse")]
        bool AddRemark(int EmployeeID, string Remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddEmployee/AddRemark", ReplyAction="http://tempuri.org/IAddEmployee/AddRemarkResponse")]
        System.Threading.Tasks.Task<bool> AddRemarkAsync(int EmployeeID, string Remark);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAddEmployeeChannel : Client.DataManagementService.IAddEmployee, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AddEmployeeClient : System.ServiceModel.ClientBase<Client.DataManagementService.IAddEmployee>, Client.DataManagementService.IAddEmployee {
        
        public AddEmployeeClient() {
        }
        
        public AddEmployeeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AddEmployeeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddEmployeeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AddEmployeeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddNew(int EmployeeID, string FirstName, string LastName) {
            return base.Channel.AddNew(EmployeeID, FirstName, LastName);
        }
        
        public System.Threading.Tasks.Task<bool> AddNewAsync(int EmployeeID, string FirstName, string LastName) {
            return base.Channel.AddNewAsync(EmployeeID, FirstName, LastName);
        }
        
        public bool AddRemark(int EmployeeID, string Remark) {
            return base.Channel.AddRemark(EmployeeID, Remark);
        }
        
        public System.Threading.Tasks.Task<bool> AddRemarkAsync(int EmployeeID, string Remark) {
            return base.Channel.AddRemarkAsync(EmployeeID, Remark);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DataManagementService.IGetEmployeeDetails")]
    public interface IGetEmployeeDetails {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/EmployeeList", ReplyAction="http://tempuri.org/IGetEmployeeDetails/EmployeeListResponse")]
        Client.DataManagementService.Employee[] EmployeeList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/EmployeeList", ReplyAction="http://tempuri.org/IGetEmployeeDetails/EmployeeListResponse")]
        System.Threading.Tasks.Task<Client.DataManagementService.Employee[]> EmployeeListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/EmployeeDetails", ReplyAction="http://tempuri.org/IGetEmployeeDetails/EmployeeDetailsResponse")]
        Client.DataManagementService.Employee EmployeeDetails(int EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/EmployeeDetails", ReplyAction="http://tempuri.org/IGetEmployeeDetails/EmployeeDetailsResponse")]
        System.Threading.Tasks.Task<Client.DataManagementService.Employee> EmployeeDetailsAsync(int EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/EmployeeDetailsByName", ReplyAction="http://tempuri.org/IGetEmployeeDetails/EmployeeDetailsByNameResponse")]
        Client.DataManagementService.Employee[] EmployeeDetailsByName(string FirstName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/EmployeeDetailsByName", ReplyAction="http://tempuri.org/IGetEmployeeDetails/EmployeeDetailsByNameResponse")]
        System.Threading.Tasks.Task<Client.DataManagementService.Employee[]> EmployeeDetailsByNameAsync(string FirstName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/GetRemark", ReplyAction="http://tempuri.org/IGetEmployeeDetails/GetRemarkResponse")]
        Client.DataManagementService.Remarks GetRemark(int EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/GetRemark", ReplyAction="http://tempuri.org/IGetEmployeeDetails/GetRemarkResponse")]
        System.Threading.Tasks.Task<Client.DataManagementService.Remarks> GetRemarkAsync(int EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/GetAllRemarks", ReplyAction="http://tempuri.org/IGetEmployeeDetails/GetAllRemarksResponse")]
        Client.DataManagementService.Remarks[] GetAllRemarks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetEmployeeDetails/GetAllRemarks", ReplyAction="http://tempuri.org/IGetEmployeeDetails/GetAllRemarksResponse")]
        System.Threading.Tasks.Task<Client.DataManagementService.Remarks[]> GetAllRemarksAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGetEmployeeDetailsChannel : Client.DataManagementService.IGetEmployeeDetails, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetEmployeeDetailsClient : System.ServiceModel.ClientBase<Client.DataManagementService.IGetEmployeeDetails>, Client.DataManagementService.IGetEmployeeDetails {
        
        public GetEmployeeDetailsClient() {
        }
        
        public GetEmployeeDetailsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetEmployeeDetailsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetEmployeeDetailsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetEmployeeDetailsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Client.DataManagementService.Employee[] EmployeeList() {
            return base.Channel.EmployeeList();
        }
        
        public System.Threading.Tasks.Task<Client.DataManagementService.Employee[]> EmployeeListAsync() {
            return base.Channel.EmployeeListAsync();
        }
        
        public Client.DataManagementService.Employee EmployeeDetails(int EmployeeID) {
            return base.Channel.EmployeeDetails(EmployeeID);
        }
        
        public System.Threading.Tasks.Task<Client.DataManagementService.Employee> EmployeeDetailsAsync(int EmployeeID) {
            return base.Channel.EmployeeDetailsAsync(EmployeeID);
        }
        
        public Client.DataManagementService.Employee[] EmployeeDetailsByName(string FirstName) {
            return base.Channel.EmployeeDetailsByName(FirstName);
        }
        
        public System.Threading.Tasks.Task<Client.DataManagementService.Employee[]> EmployeeDetailsByNameAsync(string FirstName) {
            return base.Channel.EmployeeDetailsByNameAsync(FirstName);
        }
        
        public Client.DataManagementService.Remarks GetRemark(int EmployeeID) {
            return base.Channel.GetRemark(EmployeeID);
        }
        
        public System.Threading.Tasks.Task<Client.DataManagementService.Remarks> GetRemarkAsync(int EmployeeID) {
            return base.Channel.GetRemarkAsync(EmployeeID);
        }
        
        public Client.DataManagementService.Remarks[] GetAllRemarks() {
            return base.Channel.GetAllRemarks();
        }
        
        public System.Threading.Tasks.Task<Client.DataManagementService.Remarks[]> GetAllRemarksAsync() {
            return base.Channel.GetAllRemarksAsync();
        }
    }
}
