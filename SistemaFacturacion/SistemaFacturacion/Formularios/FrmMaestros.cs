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
        string TipoConsulta_="";
        DataSet ds;


      
       public void Refreshdata()
        {
            
            ConsultaDatosInsumos();
        
        }


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
          

            Clases.clsUtilidades ut = new Clases.clsUtilidades();
            ds = pd.ConsultasCombos("paConsultas", "1");

            if (TipoConsulta_ == "Insumos")
            {
                dgvMaestros.DataSource = ds.Tables[0];
            
                ut.FormatearGrid(dgvMaestros, "Precio", "C");
            }else if (TipoConsulta_=="Clientes")
            {
                gbppal.Text = "Clientes";
                dgvMaestros.DataSource = ds.Tables[1];
                dgvMaestros.Columns["Id"].Visible = false;
            }
            else if(TipoConsulta_ == "Compañias")
            {
                gbppal.Text = "Compañias";
                dgvMaestros.DataSource = ds.Tables[2];
                dgvMaestros.Columns["IdCompañia"].Visible = false;
                dgvMaestros.Columns["Logo"].Visible = false;

            }
            ut.AlinearContenidoColumna(dgvMaestros);
            dgvMaestros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
        else if (TipoConsulta_ == "Compañias")
            {
                Form FrmCompañias = new FrmCompañias(0,0);
                FrmCompañias.Show();
                
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
            int row = dgvMaestros.CurrentCell.RowIndex;
            if (TipoConsulta_ == "Insumos")
            {
               
                string CodigoInsumo = dgvMaestros.Rows[row].Cells["CodigoInsumo"].Value.ToString();

                Form FrmInsumos = new FrmGestionarInsumo(CodigoInsumo);
                
                FrmInsumos.Show();
            }else if(TipoConsulta_=="Clientes")
            {
                
                string Nit = dgvMaestros.Rows[row].Cells["Nit"].Value.ToString();
                int Id = int.Parse( dgvMaestros.Rows[row].Cells["Id"].Value.ToString());
                Form FrmClientes = new FrmGestionarClientes(Nit,Id);
                FrmClientes.Show();

            }
            else if (TipoConsulta_ == "Compañias")
            {
                
                int Id = int.Parse(dgvMaestros.Rows[row].Cells["IdCompañia"].Value.ToString());
                Form FrmCompañias = new FrmCompañias(Id,1);
                FrmCompañias.Show();

            }

        }

        private void tsbRefrescar_Click(object sender, EventArgs e)
        {
            ConsultaDatosInsumos();
            textBox1.Text = "";
        }

    
    }
}
