﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MXit.ExternalApp.ExternalAppAPI {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
    [System.SerializableAttribute()]
    public partial class CommsError : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClientType", Namespace="http://schemas.datacontract.org/2004/07/MXit.User")]
    public enum ClientType : short {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unknown = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        JavaMe = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        JavaMeLite = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WindowsMobile = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IPhone = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Blackberry = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Android = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LibPurple = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Evo = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Web = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Bada = 10,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Daxtop = 11,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ThirdParty = 12,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        WindowsPhone7 = 13,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Wap = 14,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ServerEventType", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
    public enum ServerEventType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ServerIsShuttingDown = 0,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.mxit.com/wcf.ExternalAppComms", ConfigurationName="ExternalAppAPI.Comms", CallbackContract=typeof(MXit.ExternalApp.ExternalAppAPI.CommsCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface Comms {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/Version", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/VersionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/VersionCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        System.Version Version();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RecommendedSdkVersion", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/RecommendedSdkVersionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RecommendedSdkVersionCommsErrorFau" +
            "lt", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        System.Version RecommendedSdkVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/Connect", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/ConnectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/ConnectCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        void Connect(string externalAppName, string externalAppPassword, MXit.SDK externalAppSdk);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/Disconnect", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/DisconnectResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/DisconnectCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        void Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/IsOnline", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/IsOnlineResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/IsOnlineCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        bool IsOnline();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/KeepAlive", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/KeepAliveResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/KeepAliveCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        void KeepAlive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/GetUser", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/GetUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/GetUserCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        MXit.User.UserInfo GetUser(string UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/SendMessage", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/SendMessageResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/SendMessageCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        void SendMessage(MXit.Messaging.MessageToSend message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RegisterImageStrip", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/RegisterImageStripResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RegisterImageStripCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        MXit.Messaging.MessageElements.ImageStripReference RegisterImageStrip(string name, System.Drawing.Bitmap image, int frameWidth, int frameHeight, int layer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RedirectUser", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/RedirectUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RedirectUserCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        void RedirectUser(MXit.Navigation.RedirectRequest redirectRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RequestPayment", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/RequestPaymentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/RequestPaymentCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        void RequestPayment(MXit.Billing.PaymentRequest paymentRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/ConfirmPayment", ReplyAction="http://www.mxit.com/wcf.ExternalAppComms/Comms/ConfirmPaymentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(MXit.ExternalApp.ExternalAppAPI.CommsError), Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/ConfirmPaymentCommsErrorFault", Name="CommsError", Namespace="http://schemas.datacontract.org/2004/07/MXit.ExternalAppAPI")]
        System.Nullable<long> ConfirmPayment(System.Nullable<int> vendorId, string transactionReference);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CommsCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/OnMessageReceived")]
        void OnMessageReceived(MXit.Messaging.MessageReceived messageReceived);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/OnFileReceived")]
        void OnFileReceived(MXit.Messaging.FileReceived fileReceived);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/OnPresenceReceived")]
        void OnPresenceReceived(MXit.User.Presence userPresence);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/OnPaymentResponseReceived")]
        void OnPaymentResponseReceived(MXit.Billing.PaymentResponse paymentResponse);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/OnNotificationReceived")]
        void OnNotificationReceived(string message, MXit.Log.Level level);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://www.mxit.com/wcf.ExternalAppComms/Comms/OnServerEvent")]
        void OnServerEvent(MXit.ExternalApp.ExternalAppAPI.ServerEventType serverEventType);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CommsChannel : MXit.ExternalApp.ExternalAppAPI.Comms, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommsClient : System.ServiceModel.DuplexClientBase<MXit.ExternalApp.ExternalAppAPI.Comms>, MXit.ExternalApp.ExternalAppAPI.Comms {
        
        public CommsClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CommsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CommsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CommsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CommsClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Version Version() {
            return base.Channel.Version();
        }
        
        public System.Version RecommendedSdkVersion() {
            return base.Channel.RecommendedSdkVersion();
        }
        
        public void Connect(string externalAppName, string externalAppPassword, MXit.SDK externalAppSdk) {
            base.Channel.Connect(externalAppName, externalAppPassword, externalAppSdk);
        }
        
        public void Disconnect() {
            base.Channel.Disconnect();
        }
        
        public bool IsOnline() {
            return base.Channel.IsOnline();
        }
        
        public void KeepAlive() {
            base.Channel.KeepAlive();
        }
        
        public MXit.User.UserInfo GetUser(string UserId) {
            return base.Channel.GetUser(UserId);
        }
        
        public void SendMessage(MXit.Messaging.MessageToSend message) {
            base.Channel.SendMessage(message);
        }
        
        public MXit.Messaging.MessageElements.ImageStripReference RegisterImageStrip(string name, System.Drawing.Bitmap image, int frameWidth, int frameHeight, int layer) {
            return base.Channel.RegisterImageStrip(name, image, frameWidth, frameHeight, layer);
        }
        
        public void RedirectUser(MXit.Navigation.RedirectRequest redirectRequest) {
            base.Channel.RedirectUser(redirectRequest);
        }
        
        public void RequestPayment(MXit.Billing.PaymentRequest paymentRequest) {
            base.Channel.RequestPayment(paymentRequest);
        }
        
        public System.Nullable<long> ConfirmPayment(System.Nullable<int> vendorId, string transactionReference) {
            return base.Channel.ConfirmPayment(vendorId, transactionReference);
        }
    }
}
