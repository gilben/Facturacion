using SistemaFacturacion.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFacturacion.Formularios;

namespace SistemaFacturacion
{
    public partial class FrmMenuFactura : System.Windows.Forms.Form
    {
        // clsMDIMenu menu = new clsMDIMenu();
        Clases.ProcesaDatos pd = new ProcesaDatos();
        DataSet ds = new DataSet();
        Clases.clsUtilidades ut = new clsUtilidades();
        public FrmMenuFactura ()
        {
            InitializeComponent();
        }



        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmFactura FormFac = new Formularios.FrmFactura();

            FormFac.Text = "Generar Factura";
            FormFac.Show();
            //menu.AgregarTabPage(FormFac, TabControlForm);

        }



        private void Form_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            cargarDatos();

           dtpFechaInicial .Format = DateTimePickerFormat.Custom;
            dtpFechaInicial.CustomFormat = "MM/dd/yyyy";
            dtpFechaFinal.Format = DateTimePickerFormat.Custom;
            dtpFechaFinal.CustomFormat = "MM/dd/yyyy";
            this.dtpFechaInicial.Value = DateTime.Now;
            this.dtpFechaInicial.Value = DateTime.Now;

         
            


        }


        private void cargarDatos()
        {
            ds = pd.ConsultasCombos("paConsultarFacturas");

            dgvFacturas.DataSource = ds.Tables[0];
            ut.AlinearContenidoColumna(dgvFacturas);
            // ut.FormatearGrid(dgvFacturas, "Iva",true);
            ut.FormatearGrid(dgvFacturas, "SubTotal", "C");
            ut.FormatearGrid(dgvFacturas, "BaseGravada", "C");
            ut.FormatearGrid(dgvFacturas, "PorcDescuento", "P");
            ut.FormatearGrid(dgvFacturas, "VlrDescuento", "C");
            ut.FormatearGrid(dgvFacturas, "Total", "C");
            ut.FormatearGrid(dgvFacturas, "ValorIva", "C");
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }




        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string Dato = txtBuscar.Text;
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvFacturas.DataSource;
            // string filtro = string.Format($"(Nombre ={s})");
            bs.Filter = "[Factura] LIKE '%" + Dato + "%' OR Cliente LIKE '%" + Dato + "%' OR Estado LIKE '%"+Dato+"%' ";
            dgvFacturas.DataSource = bs;

        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmFactura FormFac = new Formularios.FrmFactura();

            FormFac.Text = "Generar Factura";
            FormFac.Show();
            //menu.AgregarTabPage(FormFac, TabControlForm);
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Formularios.FrmReporteFactura rptfac = new Formularios.FrmReporteFactura();
            //rptfac.Show();
            //FrmReporteFac fac = new FrmReporteFac();
            //fac.Show();

            //frmRptFac frm = new frmRptFac();
            //frm.Show();
            int row = dgvFacturas.CurrentCell.RowIndex;


         //dgvFacturas.Rows[row].Cells["Factura"].Value.ToString()

            //descomentar este    FrmReporteFac fac = new FrmReporteFac(dgvFacturas.Rows[row].Cells["Factura"].Value.ToString());


            // y estefac.Show();

        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Formularios.FrmFactura FormFac = new Formularios.FrmFactura();
           // FormFac.MdiParent = ;
            FormFac.Text = "Generar Factura";
            FormFac.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int row = dgvFacturas.CurrentCell.RowIndex;


            dgvFacturas.Rows[row].Cells["Factura"].Value.ToString();

           FrmReporteFactura fac = new FrmReporteFactura(dgvFacturas.Rows[row].Cells["Factura"].Value.ToString());
            

               fac.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void facToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form FrmFactura = new Formularios.FrmFactura();
            //FrmFactura.MdiParent = Formularios.MDIParent;
            //FrmFactura.Show();
        }

        private void dgvFacturas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = dgvFacturas.CurrentCell.RowIndex;


            dgvFacturas.Rows[row].Cells["Factura"].Value.ToString();

            FrmReporteFactura fac = new FrmReporteFactura(dgvFacturas.Rows[row].Cells["Factura"].Value.ToString());


            fac.Show();
        }
    }
    }
