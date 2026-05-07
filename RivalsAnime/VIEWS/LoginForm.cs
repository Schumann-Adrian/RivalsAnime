using RivalsAnime.Controller;
using RivalsAnime.Model;
using RivalsAnime.VIEWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace RivalsAnime
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();

            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuarioLogin.Text.Trim();
            string contraseña = textBoxContraseñaLogin.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Introduce usuario y contraseña ❌");
                return;
            }

            string passwordHash = Hash(contraseña);

            UsuarioDTO dto = new UsuarioDTO()
            {
                Usuario = usuario,
                Password = passwordHash
            };

            UsuarioController controller = new UsuarioController();

            int rol = controller.Login(dto);

            if (rol == -1)
            {
                MessageBox.Show("Error en la conexión ❌");
            }
            else if (rol == 0)
            {
                MessageBox.Show("Credenciales incorrectas ❌");
            }
            else if (rol == 1) // ADMIN
            {
                MessageBox.Show("Bienvenido Admin 🛡️");

                AdminForm admin = new AdminForm();
                admin.Show();
                this.Hide();
            }
            else if (rol == 2) // USER
            {
                MessageBox.Show("Bienvenido Usuario ⚔️");

                UserForm user = new UserForm();
                user.Show();
                this.Hide();
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
    }
    }
