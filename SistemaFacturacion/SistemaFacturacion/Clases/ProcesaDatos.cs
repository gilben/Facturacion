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
                SqlParameter sqlParamNumeroDocumento = cmd.Parameters.Add("@IdCliente", valores[2]);
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



        public static DataTable ProcesarClientes(string strProcedimiento, object[] valores, DataTable dtDirecciones)
        {

            try
            {

                DataTable data = new DataTable();
                //SqlConnection con = new SqlConnection(Clases.clsConexion.Connection);
                SqlCommand cmd = new SqlCommand(strProcedimiento, Clases.clsConexion.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParamId = cmd.Parameters.Add("@IdCliente", valores[0]);
                SqlParameter sqlParamNit = cmd.Parameters.Add("@Nit", valores[1]);
                SqlParameter sqlParamRazonSocial = cmd.Parameters.Add("@RazonSocial", valores[2]);
                SqlParameter sqlParamNombre = cmd.Parameters.Add("@Nombre", valores[3]);
                SqlParameter sqlParamEmail = cmd.Parameters.Add("@Email", valores[4]);
                SqlParameter sqlParamContacto = cmd.Parameters.Add("@Contacto", valores[5]);
                SqlParameter sqlParamTel1 = cmd.Parameters.Add("@Telefono1", valores[6]);
                SqlParameter sqlParamTel2= cmd.Parameters.Add("@Telefono2", valores[7]);
                SqlParameter sqlParamCel = cmd.Parameters.Add("@Celular", valores[8]);
                SqlParameter sqlParamEstado = cmd.Parameters.Add("@Estado", valores[9]);


                SqlParameter sqlParamDetalle = cmd.Parameters.AddWithValue("@Direccion", dtDirecciones);

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


        public static DataTable ProcesarInsumos(string strProcedimiento, object[] valores)
        {

            try
            {

                DataTable data = new DataTable();
                //SqlConnection con = new SqlConnection(Clases.clsConexion.Connection);
                SqlCommand cmd = new SqlCommand(strProcedimiento, Clases.clsConexion.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParamIdDocumento = cmd.Parameters.Add("@codigoInsumo", valores[0]);
                SqlParameter sqlParamIdCompania = cmd.Parameters.Add("@NombreInsumo", valores[1]);
                SqlParameter sqlParamNumeroDocumento = cmd.Parameters.Add("@CantidadActual", valores[2]);
                SqlParameter sqlParamDirCliente = cmd.Parameters.Add("@IdUnidadMedida", valores[3]);
                SqlParameter sqlParamIdParametrosDocumentoContable = cmd.Parameters.Add("@Precio", valores[4]);
                SqlParameter sqlParamIdTipoDocumentoContable = cmd.Parameters.Add("@Iva", valores[5]);
                SqlParameter sqlParamIdTipoFactura = cmd.Parameters.Add("@IdTipoInsumo", valores[6]);
               
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










        public DataSet ConsultasCombos(string ProcedimientoAlmacenado, object[] Parametros)
        {
            return AD.ExecuteDataset(clsConexion.Connection, ProcedimientoAlmacenado, Parametros);
        }

        public DataSet ConsultasCombos(string ProcedimientoAlmacenado, string Parametros)
        {
            return AD.ExecuteDataset(clsConexion.Connection, ProcedimientoAlmacenado, Parametros);
        }

        public DataSet ConsultasCombos(string ProcedimientoAlmacenado)
        {
            return AD.ExecuteDataset(Clases.clsConexion.Connection, ProcedimientoAlmacenado);
        }

        public DataSet ProcesarDatos(string ProcedimientoAlmacenado, object[] Parametros)
        {
            return AD.ExecuteDataset(Clases.clsConexion.Connection, ProcedimientoAlmacenado,Parametros);
        }
    }



}
