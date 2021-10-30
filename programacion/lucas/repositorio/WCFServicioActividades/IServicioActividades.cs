using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServicioActividades
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioActividades" in both code and config file together.
    [ServiceContract]
    public interface IServicioActividades
    {
        [OperationContract]
        List<Actividad> GetAll();

        [OperationContract]
        Actividad GetActividad(int id);

        [OperationContract]
        Actividad UpdateCupoActividad(int id, int cupo);
    }
    [DataContract]
    public class Actividad
    {
        int codigoAct;
        string nombre;
        DateTime horaComienzo;
        int cupoActual;
        int cupoTotal;
        int minEdad;
        int maxEdad;

        [DataMember]
        public int CodigoAct
        {
            get { return codigoAct; }
            set { codigoAct = value; }
        }


        [DataMember]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        [DataMember]
        public DateTime HoraComienzo
        {
            get { return horaComienzo; }
            set { horaComienzo = value; }
        }

        [DataMember]
        public int CupoActual
        {
            get { return cupoActual; }
            set { cupoActual = value; }
        }

        [DataMember]
        public int CupoTotal
        {
            get { return cupoTotal; }
            set { cupoTotal = value; }
        }

        [DataMember]
        public int MinEdad
        {
            get { return minEdad; }
            set { minEdad = value; }
        }

        [DataMember]
        public int MaxEdad
        {
            get { return maxEdad; }
            set { maxEdad = value; }
        }


    }
}
