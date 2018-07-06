using System;
using System.Collections;
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
    public partial class FrmFactura : System.Windows.Forms.Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        DataTable dt;
        DataSet ds;
        Clases.clsUtilidades Utilidades = new Clases.clsUtilidades();
        Clases.clsConexion con = new Clases.clsConexion();





        private void FrmFactura_Load(object sender, EventArgs e)
        {

            CargarCombos();
            dtpFechaFactura.Format = DateTimePickerFormat.Custom;
            dtpFechaFactura.CustomFormat = "dd/MM/yyyy";
            dtpFechavencimento.Format = DateTimePickerFormat.Custom;
            dtpFechavencimento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFactura.Value = DateTime.Now;
            this.dtpFechavencimento.Value = DateTime.Now;


        }



        private void CargarCombos()
        {
           
            ds = con.ConsultasCombos(0);
            //string[] s = ds.Tables[1].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();

            cbbResolucion.DataSource = ds.Tables[0];
            cbbResolucion.ValueMember = "NumeroResolucion";
            this.cbbResolucion.AutoCompleteCustomSource.AddRange(ds.Tables[0].Rows.OfType<DataRow>().Select(k => k[0].ToString()).ToArray());
            this.cbbResolucion.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbbResolucion.AutoCompleteSource = AutoCompleteSource.CustomSource;



            // this.cbbCliente.AutoCompleteCustomSource.AddRange(ds.Tables[1].Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray());
            // autocompleta combox
            this.cbbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            DataView dtv = new DataView(ds.Tables[1]);
            dtv.Sort = "Nombre DESC";
            DataTable dt = dtv.ToTable();
            cbbCliente.DataSource = dt;
            cbbCliente.DisplayMember = "RazonSocial";
            cbbCliente.ValueMember = "Nit";



            txtNumFac.Text = ds.Tables[2].Rows[0]["NumFac"].ToString();
            dgvInsumos.DataSource = ds.Tables[3];
            dgvInsumos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dgvInsumos.Columns["Precio"].DefaultCellStyle.FormatProvider= System.Globalization.CultureInfo.GetCultureInfo("en-us");
            //dgvInsumos.Columns["Precio"].DefaultCellStyle.Format =string.Format( "C");
            Utilidades.FormatearGrid(dgvInsumos, "Precio");

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






            // dgvInsumos.Columns["Unidad medida"].DisplayIndex = 0;




            cbbCompania.DataSource = ds.Tables[5];
            cbbCompania.DisplayMember = "RazonSocial";
            cbbCompania.ValueMember = "IdCompañia";

            //dgvInsumosFacturar.Columns.Add("CodigoInsumo", "CodigoInsumo");
            //dgvInsumosFacturar.Columns.Add("Descripcion", "Descripcion");
            //dgvInsumosFacturar.Columns.Add("Iva", "Iva");
            //dgvInsumosFacturar.Columns.Add("Cantidad", "Cantidad");
            //dgvInsumosFacturar.Columns.Add("VlrUnitario", "VlrUnitario");
            //dgvInsumosFacturar.Columns.Add("VlrIva", "VlrIva");
            //dgvInsumosFacturar.Columns.Add("VlrBruto", "VlrBruto");
            //dgvInsumosFacturar.Columns.Add("VlrTotal", "VlrTotal");


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
                    MessageBox.Show("El insumo ya esta en la lista para facturar", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


            }


            double Bruto = Convert.ToDouble(dgvInsumos.Rows[row].Cells["Cantidad"].Value) * Convert.ToDouble(dgvInsumos.Rows[row].Cells["Precio"].Value);
            double VlrIva = (Bruto * Convert.ToDouble(dgvInsumos.Rows[row].Cells["Iva"].Value)) / 100;
            double Total = Bruto + VlrIva;
            double VlrUnitario = Convert.ToDouble(dgvInsumos.Rows[row].Cells["Precio"].Value);//.ToString("c1", System.Globalization.CultureInfo.GetCultureInfo("en-us")));
            int Iva = Convert.ToInt16(dgvInsumos.Rows[row].Cells["Iva"].Value);


            DataRow dr = ds.Tables[4].NewRow();

            dr[0] = dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value;
            dr[1] = dgvInsumos.Rows[row].Cells["Producto/servicio"].Value;
            dr[2] = dgvInsumos.Rows[row].Cells["Cantidad"].Value;
            dr[3] = Iva;
            dr[4] = VlrUnitario;//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[5] = VlrIva;//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[6] = Bruto;//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[7] = Total;//.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));



            ds.Tables[4].Rows.InsertAt(dr, 0);
            dgvInsumosFacturar.DataSource = ds.Tables[4];
            dgvInsumosFacturar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dgvInsumosFacturar.Rows.Add(dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value, dgvInsumos.Rows[row].Cells["Nombre"].Value,Iva, dgvInsumos.Rows[row].Cells["Cantidad"].Value, VlrUnitario.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")), VlrIva.ToString("c0",System.Globalization.CultureInfo.GetCultureInfo("en-us")), Bruto.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")), Total.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")));


            Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrUnitario");
            // Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrIva");
            //Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrBruto");
            //Utilidades.FormatearGrid(dgvInsumosFacturar, "VlrTotal");


        }

        private void dgvInsumos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           

            if (dgvInsumos.CurrentCell.ColumnIndex == 2 || dgvInsumos.CurrentCell.ColumnIndex == 5)
            {
                dgvInsumos.BeginEdit(true);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarDocumento();
        }


        private void GuardarDocumento()
        {
            if (dgvInsumosFacturar.RowCount == 0)
            {
                MessageBox.Show("No hay datos para guardar", "Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            double Iva = 0, Subtotal = 0, Total = 0, Descuento = 0, BaseGravable = 0;
            try
            {
                foreach (DataGridViewRow row in dgvInsumosFacturar.Rows)
                {
                    Iva += double.Parse(row.Cells["VlrIva"].Value.ToString());
                    Subtotal += double.Parse(row.Cells["VlrBruto"].Value.ToString());
                    Total += double.Parse(row.Cells["VlrTotal"].Value.ToString());
                    if (int.Parse(row.Cells["Iva"].Value.ToString()) != 0)
                    {
                        BaseGravable += double.Parse(row.Cells["VlrBruto"].Value.ToString());
                    }

                }

                Descuento = double.Parse(txtDescuento.Text);

                ds.Tables[4].Columns.Remove("Producto/servicio");
                DataTable dts = Clases.ProcesaDatos.ProcesarFactura("paInsertarDatosFactura", new object[] { txtNumFac.Text, 1, cbbCliente.SelectedValue.ToString(), cbbResolucion.SelectedValue.ToString(), 1, cbbCompania.SelectedValue.ToString(), rtxComentarios.Text, Iva, Subtotal, Total, BaseGravable, Descuento, dtpFechavencimento.Text, dtpFechaFactura.Text }, (DataTable)dgvInsumosFacturar.DataSource);

                if (dts.Rows[0][0].ToString()=="ok")
                {
                    MessageBox.Show("Factura Generada Correctamente","Sistema de facturacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvInsumosFacturar.DataSource = null;

                    CargarCombos();
                
                }
                else
                {
                    MessageBox.Show(dts.Rows[0][0].ToString(), "Error Sistemas de facturacion Revercer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dgvInsumosFacturar.DataSource = null;

                    CargarCombos();
                }

            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.ToString(), "Error Sistema Facturacion Reverdecer",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                dgvInsumosFacturar.DataSource = null;

                CargarCombos();
            }
            

            
        }

        
    }
}


