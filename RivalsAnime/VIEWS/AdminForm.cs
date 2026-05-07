using RivalsAnime.Controller;
using RivalsAnime.Model;
using System;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;


namespace RivalsAnime.VIEWS
{
    public partial class AdminForm : BaseForm
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
            dataGridPersonajes.ReadOnly = false;

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

        private void btnLeer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos JSON (*.json)|*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(ofd.FileName);

                    List<PersonajeDTO> personajes =
                        JsonSerializer.Deserialize<List<PersonajeDTO>>(json);

                    PersonajeController controller = new PersonajeController();

                    foreach (var p in personajes)
                    {
                        controller.CrearOActualizarPersonaje(p);
                    }

                    MessageBox.Show("Personajes importados 🔥");

                    // 🔥 REFRESCAR GRID
                    CargarPersonajes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (dataGridPersonajes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un personaje ❌");
                return;
            }

            DataGridViewRow fila = dataGridPersonajes.SelectedRows[0];

            string nombreNuevo = fila.Cells["Nombre"].Value.ToString();

            // comprobar duplicado en el grid
            foreach (DataGridViewRow row in dataGridPersonajes.Rows)
            {
                if (row.Index != fila.Index) // ignorar la misma fila
                {
                    if (row.Cells["Nombre"].Value.ToString() == nombreNuevo)
                    {
                        MessageBox.Show("Ya existe un personaje con ese nombre ❌");
                        return;
                    }
                }
            }

            PersonajeDTO p = new PersonajeDTO()
            {
                Nombre = fila.Cells["Nombre"].Value.ToString(),
                Vida = Convert.ToInt32(fila.Cells["Vida"].Value),
                Ataque = Convert.ToInt32(fila.Cells["Ataque"].Value),
                Defensa = Convert.ToInt32(fila.Cells["Defensa"].Value),
                Habilidad = fila.Cells["Habilidad"].Value.ToString()
            };

            PersonajeController controller = new PersonajeController();

            bool resultado = controller.ActualizarPersonaje(p);

            if (resultado)
            {
                MessageBox.Show("Personaje actualizado 🔄");

                CargarPersonajes();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridPersonajes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un personaje ❌");
                return;
            }

            DataGridViewRow fila = dataGridPersonajes.SelectedRows[0];
            string nombre = fila.Cells["Nombre"].Value.ToString();

            // 🔥 confirmación (MUY IMPORTANTE)
            DialogResult confirm = MessageBox.Show(
                $"¿Eliminar a {nombre}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            PersonajeController controller = new PersonajeController();

            bool resultado = controller.EliminarPersonaje(nombre);

            if (resultado)
            {
                MessageBox.Show("Personaje eliminado 🗑️");

                CargarPersonajes(); // 🔥 refrescar tabla
            }
            else
            {
                MessageBox.Show("No se pudo eliminar ❌");
            }
        }
    }
}