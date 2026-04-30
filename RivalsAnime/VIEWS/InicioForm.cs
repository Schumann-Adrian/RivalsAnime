namespace RivalsAnime
{
    public partial class InicioForm : Form
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
