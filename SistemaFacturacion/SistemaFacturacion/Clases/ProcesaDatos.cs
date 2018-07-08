using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using AD = Microsoft.ApplicationBlocks.Data.SqlHelper;


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
                SqlParameter sqlParamDirCliente = cmd.Parameters.Add("@IdDireccionCliente", valores[3]);
                SqlParameter sqlParamIdParametrosDocumentoContable = cmd.Parameters.Add("@Resolucion", valores[4]);
                SqlParameter sqlParamIdTipoDocumentoContable = cmd.Parameters.Add("@TipoDocumento", valores[5]);
                SqlParameter sqlParamIdTipoFactura = cmd.Parameters.Add("@idCompania", valores[6]);
                SqlParameter sqlParamComentario = cmd.Parameters.Add("@comentarios", valores[7]);
                SqlParameter sqlParamVlrIva = cmd.Parameters.Add("@ValorIva", valores[8]);
                SqlParameter sqlParamSubTOtal = cmd.Parameters.Add("@SubTotal", valores[9]);
                SqlParameter sqlParamtotal = cmd.Parameters.Add("@Total", valores[10]);
                SqlParameter sqlParamBaseGravada = cmd.Parameters.Add("@BaseGravada", valores[11]);
                SqlParameter sqlParamDescuento = cmd.Parameters.Add("@Descuento", valores[12]);
                SqlParameter sqlParamFechaven = cmd.Parameters.Add("@FechaVEncimiento", valores[13]);
                SqlParameter sqlParamFechaFac = cmd.Parameters.Add("@FechaFactura", valores[14]);



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
        public DataSet ConsultasCombos(string ProcedimientoAlmacenado, string Parametro)
        {
            return AD.ExecuteDataset(Clases.clsConexion.Connection, ProcedimientoAlmacenado, Parametro);
        }

        public DataSet ConsultasCombos(string ProcedimientoAlmacenado)
        {
            return AD.ExecuteDataset(Clases.clsConexion.Connection, ProcedimientoAlmacenado);
        }
    }



}
