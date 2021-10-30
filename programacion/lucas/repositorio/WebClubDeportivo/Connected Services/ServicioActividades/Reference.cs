﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebClubDeportivo.ServicioActividades {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Actividad", Namespace="http://schemas.datacontract.org/2004/07/WCFServicioActividades")]
    [System.SerializableAttribute()]
    public partial class Actividad : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoActField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CupoActualField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CupoTotalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime HoraComienzoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxEdadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MinEdadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
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
        public int CodigoAct {
            get {
                return this.CodigoActField;
            }
            set {
                if ((this.CodigoActField.Equals(value) != true)) {
                    this.CodigoActField = value;
                    this.RaisePropertyChanged("CodigoAct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CupoActual {
            get {
                return this.CupoActualField;
            }
            set {
                if ((this.CupoActualField.Equals(value) != true)) {
                    this.CupoActualField = value;
                    this.RaisePropertyChanged("CupoActual");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CupoTotal {
            get {
                return this.CupoTotalField;
            }
            set {
                if ((this.CupoTotalField.Equals(value) != true)) {
                    this.CupoTotalField = value;
                    this.RaisePropertyChanged("CupoTotal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime HoraComienzo {
            get {
                return this.HoraComienzoField;
            }
            set {
                if ((this.HoraComienzoField.Equals(value) != true)) {
                    this.HoraComienzoField = value;
                    this.RaisePropertyChanged("HoraComienzo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxEdad {
            get {
                return this.MaxEdadField;
            }
            set {
                if ((this.MaxEdadField.Equals(value) != true)) {
                    this.MaxEdadField = value;
                    this.RaisePropertyChanged("MaxEdad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MinEdad {
            get {
                return this.MinEdadField;
            }
            set {
                if ((this.MinEdadField.Equals(value) != true)) {
                    this.MinEdadField = value;
                    this.RaisePropertyChanged("MinEdad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioActividades.IServicioActividades")]
    public interface IServicioActividades {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioActividades/GetAll", ReplyAction="http://tempuri.org/IServicioActividades/GetAllResponse")]
        System.Collections.Generic.List<WebClubDeportivo.ServicioActividades.Actividad> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioActividades/GetAll", ReplyAction="http://tempuri.org/IServicioActividades/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<WebClubDeportivo.ServicioActividades.Actividad>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioActividades/GetActividad", ReplyAction="http://tempuri.org/IServicioActividades/GetActividadResponse")]
        WebClubDeportivo.ServicioActividades.Actividad GetActividad(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioActividades/GetActividad", ReplyAction="http://tempuri.org/IServicioActividades/GetActividadResponse")]
        System.Threading.Tasks.Task<WebClubDeportivo.ServicioActividades.Actividad> GetActividadAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioActividades/UpdateCupoActividad", ReplyAction="http://tempuri.org/IServicioActividades/UpdateCupoActividadResponse")]
        WebClubDeportivo.ServicioActividades.Actividad UpdateCupoActividad(int id, int cupo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioActividades/UpdateCupoActividad", ReplyAction="http://tempuri.org/IServicioActividades/UpdateCupoActividadResponse")]
        System.Threading.Tasks.Task<WebClubDeportivo.ServicioActividades.Actividad> UpdateCupoActividadAsync(int id, int cupo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioActividadesChannel : WebClubDeportivo.ServicioActividades.IServicioActividades, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioActividadesClient : System.ServiceModel.ClientBase<WebClubDeportivo.ServicioActividades.IServicioActividades>, WebClubDeportivo.ServicioActividades.IServicioActividades {
        
        public ServicioActividadesClient() {
        }
        
        public ServicioActividadesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioActividadesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioActividadesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioActividadesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<WebClubDeportivo.ServicioActividades.Actividad> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<WebClubDeportivo.ServicioActividades.Actividad>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public WebClubDeportivo.ServicioActividades.Actividad GetActividad(int id) {
            return base.Channel.GetActividad(id);
        }
        
        public System.Threading.Tasks.Task<WebClubDeportivo.ServicioActividades.Actividad> GetActividadAsync(int id) {
            return base.Channel.GetActividadAsync(id);
        }
        
        public WebClubDeportivo.ServicioActividades.Actividad UpdateCupoActividad(int id, int cupo) {
            return base.Channel.UpdateCupoActividad(id, cupo);
        }
        
        public System.Threading.Tasks.Task<WebClubDeportivo.ServicioActividades.Actividad> UpdateCupoActividadAsync(int id, int cupo) {
            return base.Channel.UpdateCupoActividadAsync(id, cupo);
        }
    }
}
