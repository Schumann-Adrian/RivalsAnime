using RivalsAnime.Controller;
using System;
using System.Windows.Forms;

namespace RivalsAnime.VIEWS
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            // 🔥 IMPORTANTE → se ejecuta cada vez que vuelves al form
            this.Activated += AdminForm_Activated;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            // 🔥 PASAMOS EL ADMIN ACTUAL
            CrearForm crear = new CrearForm(this);
            crear.Show();
        }

        public void CargarPersonajes()
        {
            PersonajeController controller = new PersonajeController();

            dataGridPersonajes.DataSource = null;
            dataGridPersonajes.DataSource = controller.ObtenerPersonajes();

            // 🎨 ESTILO (AQUÍ ES DONDE FUNCIONA SEGURO)

            dataGridPersonajes.BorderStyle = BorderStyle.None;
            dataGridPersonajes.BackgroundColor = Color.FromArgb(25, 25, 25);

            dataGridPersonajes.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridPersonajes.DefaultCellStyle.ForeColor = Color.White;

            dataGridPersonajes.DefaultCellStyle.SelectionBackColor = Color.Orange;
            dataGridPersonajes.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridPersonajes.EnableHeadersVisualStyles = false;
            dataGridPersonajes.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dataGridPersonajes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridPersonajes.RowHeadersVisible = false;

            dataGridPersonajes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridPersonajes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPersonajes.ReadOnly = true;

            // 🔥 NOMBRES BONITOS
            dataGridPersonajes.Columns["Nombre"].HeaderText = "👤 Personaje";
            dataGridPersonajes.Columns["Vida"].HeaderText = "❤️ Vida";
            dataGridPersonajes.Columns["Ataque"].HeaderText = "⚔️ Ataque";
            dataGridPersonajes.Columns["Defensa"].HeaderText = "🛡️ Defensa";
            dataGridPersonajes.Columns["Habilidad"].HeaderText = "✨ Habilidad";
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            CargarPersonajes();

        }

        // 🔥 CLAVE → se ejecuta cada vez que vuelves al Admin
        private void AdminForm_Activated(object sender, EventArgs e)
        {
            CargarPersonajes();
        }
    }
}