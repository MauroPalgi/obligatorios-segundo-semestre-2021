
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceActividades
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IIServicioActividades" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioActividades
    {
        [OperationContract]
        List<Actividad> GetAll();
    }

    [DataContract]
    public class Actividad
    {
        int codigoAct;

        [DataMember]
        public int CodigoAct
        {
            get { return codigoAct; }
            set { codigoAct = value; }
        }
        string nombre;

        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        DateTime horaComienzo;

        [DataMember]
        public DateTime HoraComienzo
        {
            get { return horaComienzo; }
            set { horaComienzo = value; }
        }



    }
}