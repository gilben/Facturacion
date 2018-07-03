using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion.Clases
{
    public class clsMDIMenu:TabPage
    {
        private Form Menu;

        public clsMDIMenu(FormMenu Contenido)
        {
            this.Menu = Contenido;
            this.Controls.Add(Contenido.pnl);
        }
    }

    public class FormMenu : Form
    {
        public Panel pnl;
    }
}
