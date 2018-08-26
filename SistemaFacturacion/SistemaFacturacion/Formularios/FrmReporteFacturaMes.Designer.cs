namespace SistemaFacturacion.Formularios
{
    partial class FrmReporteFacturaMes
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
            this.rptFacturasMes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptFacturasMes
            // 
            this.rptFacturasMes.LocalReport.ReportEmbeddedResource = "SistemaFacturacion.Reportes.rptReporteFacturas.rdlc";
            this.rptFacturasMes.Location = new System.Drawing.Point(12, 12);
            this.rptFacturasMes.Name = "rptFacturasMes";
            this.rptFacturasMes.Size = new System.Drawing.Size(828, 447);
            this.rptFacturasMes.TabIndex = 0;
            // 
            // FrmReporteFacturaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 482);
            this.Controls.Add(this.rptFacturasMes);
            this.Name = "FrmReporteFacturaMes";
            this.Text = "FrmReporteFacturaMes";
            this.Load += new System.EventHandler(this.FrmReporteFacturaMes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptFacturasMes;
    }
}