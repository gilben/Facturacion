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
    public partial class FrmFactura : System.Windows.Forms.Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }

        DataTable dt;
        DataSet ds;

        private void FrmFactura_Load(object sender, EventArgs e)
        {

            CargarCombos();
            dtpFechaFactura.Format = DateTimePickerFormat.Custom;
            dtpFechaFactura.CustomFormat = "dd/MM/yyyy";
            dtpFechavencimento.Format = DateTimePickerFormat.Custom;
            dtpFechavencimento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFactura.Value = DateTime.Now;
            this.dtpFechavencimento.Value = DateTime.Now ;

            
        }



        private void CargarCombos()
        {
            Clases.clsConexion con = new Clases.clsConexion();
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

            cbbCompania.DataSource = ds.Tables[5];
            cbbCompania.DisplayMember = "RazonSocial";
            cbbCompania.ValueMember = "Nit";

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
                bs.Filter = "Nombre LIKE '%"+Dato+"%' OR CodigoInsumo LIKE '"+Dato+"' ";
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


            if(string.IsNullOrEmpty( dgvInsumos.Rows[row].Cells["Cantidad"].Value.ToString()) )
            {
                MessageBox.Show("La cntidad no puede estar vacia", "Sistema de facturacion Reverdecer",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            int RowsDt = ds.Tables[4].Rows.Count;

           foreach(DataRow rows in ds.Tables[4].Rows)
            {
                if(rows[0].ToString()== dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value.ToString())
                {
                    MessageBox.Show("El insumo ya esta en la lista para facturar","Sistema de facturacion Reverdecer",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                
            }
            

            double Bruto =Convert.ToDouble( dgvInsumos.Rows[row].Cells["Cantidad"].Value)* Convert.ToDouble(dgvInsumos.Rows[row].Cells["Precio"].Value);
            double VlrIva = (Bruto * Convert.ToDouble(dgvInsumos.Rows[row].Cells["Iva"].Value))/100;
            double Total = Bruto + VlrIva;
            double VlrUnitario = Convert.ToDouble(dgvInsumos.Rows[row].Cells["Precio"].Value);//.ToString("c1", System.Globalization.CultureInfo.GetCultureInfo("en-us")));
            int Iva = Convert.ToInt16(dgvInsumos.Rows[row].Cells["Iva"].Value);


            DataRow dr = ds.Tables[4].NewRow();

            dr[0] = dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value;
            dr[1] = dgvInsumos.Rows[row].Cells["Nombre"].Value;
            dr[2] = Iva;
            dr[3] = dgvInsumos.Rows[row].Cells["Cantidad"].Value;
            dr[4] = VlrUnitario.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[5] = VlrIva.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[6] = Bruto.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
            dr[7] = Total.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us"));

            ds.Tables[4].Rows.InsertAt(dr, 0);
            dgvInsumosFacturar.DataSource = ds.Tables[4];
            dgvInsumosFacturar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dgvInsumosFacturar.Rows.Add(dgvInsumos.Rows[row].Cells["CodigoInsumo"].Value, dgvInsumos.Rows[row].Cells["Nombre"].Value,Iva, dgvInsumos.Rows[row].Cells["Cantidad"].Value, VlrUnitario.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")), VlrIva.ToString("c0",System.Globalization.CultureInfo.GetCultureInfo("en-us")), Bruto.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")), Total.ToString("c0", System.Globalization.CultureInfo.GetCultureInfo("en-us")));

            
        }
    }
}
