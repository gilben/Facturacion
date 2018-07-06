using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.Windows.Forms;

namespace SistemaFacturacion.Clases
{
    public class clsUtilidades
    {
        public void FormatearGrid(DataGridView dgv, string columna)
        {
            dgv.Columns[columna].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("en-us");
            dgv.Columns[columna].DefaultCellStyle.Format = string.Format("C");

        }
    }
}
