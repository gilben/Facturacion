using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AD = Microsoft.ApplicationBlocks.Data.SqlHelper;

namespace SistemaFacturacion.Clases
{
    public class clsConexion
    {
        private static SqlConnection Connection = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["strConexion"].ToString());


   


        public DataSet ConsultasCombos(int Parametro)
        {
           return AD.ExecuteDataset(Connection, "paConsultas", Parametro);
        }


    }
}
