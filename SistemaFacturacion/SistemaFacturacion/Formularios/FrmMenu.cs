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


            ds = pd.ConsultasCombos("paConsultarFacturas");

            dgvFacturas.DataSource = ds.Tables[0];
            ut.FormatearGrid(dgvFacturas, "Iva");
            ut.FormatearGrid(dgvFacturas, "SubTotal");
            ut.FormatearGrid(dgvFacturas, "BaseGravada");
            ut.FormatearGrid(dgvFacturas, "Descuento");
            ut.FormatearGrid(dgvFacturas, "Total");

        }



 

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string Dato = txtBuscar.Text;
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvFacturas.DataSource;
            // string filtro = string.Format($"(Nombre ={s})");
            bs.Filter = "[Factura] LIKE '%" + Dato + "%' OR Cliente LIKE '%" + Dato + "%' ";
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

            frmRptFac frm = new frmRptFac();
            frm.Show();

        }
    }
    }
