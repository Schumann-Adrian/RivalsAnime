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
    public partial class LoginForm : Form
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

            // 🔴 VALIDACIÓN
            if (string.IsNullOrWhiteSpace(usuario) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Introduce usuario y contraseña ❌");
                return;
            }

            // 🔐 HASH DE LA CONTRASEÑA
            string passwordHash = Hash(contraseña);

            UsuarioDTO dto = new UsuarioDTO()
            {
                Usuario = usuario,
                Password = passwordHash
            };

            UsuarioController controller = new UsuarioController();

            int resultado = controller.Login(dto);

            // 🔍 RESULTADOS
            if (resultado == -1)
            {
                MessageBox.Show("Error en la conexión ❌");
            }
            else if (resultado == 0)
            {
                MessageBox.Show("Credenciales incorrectas ❌");
            }
            else
            {
                MessageBox.Show("Login correcto ✅");

                // 🎯 AQUÍ PUEDES REDIRIGIR SEGÚN ROL
                if (resultado == 1) // Admin
                {
                    MessageBox.Show("Eres ADMIN 🔥");
                }
                else if (resultado == 2) // Usuario
                {
                    MessageBox.Show("Eres USUARIO 👤");
                }

                 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm registro = new RegisterForm();
            registro.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBoxUsuarioLogin.Text.Trim();
            string contraseña = textBoxContraseñaLogin.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Completa todos los campos ❌");
                return;
            }

            UsuarioDTO dto = new UsuarioDTO()
            {
                Usuario = usuario,
                Password = Hash(contraseña) // 🔐 IMPORTANTE (igual que en registro)
            };

            UsuarioController service = new UsuarioController();

            int rol = service.Login(dto);

            if (rol == 1)
            {
                MessageBox.Show("Bienvenido Admin 🛡️");
            }
            else if (rol == 2)
            {
                MessageBox.Show("Bienvenido Usuario ⚔️");
            }
            else if (rol == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrectos ❌");
            }
            else
            {
                MessageBox.Show("Error en el sistema ⚠️");
            }
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Close();
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
