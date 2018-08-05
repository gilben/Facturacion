using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Windows.Forms;
using SistemaFacturacion.Formularios;

namespace SistemaFacturacion.Clases
{
    public class clsUtilidades
    {

        public void FormatearGrid(DataGridView dgv, string columna, string  parametro)
        {
            if(parametro=="C")
            {
                dgv.Columns[columna].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                dgv.Columns[columna].DefaultCellStyle.Format = string.Format("C");
            }
            else if(parametro=="N")
            {
                dgv.Columns[columna].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                dgv.Columns[columna].DefaultCellStyle.Format = string.Format("N");
            }else
            {
                dgv.Columns[columna].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-us");
                dgv.Columns[columna].DefaultCellStyle.Format = string.Format("P0");
            }

      

        }

        public void AlinearContenidoColumna(DataGridView dgv)
        {
            double Dft = 0;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //row.Cells[col.Name].Value;

                    if(double.TryParse(row.Cells[col.Name].Value.ToString(),out Dft))
                    {
                        dgv.Columns[col.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    }

                    else
                    {
                        dgv.Columns[col.Name].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                    }
                }
            }


      
            

            //if (!long.TryParse(txt.Text, out Dft))
            //{
            //    MessageBox.Show("Este campo solo acepta valores numericos", "Sistema Factuacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Warning);


           
          

            //}


            //dgv.Columns[columna ].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public void ValidaNumeros(TextBox texbox, object [] ParametroExcluir)
        {

            long Dft = 0;
            if (texbox.Text.Length < 1)
                texbox.Text = "0";

            foreach(object obj in  ParametroExcluir)
            {
               // if (texbox.Text.Substring(texbox.Text.Length - 1) != obj.ToString())
               if(!texbox.Text.Contains(obj.ToString()))
                {


                    if (!long.TryParse(texbox.Text, out Dft))
                    {
                        MessageBox.Show("Este campo solo acepta valores numericos", "Sistema Factuacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        texbox.Text = "0";
                        texbox.SelectAll();
                        return;

                    }

                }
            }

           
        }
        public void ValidaNumeros(TextBox texbox)
        {

            long Dft = 0;
            if (texbox.Text.Length < 1)
                texbox.Text = "0";

            


                if (!long.TryParse(texbox.Text, out Dft))
                {
                    MessageBox.Show("Este campo solo acepta valores numericos", "Sistema Factuacion Reverdecer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    texbox.Text = "0";
                    texbox.SelectAll();
                    return;

                }

            
        }

        public void AlinearContenidoColumnaLeft(DataGridView dgv, string columna)
        {
            dgv.Columns[columna].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        public void ValidarForms(Form frm1)
        {


        

            foreach(Form frm in Application.OpenForms)
            {
                if (frm.GetType() !=null)
                {
                    frm1.BringToFront();
                }
            }
        }
    }
}
