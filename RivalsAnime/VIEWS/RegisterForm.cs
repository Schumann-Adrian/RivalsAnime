using MySql.Data.MySqlClient;
using RivalsAnime.Controller;
using RivalsAnime.Database;
using RivalsAnime.Model;
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

            if (string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(contraseña) ||
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
            }
            else
            {
                MessageBox.Show("El usuario ya existe ❌");
            }


        }

        private string Hash(string contraseña)
        {
            throw new NotImplementedException();
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
