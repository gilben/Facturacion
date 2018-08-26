using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.Formularios
{
    public partial class FrmCompañias : Form
    {
        int id_;
        int tipo_;
        DataSet ds;
        Clases.ProcesaDatos pd = new Clases.ProcesaDatos();
        public FrmCompañias()
        {
            InitializeComponent();
        }
        public FrmCompañias(int idCompañia,int tipo)
        {
            InitializeComponent();
            id_ = idCompañia;
            tipo_ = tipo;

      


        }

        private void FrmCompañias_Load(object sender, EventArgs e)
        {
            ConsultarCompañias();

           
        }


        private void InsertarActualizarCompañia()
        {
            string folderPath;
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;

            folderBrowser.Filter = "Image Files(*.JPG; *.PNG)| *.JPG; *.PNG | All files(*.*) | *.*";
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowser.FileName.ToString();

            }
            pbLogo.Image = new Bitmap(folderBrowser.FileName);
            //byte[] imageBuffer = (byte[])folderPath;
            //System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
            //pbLogo.Image = Image.FromStream(ms);


        }

        private void ConsultarCompañias()
        {
            if(tipo_==0)
            {
                return;
            }
            ds = pd.ConsultasCombos("paConsultasConParametros", new object[] { 3, id_ });

            byte[] imageBuffer = (byte[])ds.Tables[0].Rows[0]["Logo"];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
            pbLogo.Image = Image.FromStream(ms);
            txtNit.Text = ds.Tables[0].Rows[0]["Nit"].ToString();
            txtRZ.Text = ds.Tables[0].Rows[0]["RazonSocial"].ToString();
            txtNombre.Text= ds.Tables[0].Rows[0]["Nombre"].ToString();
            txtMail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtWeb.Text = ds.Tables[0].Rows[0]["SitioWeb"].ToString();
            txtTelefono.Text= ds.Tables[0].Rows[0]["Telefono"].ToString();
            txtDireccion.Text= ds.Tables[0].Rows[0]["Direccion"].ToString();
            txtCel.Text= ds.Tables[0].Rows[0]["Celular"].ToString();
            txtPais.Text= ds.Tables[0].Rows[0]["Pais"].ToString();
            txtCiudad.Text= ds.Tables[0].Rows[0]["Ciudad"].ToString();
            txtBarrio.Text= ds.Tables[0].Rows[0]["Barrio"].ToString();
            txtDepartamento.Text= ds.Tables[0].Rows[0]["Departamento"].ToString();

            //txtTel1.Text = ds.Tables[0].Rows[0]["Telefono1"].ToString();
            //txtTel2.Text = ds.Tables[0].Rows[0]["Telefono2"].ToString();
            //txtCel.Text = ds.Tables[0].Rows[0]["Celular"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            InsertarActualizarCompañia();
        }

        private void FrmCompañias_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMaestros obj = (FrmMaestros)Application.OpenForms["FrmMaestros"];
            obj.Refreshdata();
        }
    }
}
