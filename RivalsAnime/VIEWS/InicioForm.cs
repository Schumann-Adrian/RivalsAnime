
using RivalsAnime.VIEWS; 

namespace RivalsAnime
{
    public partial class InicioForm : BaseForm
    {
        public InicioForm()
        {
            InitializeComponent();

            string ruta = Path.Combine(Application.StartupPath, "Resources", "unravel.mp3");
            MusicManager.Play(ruta);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm ventanaLogin = new LoginForm();

            ventanaLogin.Show();

            this.Hide();
        }
    }
}
