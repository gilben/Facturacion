using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace SistemaFacturacion.Clases
{
    class ProcesaDatos
    {
        public static DataTable ProcesarFactura(string strProcedimiento, object[] valores, DataTable dtDetalle)
        {
            
            try
            {
             
               

                DataTable data = new DataTable();
                //SqlConnection con = new SqlConnection(Clases.clsConexion.Connection);
                SqlCommand cmd = new SqlCommand(strProcedimiento, Clases.clsConexion.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParamIdDocumento = cmd.Parameters.Add("@NumDocumento", valores[0]);
                SqlParameter sqlParamIdCompania = cmd.Parameters.Add("@CodVendedor", valores[1]);
                SqlParameter sqlParamNumeroDocumento = cmd.Parameters.Add("@NitCliente", valores[2]);
                SqlParameter sqlParamIdParametrosDocumentoContable = cmd.Parameters.Add("@Resolucion", valores[3]);
                SqlParameter sqlParamIdTipoDocumentoContable = cmd.Parameters.Add("@TipoDocumento", valores[4]);
                SqlParameter sqlParamIdTipoFactura = cmd.Parameters.Add("@idCompania", valores[5]);
                SqlParameter sqlParamComentario = cmd.Parameters.Add("@comentarios", valores[6]);
                SqlParameter sqlParamVlrIva = cmd.Parameters.Add("@ValorIva", valores[7]);
                SqlParameter sqlParamSubTOtal = cmd.Parameters.Add("@SubTotal", valores[8]);
                SqlParameter sqlParamtotal = cmd.Parameters.Add("@Total", valores[9]);
                SqlParameter sqlParamBaseGravada = cmd.Parameters.Add("@BaseGravada", valores[10]);
                SqlParameter sqlParamDescuento = cmd.Parameters.Add("@Descuento", valores[11]);
                SqlParameter sqlParamFechaven = cmd.Parameters.Add("@FechaVEncimiento", valores[12]);
                SqlParameter sqlParamFechaFac = cmd.Parameters.Add("@FechaFactura", valores[13]);



                SqlParameter sqlParamDetalle = cmd.Parameters.AddWithValue("@DetalleFac", dtDetalle);
 
                sqlParamDetalle.SqlDbType = SqlDbType.Structured;
     
                SqlDataAdapter datap = new SqlDataAdapter(cmd);
                datap.Fill(data);
                return data;

               

            }
            catch (Exception Error)
            {
                throw Error;
                Clases.clsConexion.Connection.Close();
            }


        
    }

}
}
