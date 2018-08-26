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
    public partial class FrmReporteFacturaMes : Form
    {
        Microsoft.Reporting.WinForms.ReportDataSource DataSourceReporte = new Microsoft.Reporting.WinForms.ReportDataSource();
        public FrmReporteFacturaMes()
        {
            InitializeComponent();
        }

        private void FrmReporteFacturaMes_Load(object sender, EventArgs e)
        {
            Clases.ProcesaDatos datos = new Clases.ProcesaDatos();
            //string c = "70221428";
            DataSet ds = new System.Data.DataSet();
            DataTable dt = new DataTable();

            //SqlConnection sCon = new SqlConnection(@"Data Source=DESKTOP-O21LNAS\SQLEXPRESS;Initial Catalog=Sistema_Facturacion;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("[paConsultaReporteFactura] 2045", sCon);
            //cmd.CommandType = CommandType.Text;

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);
            //sCon.Close();




            //dt = ds.Tables[0];
            ds = datos.ConsultasCombos("paReporteFacturasMensual");




            this.rptFacturasMes.LocalReport.DataSources.Clear();
            this.rptFacturasMes.Clear();
            this.rptFacturasMes.Refresh();

            rptFacturasMes.Name = "DataSet1";
            //rptFacturasMes.Value = ds.Tables[0];
            this.rptFacturasMes.LocalReport.DataSources.Add(DataSourceReporte);

            this.rptFacturasMes.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptReporteFacturas.rdlc";
            this.rptFacturasMes.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.rptFacturasMes.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.rptFacturasMes.ZoomPercent = 100;


            this.rptFacturasMes.RefreshReport();



            this.rptFacturasMes.RefreshReport();
        }
    }
}
