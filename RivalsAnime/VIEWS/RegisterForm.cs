using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RivalsAnime.VIEWS
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text.Trim();
            string contraseña = textBoxContraseña.Text.Trim();

            // 🔴 Validar campos vacíos
            if (string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(contraseña) ||
                comboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos ❌");
                return;
            }

            int rol = comboRol.SelectedIndex + 1;

            Conexion con = new Conexion();
            MySqlConnection conn = con.establecerConexion();

            if (conn != null)
            {
                // 🔍 Comprobar si el usuario ya existe
                string check = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario=@u";
                MySqlCommand checkCmd = new MySqlCommand(check, conn);
                checkCmd.Parameters.AddWithValue("@u", usuario);

                int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existe > 0)
                {
                    MessageBox.Show("El usuario ya existe ❌");
                    conn.Close();
                    return;
                }

                // 💾 Insertar usuario
                string query = "INSERT INTO usuarios (nombre_usuario, password_hash, tipo_rol) VALUES (@u, @p, @r)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", usuario);
                cmd.Parameters.AddWithValue("@p", contraseña);
                cmd.Parameters.AddWithValue("@r", rol);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario registrado correctamente 🔥");

                conn.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            comboRol.Items.Add("🛡️ Admin");
            comboRol.Items.Add("⚔️ Usuario");

            comboRol.SelectedIndex = 0;
        }
    }
}
