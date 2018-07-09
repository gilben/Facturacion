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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sistema_FacturacionDataSet = new SistemaFacturacion.Sistema_FacturacionDataSet();
            this.paConsultaReporteFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paConsultaReporteFacturaTableAdapter = new SistemaFacturacion.Sistema_FacturacionDataSetTableAdapters.paConsultaReporteFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Sistema_FacturacionDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paConsultaReporteFacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvFactura
            // 
            this.rvFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.paConsultaReporteFacturaBindingSource;
            this.rvFactura.LocalReport.DataSources.Add(reportDataSource1);
            this.rvFactura.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptFactura.rdlc";
            this.rvFactura.Location = new System.Drawing.Point(0, 0);
            this.rvFactura.Name = "rvFactura";
            this.rvFactura.Size = new System.Drawing.Size(564, 360);
            this.rvFactura.TabIndex = 0;
            // 
            // Sistema_FacturacionDataSet
            // 
            this.Sistema_FacturacionDataSet.DataSetName = "Sistema_FacturacionDataSet";
            this.Sistema_FacturacionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // paConsultaReporteFacturaBindingSource
            // 
            this.paConsultaReporteFacturaBindingSource.DataMember = "paConsultaReporteFactura";
            this.paConsultaReporteFacturaBindingSource.DataSource = this.Sistema_FacturacionDataSet;
            // 
            // paConsultaReporteFacturaTableAdapter
            // 
            this.paConsultaReporteFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteFac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 360);
            this.Controls.Add(this.rvFactura);
            this.Name = "FrmReporteFac";
            this.Text = "FrmReporteFac";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReporteFac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sistema_FacturacionDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paConsultaReporteFacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvFactura;
        private System.Windows.Forms.BindingSource paConsultaReporteFacturaBindingSource;
        private Sistema_FacturacionDataSet Sistema_FacturacionDataSet;
        private Sistema_FacturacionDataSetTableAdapters.paConsultaReporteFacturaTableAdapter paConsultaReporteFacturaTableAdapter;
    }
}