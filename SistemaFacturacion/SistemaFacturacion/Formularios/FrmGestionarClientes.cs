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
    public partial class FrmGestionarClientes : Form
    {
        string Nit_="",NitNvo_="";
        int idCliente_ = 0;
        bool validaCliente ;

        DataSet ds;
        DataTable dt;
        Clases.ProcesaDatos pd = new Clases.ProcesaDatos();
        public FrmGestionarClientes()
        {
            InitializeComponent();
        }
        public FrmGestionarClientes(string Nit,int Idcliente)
        {
            Nit_ = Nit;
            idCliente_ = Idcliente;
            InitializeComponent();
        }

        private void FrmGestionarClientes_Load(object sender, EventArgs e)
        {
            if(Nit_!="")
            {
                ObtenerDatos();
                ds = pd.ConsultasCombos("paConsultasConParametros", new object[] { 2, Nit_ });
                dgvDirecciones.DataSource = ds.Tables[1];
                this.dgvDirecciones.Columns["IdDireccion"].Visible = false;
                this.dgvDirecciones.Columns["Nit"].Visible = false;
              
               

            }
            else
            {
                btnEliminar.Enabled = false;
                txtNit.Select();
                rbActivo.Checked=true;

              
            }

           
        }
        private void ObtenerDatos()
        {
            try
            {
                ds = pd.ConsultasCombos("paConsultasConParametros", new object[] { 2, Nit_ });

                txtNit.Text = Nit_;
                // txtNit.Enabled = false;
                txtRz.Text = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
                txtNombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
                txtContacto.Text = ds.Tables[0].Rows[0]["Contacto"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtTel1.Text = ds.Tables[0].Rows[0]["Telefono1"].ToString();
                txtTel2.Text = ds.Tables[0].Rows[0]["Telefono2"].ToString();
                txtCel.Text = ds.Tables[0].Rows[0]["Celular"].ToString();

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Estado"].ToString()) == false)
                {


                    rbInactivo.Checked = true;
                }
                else
                {

                    rbActivo.Checked = true;
                }
                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
            


        }

 

        private void tabClientes_Selected(object sender, TabControlEventArgs e)
        {
            if (dgvDirecciones.Rows.Count == 0)
            {

                ds = pd.ConsultasCombos("paConsultasConParametros", new object[] { 2, Nit_ });
                dgvDirecciones.DataSource = ds.Tables[1];
                this.dgvDirecciones.Columns["IdDireccion"].Visible = false;
                this.dgvDirecciones.Columns["Nit"].Visible = false;
            }




        }

    

        private void txtRz_Validated(object sender, EventArgs e)
        {
            txtRz.Text = txtRz.Text.ToUpper();
        }

        private void txtNombre_Validated(object sender, EventArgs e)
        {
            txtNombre.Text = txtNombre.Text.ToUpper();
            
        }

        private void txtContacto_Validated(object sender, EventArgs e)
        {
            txtContacto.Text = txtContacto.Text.ToUpper();
        }

        private bool ValidarCLiente()
        {

            if (NitNvo_ != Nit_)
            {

                errorProvider1.Clear();
                dt = pd.ConsultasCombos("paConsultasConParametros", new object[] { 2, txtNit.Text }).Tables[0];


                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("El nit:" + dt.Rows[0][1].ToString() + " ya existe para el cliente: " + dt.Rows[0][2].ToString() + "", "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNit.Focus();
                    errorProvider1.SetError(txtNit, "El nit ya existe");
                    return true;
                }


            }
            
            if (txtNit.Text == "")
                {

                    errorProvider1.SetError(txtNit, "Campo obligatorio");
                    txtNit.Focus();
                    return true;

                }
            


        
            if ( txtRz.Text == "")
            {
                errorProvider1.SetError(txtRz, "Campo obligatorio");
                txtRz.Select();
                return true;

            }else
            {
                errorProvider1.Clear();
            }
             if(txtTel1.Text == "")
            {
                errorProvider1.SetError(txtTel1, "Campo obligatorio");
                txtTel1.Select();
                return true;
            }
            else
            {
                errorProvider1.Clear();
            }


          
            return false;
         
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarActualizarCliente();

        }

        private void GuardarActualizarCliente()
        {
            if (ValidarCLiente())
            {
                return;
            }
            tabClientes_Selecting(null, null);
            tabClientes_Selected(null, null);
            string btn;
            try
            {
                

                if (btnGuardar.Text == "Actualizar")
                {
                    btn = "Actualizado";
                }
                else
                {
                    btn = "Guardado";
                }

                if (Nit_ == "")
                {
                    Nit_ = txtNit.Text;
                }
                DataTable dt1 = (DataTable)dgvDirecciones.DataSource;
                //DataRow dr = dt.NewRow(); //ds.Tables[4].NewRow();

                for(int x = 0; x < dgvDirecciones.RowCount - 1; x++)
 {
                    if (dgvDirecciones.Rows[x].Cells[2].Value.ToString() == "")
                    {
                        dgvDirecciones.Rows.RemoveAt(x);
                        x--;
                    }
                }
                int i = 0;
                foreach (DataRow dr1 in dt1.Rows)
                {
                    //if (string.IsNullOrEmpty(dr1.ItemArray[2].ToString()))
                    //{

                    ////    dt1.Rows.RemoveAt(i);

                    ////    dt1.AcceptChanges();
                    ////}

                  
                  
                    if (string.IsNullOrEmpty(dr1.ItemArray[1].ToString()))
                    {

                        dt1.Rows[i][1] = Nit_;

                        dt1.AcceptChanges();
                    }
                   

                    i++;
                }

                bool rb = false;
                if (rbActivo.Checked)
                {
                    rb = true;
                }

                //if(dt1.Rows.Count>0)
                //{
                //    DataRow[] dr = dt1.Select("Direccion <>'' ");
                //    dt1 = dr.CopyToDataTable();
                //}
              



                DataTable dt = Clases.ProcesaDatos.ProcesarClientes("paInsertarActualizarClientes", new object[] { idCliente_,txtNit.Text, txtRz.Text, txtNombre.Text, txtEmail.Text, txtContacto.Text, txtTel1.Text, txtTel2.Text, txtCel.Text, rb }, dt1);//dts = Clases.ProcesaDatos.ProcesarFactura("paInsertarDatosFactura", new object[] { txtNumFac.Text, 1, cbbCliente.SelectedValue.ToString(), cbbSede.SelectedValue.ToString(), cbbResolucion.SelectedValue.ToString(), 1, cbbCompania.SelectedValue.ToString(), rtxComentarios.Text, Iva, Subtotal, Total, BaseGravable, Math.Round(Descuento, 27), dtpFechavencimento.Text, dtpFechaFactura.Text }, (DataTable)dgvInsumosFacturar.DataSource);


                if (dt.Rows[0][0].ToString() == "ok")
                {

                    MessageBox.Show(btn, "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form c = new FrmMaestros();
                    
                    this.Close();
                } else
                {
                    MessageBox.Show("Error:"+ dt.Rows[0][0].ToString(), "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex, "Sistema facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  




       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form f = new FrmMaestros();
           
            this.Close();

        }

        private void txtNit_Validated(object sender, EventArgs e)
        {
            //validaCliente= ValidarCLiente();
          

        }

   

        private void tabClientes_Selecting(object sender, TabControlCancelEventArgs e)
        {
           

            //if (btnGuardar.Text == "Actualizar")
            //    return;
       
            if (ValidarCLiente() )
            {
                e.Cancel = true;
            }
            //if (dgvDirecciones.Rows.Count == 0)
            //{

            //    ds = pd.ConsultasCombos("paConsultasConParametros", new object[] { 2, Nit_ });
            //    dgvDirecciones.DataSource = ds.Tables[1];
            //    this.dgvDirecciones.Columns["IdDireccion"].Visible = false;
            //    this.dgvDirecciones.Columns["Nit"].Visible = false;
            //}

        }

    

        private void txtNit_TextChanged(object sender, EventArgs e)
        {

            NitNvo_ = txtNit.Text;

          

        }
    }
}
