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
    public partial class FrmReporteFac : System.Windows.Forms.Form
    {
        string documento;
        public FrmReporteFac()
        {
            InitializeComponent();
        }

        public FrmReporteFac(string Documento)
        {
             documento = Documento;
            InitializeComponent();
        }

        private void FrmReporteFac_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Sistema_FacturacionDataSet.paConsultaReporteFactura' table. You can move, or remove it, as needed.
            this.paConsultaReporteFacturaTableAdapter.Fill(this.Sistema_FacturacionDataSet.paConsultaReporteFactura ,documento);

            this.rvFactura.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptFactura.rdlc";
            this.rvFactura.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.rvFactura.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.rvFactura.ZoomPercent = 100;

        

            this.rvFactura.RefreshReport();
            
        }
    }
}
