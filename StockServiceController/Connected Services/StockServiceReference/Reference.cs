﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockServiceController.StockServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Stock", Namespace="http://schemas.datacontract.org/2004/07/StockServiceLibrary.DataContract")]
    [System.SerializableAttribute()]
    public partial class Stock : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CloseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal CloseTypedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateTypedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HighField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LowField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OpenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SymbolField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VolumeField;
        
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
        public string Close {
            get {
                return this.CloseField;
            }
            set {
                if ((object.ReferenceEquals(this.CloseField, value) != true)) {
                    this.CloseField = value;
                    this.RaisePropertyChanged("Close");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal CloseTyped {
            get {
                return this.CloseTypedField;
            }
            set {
                if ((this.CloseTypedField.Equals(value) != true)) {
                    this.CloseTypedField = value;
                    this.RaisePropertyChanged("CloseTyped");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Date {
            get {
                return this.DateField;
            }
            set {
                if ((object.ReferenceEquals(this.DateField, value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DateTyped {
            get {
                return this.DateTypedField;
            }
            set {
                if ((this.DateTypedField.Equals(value) != true)) {
                    this.DateTypedField = value;
                    this.RaisePropertyChanged("DateTyped");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string High {
            get {
                return this.HighField;
            }
            set {
                if ((object.ReferenceEquals(this.HighField, value) != true)) {
                    this.HighField = value;
                    this.RaisePropertyChanged("High");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Low {
            get {
                return this.LowField;
            }
            set {
                if ((object.ReferenceEquals(this.LowField, value) != true)) {
                    this.LowField = value;
                    this.RaisePropertyChanged("Low");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Open {
            get {
                return this.OpenField;
            }
            set {
                if ((object.ReferenceEquals(this.OpenField, value) != true)) {
                    this.OpenField = value;
                    this.RaisePropertyChanged("Open");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Symbol {
            get {
                return this.SymbolField;
            }
            set {
                if ((object.ReferenceEquals(this.SymbolField, value) != true)) {
                    this.SymbolField = value;
                    this.RaisePropertyChanged("Symbol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Time {
            get {
                return this.TimeField;
            }
            set {
                if ((object.ReferenceEquals(this.TimeField, value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Volume {
            get {
                return this.VolumeField;
            }
            set {
                if ((object.ReferenceEquals(this.VolumeField, value) != true)) {
                    this.VolumeField = value;
                    this.RaisePropertyChanged("Volume");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="QueueMessage", Namespace="http://schemas.datacontract.org/2004/07/StockServiceLibrary.DataContract")]
    [System.SerializableAttribute()]
    public partial class QueueMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StockServiceReference.IStockService")]
    public interface IStockService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetStock", ReplyAction="http://tempuri.org/IStockService/GetStockResponse")]
        StockServiceController.StockServiceReference.Stock GetStock(string stock_cod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetStock", ReplyAction="http://tempuri.org/IStockService/GetStockResponse")]
        System.Threading.Tasks.Task<StockServiceController.StockServiceReference.Stock> GetStockAsync(string stock_cod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/SendMessage", ReplyAction="http://tempuri.org/IStockService/SendMessageResponse")]
        StockServiceController.StockServiceReference.QueueMessage SendMessage(string message, string queue, string exchange, string user_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/SendMessage", ReplyAction="http://tempuri.org/IStockService/SendMessageResponse")]
        System.Threading.Tasks.Task<StockServiceController.StockServiceReference.QueueMessage> SendMessageAsync(string message, string queue, string exchange, string user_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetMessages", ReplyAction="http://tempuri.org/IStockService/GetMessagesResponse")]
        System.Collections.Generic.List<string> GetMessages(string queue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/GetMessages", ReplyAction="http://tempuri.org/IStockService/GetMessagesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetMessagesAsync(string queue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/ToByteArray", ReplyAction="http://tempuri.org/IStockService/ToByteArrayResponse")]
        byte[] ToByteArray(StockServiceController.StockServiceReference.QueueMessage obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/ToByteArray", ReplyAction="http://tempuri.org/IStockService/ToByteArrayResponse")]
        System.Threading.Tasks.Task<byte[]> ToByteArrayAsync(StockServiceController.StockServiceReference.QueueMessage obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/FromByteArray", ReplyAction="http://tempuri.org/IStockService/FromByteArrayResponse")]
        StockServiceController.StockServiceReference.QueueMessage FromByteArray(byte[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStockService/FromByteArray", ReplyAction="http://tempuri.org/IStockService/FromByteArrayResponse")]
        System.Threading.Tasks.Task<StockServiceController.StockServiceReference.QueueMessage> FromByteArrayAsync(byte[] data);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStockServiceChannel : StockServiceController.StockServiceReference.IStockService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockServiceClient : System.ServiceModel.ClientBase<StockServiceController.StockServiceReference.IStockService>, StockServiceController.StockServiceReference.IStockService {
        
        public StockServiceClient() {
        }
        
        public StockServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public StockServiceController.StockServiceReference.Stock GetStock(string stock_cod) {
            return base.Channel.GetStock(stock_cod);
        }
        
        public System.Threading.Tasks.Task<StockServiceController.StockServiceReference.Stock> GetStockAsync(string stock_cod) {
            return base.Channel.GetStockAsync(stock_cod);
        }
        
        public StockServiceController.StockServiceReference.QueueMessage SendMessage(string message, string queue, string exchange, string user_name) {
            return base.Channel.SendMessage(message, queue, exchange, user_name);
        }
        
        public System.Threading.Tasks.Task<StockServiceController.StockServiceReference.QueueMessage> SendMessageAsync(string message, string queue, string exchange, string user_name) {
            return base.Channel.SendMessageAsync(message, queue, exchange, user_name);
        }
        
        public System.Collections.Generic.List<string> GetMessages(string queue) {
            return base.Channel.GetMessages(queue);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<string>> GetMessagesAsync(string queue) {
            return base.Channel.GetMessagesAsync(queue);
        }
        
        public byte[] ToByteArray(StockServiceController.StockServiceReference.QueueMessage obj) {
            return base.Channel.ToByteArray(obj);
        }
        
        public System.Threading.Tasks.Task<byte[]> ToByteArrayAsync(StockServiceController.StockServiceReference.QueueMessage obj) {
            return base.Channel.ToByteArrayAsync(obj);
        }
        
        public StockServiceController.StockServiceReference.QueueMessage FromByteArray(byte[] data) {
            return base.Channel.FromByteArray(data);
        }
        
        public System.Threading.Tasks.Task<StockServiceController.StockServiceReference.QueueMessage> FromByteArrayAsync(byte[] data) {
            return base.Channel.FromByteArrayAsync(data);
        }
    }
}
