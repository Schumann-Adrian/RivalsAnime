using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(1200, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            string ruta = Path.Combine(Application.StartupPath, "Resources", "Cursors", "Goku.cur");

            if (File.Exists(ruta))
            {
                this.Cursor = new Cursor(ruta);
            }
            else
            {
                MessageBox.Show("No se encontró el cursor ❌");
            }
        }
    }
}