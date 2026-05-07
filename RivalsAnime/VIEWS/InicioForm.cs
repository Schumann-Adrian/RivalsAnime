using RivalsAnime.VIEWS; 

namespace RivalsAnime
{
    public partial class InicioForm : BaseForm
    {
        public InicioForm()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm ventanaLogin = new LoginForm();

            ventanaLogin.Show();

            this.Hide();
        }
    }
}
