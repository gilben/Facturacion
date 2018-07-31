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
    public partial class FrmMaestros : Form
    {
        Clases.ProcesaDatos pd = new Clases.ProcesaDatos();
        string TipoConsulta_;
        DataSet ds;


      
       


        public FrmMaestros()
        {
           
            InitializeComponent();
            
        }
        public FrmMaestros(string TipoConsulta)
        {
            TipoConsulta_ = TipoConsulta;
            InitializeComponent();
        }

        private void FrmMaestros_Load(object sender, EventArgs e)
        {
            ConsultaDatosInsumos();
            WindowState = FormWindowState.Maximized;
        }

         public  void ConsultaDatosInsumos()

        {
            ds = pd.ConsultasCombos("paConsultas", "1");

            if (TipoConsulta_ == "Insumos")
            {
                dgvMaestros.DataSource = ds.Tables[0];
            }else if (TipoConsulta_=="Clientes")
            {
                gbppal.Text = "Clientes";
                dgvMaestros.DataSource = ds.Tables[1];
                dgvMaestros.Columns["Id"].Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (TipoConsulta_ == "Insumos")
            {
                Form FrmInsumos = new FrmGestionarInsumo();
                FrmInsumos.Show();
            }else if (TipoConsulta_ == "Clientes")
            {
                Form FrmClientes = new FrmGestionarClientes();
                FrmClientes.Show();
                
            }
        }

   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Busca en grid



                string Codigo = dgvMaestros.Columns[0].Name.ToString();//; dgvMaestros.Rows[row].Cells[0].Value.ToString();
                string Codigo1 = dgvMaestros.Columns[1].Name.ToString();
                string Dato = textBox1.Text;
                BindingSource bs = new BindingSource();
                bs.DataSource = dgvMaestros.DataSource;
                // string filtro = string.Format($"(Nombre ={s})");
                bs.Filter = " "+Codigo+" LIKE '%" + Dato + "%' OR "+Codigo1+" LIKE '%" + Dato + "%' ";
                dgvMaestros.DataSource = bs;




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }



        private void dgvMaestros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TipoConsulta_ == "Insumos")
            {
                int row = dgvMaestros.CurrentCell.RowIndex;
                string CodigoInsumo = dgvMaestros.Rows[row].Cells["CodigoInsumo"].Value.ToString();

                Form FrmInsumos = new FrmGestionarInsumo(CodigoInsumo);
                
                FrmInsumos.Show();
            }else if(TipoConsulta_=="Clientes")
            {
                int row = dgvMaestros.CurrentCell.RowIndex;
                string Nit = dgvMaestros.Rows[row].Cells["Nit"].Value.ToString();
                int Id = int.Parse( dgvMaestros.Rows[row].Cells["Id"].Value.ToString());
                Form FrmClientes = new FrmGestionarClientes(Nit,Id);
                FrmClientes.Show();

            }

        }

        private void tsbRefrescar_Click(object sender, EventArgs e)
        {
            ConsultaDatosInsumos();
            textBox1.Text = "";
        }
    }
}
