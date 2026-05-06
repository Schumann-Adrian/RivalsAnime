using MySql.Data.MySqlClient;
using RivalsAnime.Controller;
using RivalsAnime.Database;
using RivalsAnime.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
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

            comboRol.Items.Add("Admin");
            comboRol.Items.Add("Usuario");

            comboRol.SelectedIndex = 0;

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuario.Text.Trim();
            string contraseña = textBoxContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contraseña) ||
                comboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos ❌");
                return;
            }

            UsuarioDTO dto = new UsuarioDTO()
            {
                Usuario = usuario,
                Password = Hash(contraseña),
                Rol = comboRol.SelectedIndex + 1
            };

            UsuarioController service = new UsuarioController();

            bool resultado = service.Registrar(dto);

            if (resultado)
            {
                MessageBox.Show("Registrado correctamente 🔥");

                // 🧹 Limpiar campos
                textBoxUsuario.Clear();
                textBoxContraseña.Clear();
                comboRol.SelectedIndex = 0;
                LoginForm loginForm = new LoginForm();
                this.Close();
                loginForm.Show();

            }
            else
            {
                MessageBox.Show("El usuario ya existe ❌");
            }


        }

        private string Hash(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {

            comboRol.SelectedIndex = 0;
        }
    }
}
