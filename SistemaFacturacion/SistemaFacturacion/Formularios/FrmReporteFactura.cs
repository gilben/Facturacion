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
    public partial class FrmReporteFactura : Form
    {
        Microsoft.Reporting.WinForms.ReportDataSource DataSourceReporte = new Microsoft.Reporting.WinForms.ReportDataSource();
        string Documento;
        public FrmReporteFactura(string Factura)
        {
            InitializeComponent();
            Documento = Factura;

        }

        private void FrmReporteFactura_Load(object sender, EventArgs e)
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
            ds= datos.ConsultasCombos("paConsultaReporteFactura",Documento );



      
            this.rptFactura.LocalReport.DataSources.Clear();
            this.rptFactura.Clear();
            this.rptFactura.Refresh();
 
            DataSourceReporte.Name = "DataSet1";
            DataSourceReporte.Value = ds.Tables[0];
            this.rptFactura.LocalReport.DataSources.Add(DataSourceReporte);

            this.rptFactura.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptFactura.rdlc";
            this.rptFactura.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.rptFactura.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.rptFactura.ZoomPercent = 100;


            this.rptFactura.RefreshReport();

         
        }
    }
}
