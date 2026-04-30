using RivalsAnime.Controller;
using RivalsAnime.Model;
using RivalsAnime.VIEWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RivalsAnime
{
    public partial class LoginForm : Form
    {
        private object textBoxUsuario;
        private object textBoxContraseña;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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
        }

        private string Hash(string contraseña)
        {
            throw new NotImplementedException();
        }
    }
    }
