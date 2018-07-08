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
    public partial class frmRptFac : System.Windows.Forms.Form
    {
        public frmRptFac()
        {
            InitializeComponent();
        }

        private void frmRptFac_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Sistema_FacturacionDataSet.paConsultaReporteFactura' table. You can move, or remove it, as needed.
            this.paConsultaReporteFacturaTableAdapter.Fill(this.Sistema_FacturacionDataSet.paConsultaReporteFactura,"2005");

            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptFactura.rdlc";
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }
    }
}
