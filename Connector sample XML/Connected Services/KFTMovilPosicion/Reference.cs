﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Connector_sample_XML.KFTMovilPosicion {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TypeKFTReturn", Namespace="http://schemas.datacontract.org/2004/07/KFTConnectorServer")]
    [System.SerializableAttribute()]
    public partial class TypeKFTReturn : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool isSuccesfulField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isSuccesful {
            get {
                return this.isSuccesfulField;
            }
            set {
                if ((this.isSuccesfulField.Equals(value) != true)) {
                    this.isSuccesfulField = value;
                    this.RaisePropertyChanged("isSuccesful");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KFTMovilPosicion.IWSMovilPosicionService")]
    public interface IWSMovilPosicionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWSMovilPosicionService/Login", ReplyAction="http://tempuri.org/IWSMovilPosicionService/LoginResponse")]
        bool Login(string UserName, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWSMovilPosicionService/Logout", ReplyAction="http://tempuri.org/IWSMovilPosicionService/LogoutResponse")]
        Connector_sample_XML.KFTMovilPosicion.TypeKFTReturn Logout();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWSMovilPosicionService/isLoginDone", ReplyAction="http://tempuri.org/IWSMovilPosicionService/isLoginDoneResponse")]
        Connector_sample_XML.KFTMovilPosicion.TypeKFTReturn isLoginDone();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWSMovilPosicionService/InsertDataXML", ReplyAction="http://tempuri.org/IWSMovilPosicionService/InsertDataXMLResponse")]
        string InsertDataXML(string xml);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWSMovilPosicionServiceChannel : Connector_sample_XML.KFTMovilPosicion.IWSMovilPosicionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WSMovilPosicionServiceClient : System.ServiceModel.ClientBase<Connector_sample_XML.KFTMovilPosicion.IWSMovilPosicionService>, Connector_sample_XML.KFTMovilPosicion.IWSMovilPosicionService {
        
        public WSMovilPosicionServiceClient() {
        }
        
        public WSMovilPosicionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WSMovilPosicionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSMovilPosicionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WSMovilPosicionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Login(string UserName, string Password) {
            return base.Channel.Login(UserName, Password);
        }
        
        public Connector_sample_XML.KFTMovilPosicion.TypeKFTReturn Logout() {
            return base.Channel.Logout();
        }
        
        public Connector_sample_XML.KFTMovilPosicion.TypeKFTReturn isLoginDone() {
            return base.Channel.isLoginDone();
        }
        
        public string InsertDataXML(string xml) {
            return base.Channel.InsertDataXML(xml);
        }
    }
}
