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
        public Form()
        {
            InitializeComponent();
        }

     

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.FrmFactura FormFac = new  Formularios.FrmFactura();

            FormFac.Text = "Generar Factura";
            FormFac.Show();
            //menu.AgregarTabPage(FormFac, TabControlForm);
            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            clsConexion con = new clsConexion();
        }
    }
}
