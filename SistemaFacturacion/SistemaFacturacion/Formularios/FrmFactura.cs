using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.Formularios
{
    public partial class FrmFactura : System.Windows.Forms.Form
    {


        
      

        
        public FrmFactura()
        {
            InitializeComponent();
          
        }

        DataTable dt;
        DataSet ds;
        DataTable dts;
        DataView dtv = new DataView();
        string FacActual;
        Clases.clsUtilidades Utilidades = new Clases.clsUtilidades();
        Clases.ProcesaDatos pd = new Clases.ProcesaDatos();
        bool calcula = false;






        private void FrmFactura_Load(object sender, EventArgs e)
        {

            CargarCombos();
            dtpFechaFactura.Format = DateTimePickerFormat.Custom;
            //dtpFechaFactura.CustomFormat = "MM/dd/yyyy";
            dtpFechaFactura.CustomFormat = "dd/MM/yyyy";
            dtpFechavencimento.Format = DateTimePickerFormat.Custom;
             //dtpFechavencimento.CustomFormat = "MM/dd/yyyy";
            dtpFechavencimento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFactura.Value = DateTime.Now;
            this.dtpFechavencimento.Value = DateTime.Now;
            WindowState = FormWindowState.Maximized;



        }

        private void Refresh()
        {
            ds = pd.ConsultasCombos("paConsultas", "0");
            //string[] s = ds.Tables[1].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();

            cbbResolucion.DataSource = ds.Tables[0];
            cbbResolucion.ValueMember = "NumeroResolucion";
            this.cbbResolucion.AutoCompleteCustomSource.AddRange(ds.Tables[0].Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray());
            this.cbbResolucion.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbbResolucion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //this.cbbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //this.cbbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            // dtv = new DataView(ds.Tables[1]);
            //dtv.Sort = "RazonSocial ASC";
            //DataTable dt = dtv.ToTable();
            cbbCliente.DataSource = ds.Tables[1];
            cbbCliente.DisplayMember = "RazonSocial";
            cbbCliente.ValueMember = "IdCliente";
            cbbCliente.Text = "Seleccione un cliente";

            txtNumFac.Text = ds.Tables[2].Rows[0]["NumFac"].ToString();
            dgvInsumos.DataSource = ds.Tables[3];
            dgvInsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dgvInsumos.Columns["Precio"].DefaultCellStyle.FormatProvider= System.Globalization.CultureInfo.GetCultureInfo("en-us");
            //dgvInsumos.Columns["Precio"].DefaultCellStyle.Format =string.Format( "C");
            Utilidades.FormatearGrid(dgvInsumos, "Precio","C");

            cbbCompania.DataSource = ds.Tables[5];
            cbbCompania.DisplayMember = "RazonSocial";
            cbbCompania.ValueMember = "IdCompañia";

            cbbSede.Text = "";
            this.dtpFechaFactura.Value = DateTime.Now;
            this.dtpFechavencimento.Value = DateTime.Now;
            textBox1.Text = "";
            errorProvider1.Clear();



        }

        private void CargarCombos()
        {
            try
            {
                ds = pd.ConsultasCombos("paConsultas", "0");
                //string[] s = ds.Tables[1].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();

                cbbResolucion.DataSource = ds.Tables[0];
                cbbResolucion.ValueMember = "NumeroResolucion";
                this.cbbResolucion.AutoCompleteCustomSource.AddRange(ds.Tables[0].Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray());
                this.cbbResolucion.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cbbResolucion.AutoCompleteSource = AutoCompleteSource.CustomSource;



                //this.cbbCliente.AutoCompleteCustomSource.AddRange(ds.Tables[1].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray());
                //autocompleta combox
                //this.cbbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cbbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
                //DataView dtv = new DataView(ds.Tables[1]);
                //dtv.Sort = "RazonSocial ASC";
                //DataTable dt = dtv.ToTable();
                cbbCliente.DataSource =ds.Tables[1];
                cbbCliente.DisplayMember = "RazonSocial";
                cbbCliente.ValueMember = "IdCliente";
                cbbCliente.Text = "Seleccione un cliente";

            

                //listBox1.DataSource = dt;
                //listBox1.DisplayMember = "RazonSocial";
                //listBox1.ValueMember = "Nit";


                txtNumFac.Text = ds.Tables[2].Rows[0]["NumFac"].ToString();
                dgvInsumos.DataSource = ds.Tables[3];
                dgvInsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                //dgvInsumos.Columns["Precio"].DefaultCellStyle.FormatProvider= System.Globalization.CultureInfo.GetCultureInfo("en-us");
                //dgvInsumos.Columns["Precio"].DefaultCellStyle.Format =string.Format( "C");
                Utilidades.FormatearGrid(dgvInsumos, "Precio", "C");
                Utilidades.AlinearContenidoColumna(dgvInsumos);

                //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                //BindingSource bs1 = new BindingSource();
                //bs1.DataSource = ds.Tables[6];
                //cmb.DataPropertyName = "NombreUM";
                //cmb.HeaderText = "UnidadMedida";
                //cmb.Width = 120;
                //cmb.DataSource = bs1;
                //cmb.ValueMember = "NombreUM";
                //cmb.DisplayMember = "NombreUM";

                //dgvInsumos.Columns.Insert(2, cmb);
                dgvInsumosFacturar.DataSource = ds.Tables[4];


                cbbCompania.DataSource = ds.Tables[5];
                cbbCompania.DisplayMember = "RazonSocial";
                cbbCompania.ValueMember = "IdCompañia";

                cbbSede.DataSource = null;

                //dgvInsumosFacturar.Columns.Add("CodigoInsumo", "CodigoInsumo");
                //dgvInsumosFacturar.Columns.Add("Descripcion", "Descripcion");
                //dgvInsumosFacturar.Columns.Add("Iva", "Iva");
                //dgvInsumosFacturar.Columns.Add("Cantidad", "Cantidad");
                //dgvInsumosFacturar.Columns.Add("VlrUnitario", "VlrUnitario");
                //dgvInsumosFacturar.Columns.Add("VlrIva", "VlrIva");
                //dgvInsumosFacturar.Columns.Add("VlrBruto", "VlrBruto");
                //dgvInsumosFacturar.Columns.Add("VlrTotal", "VlrTotal");
                txtDescuento.Text = "0";
                rtxComentarios.Text = "";
         
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
         


        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Busca en grid

                string Dato = textBox1.Text;
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvInsumos.DataSource;
                // string filtro = string.Format($"(Nombre ={s})");
                bs.Filter = "[Producto/servicio] LIKE '%" + Dato + "%' OR CodigoInsumo LIKE '%" + Dato + "%' ";
                dgvInsumos.DataSource = bs;




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void dgvInsumos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           

            int row = dgvInsumos.CurrentCell.RowIndex;


            if (string.IsNullOrEmpty(dgvInsumos.Rows[row].Cells["Cantidad"].Value.ToString()))
            {
                MessageBox.Show("La cntidad no puede estar vacia", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int RowsDt = ds.Tables[4].Rows.Count;

            foreach (DataRow rows in ds.Tables[4].Rows)
            {
                if (rows[0].ToString() == dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value.ToString())
                {
                    MessageBox.Show("El insumo '"+ rows[0].ToString() + "' ya esta en la lista para facturar", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


            }


            double Bruto = Convert.ToDouble(dgvInsumos.Rows[row].Cells["Cantidad"].Value) * Convert.ToDouble(dgvInsumos.Rows[row].Cells["Precio"].Value);
            double VlrIva = (Bruto* Convert.ToDouble(dgvInsumos.Rows[row].Cells["Iva"].Value)) / 100;
            double Total = Bruto+VlrIva;
            double VlrUnitario = Convert.ToDouble(dgvInsumos.Rows[row].Cells["Precio"].Value);//.ToString("c1", System.Globalization.CultureInfo.GetCultureInfo("en-us")));
            int Iva = Convert.ToInt16(dgvInsumos.Rows[row].Cells["Iva"].Value);

           


            DataRow dr = ds.Tables[4].NewRow();

            dr[0] = dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value;
            dr[1] = dgvInsumos.Rows[row].Cells["Producto/servicio"].Value;
            dr[2] = dgvInsumos.Rows[row].Cells["Cantidad"].Value;
            dr[3] = dgvInsumos.Rows[row].Cells["UM"].Value;
            dr[4] = Iva;
            dr[5] = VlrUnitario.ToString("N");//, System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[6] = VlrIva.ToString("N");//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[7] = Bruto.ToString("N");//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[8] = Total.ToString("N");//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));

        

            ds.Tables[4].Rows.InsertAt(dr, dgvInsumos.CurrentCell.RowIndex);
            dgvInsumosFacturar.DataSource = ds.Tables[4];
            Utilidades.AlinearContenidoColumna(dgvInsumosFacturar);




          


            //dgvInsumosFacturar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dgvInsumosFacturar.Rows.Add(dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value, dgvInsumos.Rows[row].Cells["Nombre"].Value,Iva, dgvInsumos.Rows[row].Cells["Cantidad"].Value, VlrUnitario.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")), VlrIva.ToString("c0",System.Globalization.CultureInfo.GetCultureInfo("en-us")), Bruto.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")), Total.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")));


            // Utilidades.FormatearGrid(dgvInsumosFacturar, "Iva");



            // Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrIva");
            //Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrBruto");
            //Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrTotal");


        }

        private void dgvInsumos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           

            if (dgvInsumos.CurrentCell.ColumnIndex == 2 || dgvInsumos.CurrentCell.ColumnIndex == 6)
            {
                dgvInsumos.BeginEdit(true);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ValidarControles())

            {
                return;
            }
            GuardarDocumento();
        }


        private void GuardarDocumento()
        {
            if (dgvInsumosFacturar.RowCount == 0)
            {
                MessageBox.Show("No hay datos para guardar", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                return;
            }

             Decimal Iva = 0, Subtotal = 0, Total = 0, Descuento = 0, BaseGravable = 0,SubtotalReal=0,sub=0;
            
            try
            {
               // Descuento = double.Parse(txtDescuento.Text);
                if (txtDescuento.Text.Contains("%"))
                {

                    Descuento = Decimal.Parse(txtDescuento.Text.Replace("%", ""));
                

                }
                else
                {
                    Decimal Subdescuento = 0;
                    foreach (DataGridViewRow row in dgvInsumosFacturar.Rows)
                    {

                        Subdescuento += (Decimal.Parse(row.Cells["VlrBruto"].Value.ToString()));
  
                    }
                    Descuento =(Decimal.Parse(txtDescuento.Text)/ Subdescuento)*100;
                    
                }
                if (Descuento > 100)
                {
                    MessageBox.Show("El porcentaje de descuento no puede superar el 100% ", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                foreach (DataGridViewRow row in dgvInsumosFacturar.Rows)
                {
                    SubtotalReal = 0;
                    SubtotalReal += (Decimal.Parse(row.Cells["VlrBruto"].Value.ToString()) - (Decimal.Parse(row.Cells["VlrBruto"].Value.ToString())*Descuento /100));
                    sub += SubtotalReal;
                    Iva += SubtotalReal * int.Parse(row.Cells["Iva"].Value.ToString()) / 100;                                                          //             double.Parse(row.Cells["VlrIva"].Value.ToString());
                    Subtotal += Decimal.Parse(row.Cells["VlrBruto"].Value.ToString());
                   
                                        //double.Parse(row.Cells["VlrTotal"].Value.ToString());
                    if (int.Parse(row.Cells["Iva"].Value.ToString()) != 0)
                    {
                        BaseGravable += Decimal.Parse(row.Cells["VlrBruto"].Value.ToString());
                    }

                }
                Total += sub + Iva;
                FacActual = txtNumFac.Text;
                BaseGravable = BaseGravable-(BaseGravable * (Descuento / 100));

                ds.Tables[4].Columns.Remove("Producto/servicio");
               dts = Clases.ProcesaDatos.ProcesarFactura("paInsertarDatosFactura", new object[] { txtNumFac.Text, 1, cbbCliente.SelectedValue.ToString(),cbbSede.SelectedValue.ToString(), cbbResolucion.SelectedValue.ToString(), 1, cbbCompania.SelectedValue.ToString(), rtxComentarios.Text, Iva, Subtotal, Total, BaseGravable,Math.Round(Descuento,27), dtpFechavencimento.Text, dtpFechaFactura.Text }, (DataTable)dgvInsumosFacturar.DataSource);

                if (dts.Rows[0][0].ToString()=="ok")
                {
                    MessageBox.Show("Factura Generada Correctamente","Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvInsumosFacturar.DataSource = null;
                    calcula = false;
                    CargarCombos();
                
                }
                else
                {
                    MessageBox.Show(dts.Rows[0][0].ToString(), "Error Sistemas de facturacion Revercer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // dgvInsumosFacturar.DataSource = null;

                    //CargarCombos();
                    calcula = false;
                }

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString(), "Error Sistema Facturacion Reverdecer",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dgvInsumosFacturar.DataSource = null;

                CargarCombos();
            }
            

            
        }

        private void ConsultarDireccion()
        {
            DataSet dsDir = new DataSet();
            dsDir = pd.ConsultasCombos("paConsultaDirecciones", cbbCliente.SelectedValue.ToString());
            cbbSede.DataSource = dsDir.Tables[0];
            cbbSede.ValueMember = "idDireccion";
            cbbSede.DisplayMember = "NombreSede";
        }
        private bool ValidarClientes()
        {
            try
            {
                if (cbbCliente.Text == "Selecione un cliente")
                {
                    errorProvider1.SetError(cbbCliente, "Selecione un cliente");
                    return true;
                }else
                {
                    errorProvider1.Clear();
                }
                if (cbbCliente.Text == "")
                {
                    cbbCliente.Text = "Selecione un cliente";
                    return true;
                }
                if (cbbCliente.SelectedValue == null)
                {
                    errorProvider1.SetError(cbbCliente, "El Cliente No existe");
                    cbbCliente.Focus();
                    return true;
                }
                else
                {
                    errorProvider1.Clear();
                    
                }
                //if(cbbSede.SelectedValue==null)
                //{
                //    errorProvider1.SetError(cbbSede, "Seleccione un dato");
                //    cbbSede.Focus();
                //    return true;
                //}else
                //{
                //    errorProvider1.Clear();
                //}
               
               
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private void cbbCliente_Validated(object sender, EventArgs e)
        {


            //if (ValidarClientes())
            //{
            //    return;
            //}
            //else
            //{
            //    ConsultarDireccion();
            //}



        }

         private bool ValidarControles()
        {
            if (dgvInsumosFacturar.RowCount==0)
            {
                MessageBox.Show("No hay datos para imprimir", "Sistema Factuacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                return true;
            }
            if(ValidarClientes() )
            {
              
                return true;
            }
            if(cbbSede.SelectedValue==null)
            {
                errorProvider1.SetError(cbbSede, "Seleccione una sede");
                return true;
            }else
            {
                errorProvider1.Clear();
            }


            
           
            return false;
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {


            Utilidades.ValidaNumeros(txtDescuento, new object[] {"%"} );
            dgvInsumosFacturar_RowStateChanged(null, null);


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvInsumosFacturar.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Hay una factura en proceso si continua perdera la informacion que no haya guardado, desea continuar?", "Sistema Facturacion Reverdecer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }

            }
            else
            {
                this.Close();
            }

        }

      

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(dgvInsumosFacturar.RowCount>0)
            {
                DialogResult dialogResult = MessageBox.Show( "Hay una factura en proceso si continua perdera la informacion que no haya guardado, desea continuar?", "Sistema Facturacion Reverdecer", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(dialogResult==DialogResult.Yes)
                {
                    CargarCombos();
                    
                }





            }else
            {
                CargarCombos();
            }

        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvInsumosFacturar.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Hay una factura en proceso si continua perdera la informacion que no haya guardado, desea continuar?", "Sistema Facturacion Reverdecer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CargarCombos();
                }




            }
            else
            {
                CargarCombos();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ValidarControles())

            {
                dts = null;
                return;
            }

            GuardarDocumento();

            if(dts==null)
            {
                return;
            }

           if( dts.Rows[0][0].ToString() == "ok")
            {
                // fac = new FrmReporteFac(FacActual);
                //CargarCombos();
                //fac.Show();
                
            }

         
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dgvInsumosFacturar.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Hay una factura en proceso si continua perdera la informacion que no haya guardado, desea continuar?", "Sistema Facturacion Reverdecer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CargarCombos();

                }





            }
            else
            {
                CargarCombos();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ValidarControles())

            {
                return;
            }
            GuardarDocumento();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            calcula = true;
            if (ValidarControles())

            {
                dts = null;
                return;
            }
            if(ValidarClientes())
            {
                return;
            }

            GuardarDocumento();

            if (dts == null)
            {
                return;
            }

            if (dts.Rows[0][0].ToString() == "ok")
            {
                Form fac = new FrmReporteFactura(FacActual);
                CargarCombos();
                fac.Show();

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Refresh();
        }

  
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (dgvInsumosFacturar.RowCount > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Hay una factura en proceso si continua perdera la informacion que no haya guardado, desea continuar?", "Sistema Facturacion Reverdecer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CargarCombos();
                }




            }
            else
            {
                CargarCombos();
            }
        }


        private void cbbCliente_TextChanged(object sender, EventArgs e)
        {
           
            if (cbbCliente.DataSource == null || cbbCliente.Text== "Selecione un cliente")
            {
                return;
            }
            
            string[] arrray = ds.Tables[1].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();// get the keyword to search
            string textToSearch = cbbCliente.Text.ToLower(); 
            //listBox1.Visible = false; // hide the listbox, see below for why doing that
            if (String.IsNullOrEmpty(textToSearch))
                return; // return with listbox hidden if the keyword is empty
            //search
         
           
            string[] result = (from i in arrray where i.ToLower().Contains(textToSearch) select i).ToArray();
            if (result.Length == 0)
                return; // return with listbox hidden if nothing found

            lsCliente.Items.Clear(); // remember to Clear before Add
            
            lsCliente.Items.AddRange(result);
            lsCliente.Visible = true; // show the listbox again 

            
            //comboBox1.DataSource = data.ToList();

        }

       


        private void cbbCliente_MouseUp(object sender, MouseEventArgs e)
        {
            cbbSede.DataSource = null;

        }

        private void lsCliente_MouseClick(object sender, MouseEventArgs e)
        {
            string x = "";
            try
            {
                cbbCliente.Text = lsCliente.SelectedItem.ToString();
                //listBox1.Visible = false;
                x = cbbCliente.SelectedValue.ToString();

                if (ValidarClientes())
                {
                    return;
                }
                else
                {
                    ConsultarDireccion();
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private void FrmFactura_Activated(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dgvInsumosFacturar_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

            lblSubtotal.Text = "0";
            lblIva.Text = "0";
            lblDcto.Text = "0";
            lblTotal.Text = "0";
            Decimal Iva1 = 0, Subtotal = 0, Total1 = 0, Descuento = 0, BaseGravable = 0, SubtotalReal = 0, sub = 0,DescuentoTotal=0;

            if(dgvInsumosFacturar.Rows.Count==0 || calcula==true)
            {
                return;
            }
            try
            {

                // Descuento = double.Parse(txtDescuento.Text);
                if (txtDescuento.Text.Contains("%"))
                {

                    Descuento = Decimal.Parse(txtDescuento.Text.Replace("%", ""));


                }
                else
                {
                    Decimal Subdescuento = 0;
                    foreach (DataGridViewRow rows in dgvInsumosFacturar.Rows)
                    {

                        Subdescuento += (Decimal.Parse(rows.Cells["VlrBruto"].Value.ToString()));




                    }
                    Descuento = (Decimal.Parse(txtDescuento.Text) / Subdescuento) * 100;

                }
                if (Descuento > 100)
                {
                    MessageBox.Show("El porcentaje de descuento no puede superar el 100% ", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                foreach (DataGridViewRow rows in dgvInsumosFacturar.Rows)
                {
                    SubtotalReal = 0;
                    SubtotalReal += (Decimal.Parse(rows.Cells["VlrBruto"].Value.ToString()) - (Decimal.Parse(rows.Cells["VlrBruto"].Value.ToString()) * Descuento / 100));
                    sub += SubtotalReal;
                    Iva1 += SubtotalReal * int.Parse(rows.Cells["Iva"].Value.ToString()) / 100;                                                          //             double.Parse(row.Cells["VlrIva"].Value.ToString());
                    Subtotal += Decimal.Parse(rows.Cells["VlrBruto"].Value.ToString());

                    //double.Parse(row.Cells["VlrTotal"].Value.ToString());
                    if (int.Parse(rows.Cells["Iva"].Value.ToString()) != 0)
                    {
                        BaseGravable += Decimal.Parse(rows.Cells["VlrBruto"].Value.ToString());
                    }

                }
                Total1 += sub + Iva1;

                lblSubtotal.Text = Subtotal.ToString("C0");
                lblIva.Text = Iva1.ToString("C0");
                lblTotal.Text = Total1.ToString("C0");

                DescuentoTotal = (-1*((Subtotal * Descuento)/100));
                lblDcto.Text = DescuentoTotal.ToString("C0");




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error Sistema Facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
             
            }
            calcula = false;

        }
    }
}


