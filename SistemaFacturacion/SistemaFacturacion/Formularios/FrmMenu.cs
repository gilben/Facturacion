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

namespace SistemaFacturacion
{
    public partial class Form : System.Windows.Forms.Form
    {
        // clsMDIMenu menu = new clsMDIMenu();
        Clases.ProcesaDatos pd = new ProcesaDatos();
        DataSet ds = new DataSet();
        Clases.clsUtilidades ut = new clsUtilidades();
        public Form()
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

            cargarDatos();

           dtpFechaInicial .Format = DateTimePickerFormat.Custom;
            dtpFechaInicial.CustomFormat = "dd/MM/yyyy";
            dtpFechaFinal.Format = DateTimePickerFormat.Custom;
            dtpFechaFinal.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicial.Value = DateTime.Now;
            this.dtpFechaInicial.Value = DateTime.Now;

        }


        private void cargarDatos()
        {
            ds = pd.ConsultasCombos("paConsultarFacturas");

            dgvFacturas.DataSource = ds.Tables[0];
            ut.AlinearContenidoColumna(dgvFacturas);
            // ut.FormatearGrid(dgvFacturas, "Iva",true);
            ut.FormatearGrid(dgvFacturas, "SubTotal", true);
            ut.FormatearGrid(dgvFacturas, "BaseGravada", true);
            ut.FormatearGrid(dgvFacturas, "Descuento", true);
            ut.FormatearGrid(dgvFacturas, "Total", true);
            ut.FormatearGrid(dgvFacturas, "ValorIva", true);

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

            FrmReporteFac fac = new FrmReporteFac();
            fac.Show();

        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    }
