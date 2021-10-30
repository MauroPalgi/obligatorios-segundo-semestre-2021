using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;

namespace DAL
{
    public class DALActividad: DALBase
    {
        public static SqlDataReader select_All()
        {
            string StoredProcedure = "SELECT_ALL_ACTIVIDADES";
            SqlDataReader dr = select(null, StoredProcedure, CommandType.StoredProcedure);
            return dr;
        }

        
        public static SqlDataReader select_byId(int id)
        {
            SqlParameter param = new SqlParameter();
            param.Value = id;
            param.ParameterName = "Id";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(param);
            string StoreProcedure = "[SELECT_ACTIVIDADESById]";
            SqlDataReader dr = select(parameters, StoreProcedure, CommandType.StoredProcedure);
            return dr;
        }
        
        public static SqlDataReader update_byId(int id, int cupoActual)
        {
            // ID
            SqlParameter idParam = new SqlParameter();
            idParam.Value = id;
            idParam.ParameterName = "CodigoAct";
            // CUPOACTUAL
            SqlParameter cupoParam = new SqlParameter();
            cupoParam.Value = cupoActual - 1;
            cupoParam.ParameterName = "CupoActual";
           
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(idParam);         
            parameters.Add(cupoParam);                     
            string StoreProcedure = "[UPDATE_ACTIVIDAD]";
            SqlDataReader dr = select(parameters, StoreProcedure, CommandType.StoredProcedure);
            return dr;
        }
    }
}
