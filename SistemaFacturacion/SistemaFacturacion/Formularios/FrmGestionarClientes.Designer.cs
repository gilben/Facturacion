namespace SistemaFacturacion.Formularios
{
    partial class FrmGestionarClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabClientes = new System.Windows.Forms.TabControl();
            this.Cliente = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.rbInactivo = new System.Windows.Forms.RadioButton();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTel2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCel = new System.Windows.Forms.TextBox();
            this.txtTel1 = new System.Windows.Forms.TextBox();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtRz = new System.Windows.Forms.TextBox();
            this.txtNit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDirecciones = new System.Windows.Forms.TabPage();
            this.dgvDirecciones = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabClientes.SuspendLayout();
            this.Cliente.SuspendLayout();
            this.tabDirecciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirecciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.Cliente);
            this.tabClientes.Controls.Add(this.tabDirecciones);
            this.tabClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClientes.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabClientes.Location = new System.Drawing.Point(0, 0);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.SelectedIndex = 0;
            this.tabClientes.Size = new System.Drawing.Size(556, 322);
            this.tabClientes.TabIndex = 0;
            this.tabClientes.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabClientes_Selecting);
            this.tabClientes.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabClientes_Selected);
            // 
            // Cliente
            // 
            this.Cliente.Controls.Add(this.txtEmail);
            this.Cliente.Controls.Add(this.btnGuardar);
            this.Cliente.Controls.Add(this.label9);
            this.Cliente.Controls.Add(this.rbInactivo);
            this.Cliente.Controls.Add(this.rbActivo);
            this.Cliente.Controls.Add(this.btnCancelar);
            this.Cliente.Controls.Add(this.btnEliminar);
            this.Cliente.Controls.Add(this.label8);
            this.Cliente.Controls.Add(this.txtTel2);
            this.Cliente.Controls.Add(this.label7);
            this.Cliente.Controls.Add(this.label6);
            this.Cliente.Controls.Add(this.label5);
            this.Cliente.Controls.Add(this.label4);
            this.Cliente.Controls.Add(this.label3);
            this.Cliente.Controls.Add(this.label2);
            this.Cliente.Controls.Add(this.txtCel);
            this.Cliente.Controls.Add(this.txtTel1);
            this.Cliente.Controls.Add(this.txtContacto);
            this.Cliente.Controls.Add(this.txtNombre);
            this.Cliente.Controls.Add(this.txtRz);
            this.Cliente.Controls.Add(this.txtNit);
            this.Cliente.Controls.Add(this.label1);
            this.Cliente.Location = new System.Drawing.Point(4, 24);
            this.Cliente.Name = "Cliente";
            this.Cliente.Padding = new System.Windows.Forms.Padding(3);
            this.Cliente.Size = new System.Drawing.Size(548, 294);
            this.Cliente.TabIndex = 0;
            this.Cliente.Text = "Cliente";
            this.Cliente.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(97, 121);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 22);
            this.txtEmail.TabIndex = 23;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Transparent;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.ImageKey = "(none)";
            this.btnGuardar.Location = new System.Drawing.Point(423, 19);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 44);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Email:";
            // 
            // rbInactivo
            // 
            this.rbInactivo.AutoSize = true;
            this.rbInactivo.Location = new System.Drawing.Point(167, 238);
            this.rbInactivo.Name = "rbInactivo";
            this.rbInactivo.Size = new System.Drawing.Size(65, 19);
            this.rbInactivo.TabIndex = 21;
            this.rbInactivo.TabStop = true;
            this.rbInactivo.Text = "Inactivo";
            this.rbInactivo.UseVisualStyleBackColor = true;
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Location = new System.Drawing.Point(97, 238);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(58, 19);
            this.rbActivo.TabIndex = 20;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(423, 151);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(95, 44);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.Location = new System.Drawing.Point(423, 83);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(95, 46);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Estado";
            // 
            // txtTel2
            // 
            this.txtTel2.Location = new System.Drawing.Point(97, 172);
            this.txtTel2.Name = "txtTel2";
            this.txtTel2.Size = new System.Drawing.Size(282, 22);
            this.txtTel2.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Telefono2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Celular:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Telefono1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contacto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Razon Social:";
            // 
            // txtCel
            // 
            this.txtCel.Location = new System.Drawing.Point(97, 200);
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(282, 22);
            this.txtCel.TabIndex = 6;
            // 
            // txtTel1
            // 
            this.txtTel1.Location = new System.Drawing.Point(97, 147);
            this.txtTel1.Name = "txtTel1";
            this.txtTel1.Size = new System.Drawing.Size(282, 22);
            this.txtTel1.TabIndex = 5;
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(97, 96);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(282, 22);
            this.txtContacto.TabIndex = 4;
            this.txtContacto.Validated += new System.EventHandler(this.txtContacto_Validated);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(97, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(282, 22);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.Validated += new System.EventHandler(this.txtNombre_Validated);
            // 
            // txtRz
            // 
            this.txtRz.Location = new System.Drawing.Point(97, 45);
            this.txtRz.Name = "txtRz";
            this.txtRz.Size = new System.Drawing.Size(282, 22);
            this.txtRz.TabIndex = 2;
            this.txtRz.Validated += new System.EventHandler(this.txtRz_Validated);
            // 
            // txtNit
            // 
            this.txtNit.Location = new System.Drawing.Point(97, 17);
            this.txtNit.Name = "txtNit";
            this.txtNit.Size = new System.Drawing.Size(282, 22);
            this.txtNit.TabIndex = 1;
            this.txtNit.TextChanged += new System.EventHandler(this.txtNit_TextChanged);
            this.txtNit.Validated += new System.EventHandler(this.txtNit_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nit:";
            // 
            // tabDirecciones
            // 
            this.tabDirecciones.Controls.Add(this.dgvDirecciones);
            this.tabDirecciones.Location = new System.Drawing.Point(4, 24);
            this.tabDirecciones.Name = "tabDirecciones";
            this.tabDirecciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirecciones.Size = new System.Drawing.Size(548, 294);
            this.tabDirecciones.TabIndex = 1;
            this.tabDirecciones.Text = "Direcciones";
            this.tabDirecciones.UseVisualStyleBackColor = true;
            // 
            // dgvDirecciones
            // 
            this.dgvDirecciones.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirecciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDirecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirecciones.EnableHeadersVisualStyles = false;
            this.dgvDirecciones.Location = new System.Drawing.Point(0, 3);
            this.dgvDirecciones.Name = "dgvDirecciones";
            this.dgvDirecciones.Size = new System.Drawing.Size(542, 288);
            this.dgvDirecciones.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmGestionarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 322);
            this.Controls.Add(this.tabClientes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGestionarClientes";
            this.Text = "Clientes";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmGestionarClientes_Load);
            this.tabClientes.ResumeLayout(false);
            this.Cliente.ResumeLayout(false);
            this.Cliente.PerformLayout();
            this.tabDirecciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirecciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabClientes;
        private System.Windows.Forms.TabPage Cliente;
        private System.Windows.Forms.TabPage tabDirecciones;
        private System.Windows.Forms.TextBox txtTel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCel;
        private System.Windows.Forms.TextBox txtTel1;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtRz;
        private System.Windows.Forms.TextBox txtNit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDirecciones;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbInactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}