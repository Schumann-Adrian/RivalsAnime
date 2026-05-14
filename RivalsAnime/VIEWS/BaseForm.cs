using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class BaseForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(System.IntPtr handle);

        public BaseForm()
        {
            AplicarEstiloBase();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            CargarIconoProyecto();
        }

        private void AplicarEstiloBase()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1200, 700);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            CargarIconoProyecto();

            string ruta = Path.Combine(Application.StartupPath, "Resources", "Cursors", "Goku.cur");

            if (File.Exists(ruta))
            {
                Cursor = new Cursor(ruta);
            }
        }

        private void CargarIconoProyecto()
        {
            string rutaIcono = Path.Combine(
                Application.StartupPath,
                "Resources",
                "Imagenes",
                "IconoProyecto.jfif"
            );

            if (!File.Exists(rutaIcono))
                return;

            using (Bitmap imagen = new Bitmap(rutaIcono))
            {
                System.IntPtr iconoHandle = imagen.GetHicon();

                try
                {
                    Icon = (Icon)Icon.FromHandle(iconoHandle).Clone();
                }
                finally
                {
                    DestroyIcon(iconoHandle);
                }
            }
        }
    }
}
