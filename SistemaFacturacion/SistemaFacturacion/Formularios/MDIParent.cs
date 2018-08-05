using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;


namespace SistemaFacturacion.Formularios
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        Clases.clsUtilidades ut = new Clases.clsUtilidades();
        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmMenuFactura = new FrmMenuFactura();
            Form frm = this.MdiChildren.FirstOrDefault(x => x is FrmMenuFactura);

            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
        
            FrmMenuFactura.MdiParent = this;
            FrmMenuFactura.Show();
        }

        private void nuevaFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            Form FrmFactura = new FrmFactura();
            Form frm = this.MdiChildren.FirstOrDefault(x => x is FrmFactura);

            if(frm!=null)
            {
                frm.BringToFront();
                return;
            }
            FrmFactura.MdiParent = this;
            FrmFactura.Show();
        }

        private void insumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Form frm = this.MdiChildren.FirstOrDefault(x => x is FrmMaestros);

            foreach (Form frm1 in Application.OpenForms)
            {

                if (frm1.Text == "Insumos")
                {
                    frm1.BringToFront();
                    return;
                }

            }
            Form FrmInsumos = new FrmMaestros("Insumos");
            FrmInsumos.MdiParent = this;
            FrmInsumos.Text = "Insumos";
            FrmInsumos.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form frm1 in Application.OpenForms)
            {

                if (frm1.Text == "Clientes")
                {
                    frm1.BringToFront();
                    return;
                }

            }


            Form FrmClientes = new FrmMaestros("Clientes");
            FrmClientes.MdiParent = this;
            FrmClientes.Text = "Clientes";
            FrmClientes.Show();

        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            //tsVersion.Text=Application.ProductVersion;
            tsVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void tsVersion_Click(object sender, EventArgs e)
        {

        }
    }
}
