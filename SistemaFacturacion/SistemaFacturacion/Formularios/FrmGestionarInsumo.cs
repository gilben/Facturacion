using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.Formularios
{
    public partial class FrmGestionarInsumo : Form
    {
        string CodigoInsumo_="0";
        Clases.ProcesaDatos pd = new Clases.ProcesaDatos();
        Clases.clsUtilidades Utilidades = new Clases.clsUtilidades();
        DataSet ds;
        DataTable dt;

        public FrmGestionarInsumo(string CodigoInsumo)
        {
            CodigoInsumo_ = CodigoInsumo;
            InitializeComponent();
        }

        public FrmGestionarInsumo()
        {
        
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
         
            
        }

        private void FrmGestionarInsumo_Load(object sender, EventArgs e)
        {
            if (CodigoInsumo_ != "0")
            {
                ObtenerDatos();
                gbInsumo.Text = "Editar Insumo/Servicio";
                
            } else
            {
                ds = pd.ConsultasCombos("PaConsultas", "2");
                txtCodigo.Text = ds.Tables[0].Rows[0]["MaxInsumo"].ToString();

                cbbIva.DataSource = ds.Tables[1];
                cbbIva.DisplayMember = "IVA";
                cbbIva.ValueMember = "IdIva";
                //cbbIva.Text = ds.Tables[0].Rows[0]["Iva"].ToString();
                cbbUnidadMedida.DataSource = ds.Tables[2];
                cbbUnidadMedida.DisplayMember = "NombreUM";
                cbbUnidadMedida.ValueMember = "IdUnidad";
                //cbbUnidadMedida.Text = ds.Tables[0].Rows[0]["UM"].ToString();
                cbbTipo.DataSource = ds.Tables[3];
                cbbTipo.DisplayMember = "Nombre";
                cbbTipo.ValueMember = "IdTipo";
                //cbbTipo.Text = ds.Tables[0].Rows[0]["Tipo"].ToString();
                gbInsumo.Text = "Crear Nuevo Insumo/Servicio";
            }
          


        }


        private void ObtenerDatos()
        {
            try
            {
                ds = pd.ConsultasCombos("paConsultasConParametros", new object[] { 1, CodigoInsumo_ });

                txtCodigo.Text = CodigoInsumo_;
               
                txtCodigo.Enabled = false;
                txtDescripcion.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                txtPrecio.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
                txtCantidadActual.Text = ds.Tables[0].Rows[0]["CantidadActual"].ToString();
                cbbIva.DataSource = ds.Tables[1];
                cbbIva.DisplayMember = "IVA";
                cbbIva.ValueMember = "IdIva";
                cbbIva.Text = ds.Tables[0].Rows[0]["Iva"].ToString();
                cbbUnidadMedida.DataSource = ds.Tables[2];
                cbbUnidadMedida.DisplayMember = "NombreUM";
                cbbUnidadMedida.ValueMember = "IdUnidad";
                cbbUnidadMedida.Text = ds.Tables[0].Rows[0]["UM"].ToString();
                cbbTipo.DataSource = ds.Tables[3];
                cbbTipo.DisplayMember = "Nombre";
                cbbTipo.ValueMember = "IdTipo";
                cbbTipo.Text = ds.Tables[0].Rows[0]["Tipo"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        private bool ValidarInsumo()
        {
            if (txtDescripcion.Text == "")
            {
                errorProvider1.SetError(txtDescripcion, "Este campo no puede estar vacio");
               // MessageBox.Show("El campo descripcion es obligatorio", "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescripcion.Focus();
                return true;
            }
            else { errorProvider1.Clear(); }
            if (txtPrecio.Text == "")
            {
                errorProvider1.SetError(txtPrecio, "Este campo no puede estar vacio");
                //MessageBox.Show("El campo Precio es obligatorio", "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecio.Focus();
                return true;
            }else { errorProvider1.Clear(); }
            if(txtCantidadActual.Text=="")
            {
                errorProvider1.SetError(txtCantidadActual, "Este campo no puede estar vacio");
                return true;
            }
            else { errorProvider1.Clear(); }
            return false;

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarInsumo())
                    return;

                dt = Clases.ProcesaDatos.ProcesarInsumos("paInsertarActualizarInsumo", new object[] { txtCodigo.Text, txtDescripcion.Text, decimal.Parse(txtCantidadActual.Text), cbbUnidadMedida.SelectedValue,  double.Parse(txtPrecio.Text), cbbIva.GetItemText(cbbIva.SelectedItem), cbbTipo.SelectedValue });

                if (dt.Rows[0][0].ToString() == "ok")
                {
                    MessageBox.Show("Insumo/servicio Procesado exitosamente", "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }else
                {
                    MessageBox.Show("Ocurrio un error al insertar los datos: " + dt.Rows[0][0].ToString(), "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio un error durante el proceso"+ex, "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            FrmMaestros obj = (FrmMaestros)Application.OpenForms["FrmMaestros"];
            obj.Refreshdata();
        


        }



        private void txtDescripcion_Validated(object sender, EventArgs e)
        {

            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            Utilidades.ValidaNumeros(txtPrecio,new object[] {".","," } );
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
           // if (txtPrecio.Text == "")
           //     return;
           //decimal _txtPrecio= decimal.Parse( txtPrecio.Text);
           // txtPrecio.Text = _txtPrecio.ToString("N");
        }

     
    }
}


