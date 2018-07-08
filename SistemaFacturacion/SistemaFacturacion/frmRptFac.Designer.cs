namespace SistemaFacturacion
{
    partial class frmRptFac
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Sistema_FacturacionDataSet = new SistemaFacturacion.Sistema_FacturacionDataSet();
            this.paConsultaReporteFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paConsultaReporteFacturaTableAdapter = new SistemaFacturacion.Sistema_FacturacionDataSetTableAdapters.paConsultaReporteFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Sistema_FacturacionDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paConsultaReporteFacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.paConsultaReporteFacturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptFactura.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1146, 408);
            this.reportViewer1.TabIndex = 0;
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
            // frmRptFac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 408);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRptFac";
            this.Text = "frmRptFac";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRptFac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Sistema_FacturacionDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paConsultaReporteFacturaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource paConsultaReporteFacturaBindingSource;
        private Sistema_FacturacionDataSet Sistema_FacturacionDataSet;
        private Sistema_FacturacionDataSetTableAdapters.paConsultaReporteFacturaTableAdapter paConsultaReporteFacturaTableAdapter;
    }
}