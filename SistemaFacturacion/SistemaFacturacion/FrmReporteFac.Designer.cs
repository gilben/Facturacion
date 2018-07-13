namespace SistemaFacturacion
{
    partial class FrmReporteFac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteFac));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.paConsultaReporteFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Sistema_FacturacionDataSet = new SistemaFacturacion.Sistema_FacturacionDataSet();
            this.rvFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.paConsultaReporteFacturaTableAdapter = new SistemaFacturacion.Sistema_FacturacionDataSetTableAdapters.paConsultaReporteFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.paConsultaReporteFacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sistema_FacturacionDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // paConsultaReporteFacturaBindingSource
            // 
            this.paConsultaReporteFacturaBindingSource.DataMember = "paConsultaReporteFactura";
            this.paConsultaReporteFacturaBindingSource.DataSource = this.Sistema_FacturacionDataSet;
            // 
            // Sistema_FacturacionDataSet
            // 
            this.Sistema_FacturacionDataSet.DataSetName = "Sistema_FacturacionDataSet";
            this.Sistema_FacturacionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvFactura
            // 
            resources.ApplyResources(this.rvFactura, "rvFactura");
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.paConsultaReporteFacturaBindingSource;
            this.rvFactura.LocalReport.DataSources.Add(reportDataSource1);
            this.rvFactura.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptFactura.rdlc";
            this.rvFactura.Name = "rvFactura";
            // 
            // paConsultaReporteFacturaTableAdapter
            // 
            this.paConsultaReporteFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteFac
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rvFactura);
            this.Name = "FrmReporteFac";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteFac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paConsultaReporteFacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sistema_FacturacionDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvFactura;
        private System.Windows.Forms.BindingSource paConsultaReporteFacturaBindingSource;
        private Sistema_FacturacionDataSet Sistema_FacturacionDataSet;
        private Sistema_FacturacionDataSetTableAdapters.paConsultaReporteFacturaTableAdapter paConsultaReporteFacturaTableAdapter;
    }
}