namespace RivalsAnime.VIEWS
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            btnbatalla = new Button();
            btnpersonajes = new Button();
            btnhistorial = new Button();
            btnsalir = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnbatalla
            // 
            btnbatalla.BackColor = Color.Transparent;
            btnbatalla.BackgroundImage = Properties.Resources.BatallaBoton;
            btnbatalla.BackgroundImageLayout = ImageLayout.Stretch;
            btnbatalla.FlatAppearance.BorderSize = 0;
            btnbatalla.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnbatalla.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnbatalla.FlatStyle = FlatStyle.Flat;
            btnbatalla.Location = new Point(196, 120);
            btnbatalla.Name = "btnbatalla";
            btnbatalla.Size = new Size(134, 72);
            btnbatalla.TabIndex = 0;
            btnbatalla.UseVisualStyleBackColor = false;
            btnbatalla.Click += btnbatalla_Click;
            // 
            // btnpersonajes
            // 
            btnpersonajes.BackColor = Color.Transparent;
            btnpersonajes.BackgroundImage = Properties.Resources.Personajesboton;
            btnpersonajes.BackgroundImageLayout = ImageLayout.Stretch;
            btnpersonajes.FlatAppearance.BorderSize = 0;
            btnpersonajes.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnpersonajes.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnpersonajes.FlatStyle = FlatStyle.Flat;
            btnpersonajes.Location = new Point(433, 112);
            btnpersonajes.Name = "btnpersonajes";
            btnpersonajes.Size = new Size(145, 88);
            btnpersonajes.TabIndex = 1;
            btnpersonajes.UseVisualStyleBackColor = false;
            btnpersonajes.Click += btnpersonajes_Click;
            // 
            // btnhistorial
            // 
            btnhistorial.BackColor = Color.Transparent;
            btnhistorial.BackgroundImage = Properties.Resources.HistorialBoton;
            btnhistorial.BackgroundImageLayout = ImageLayout.Stretch;
            btnhistorial.FlatAppearance.BorderSize = 0;
            btnhistorial.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnhistorial.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnhistorial.FlatStyle = FlatStyle.Flat;
            btnhistorial.Location = new Point(323, 230);
            btnhistorial.Name = "btnhistorial";
            btnhistorial.Size = new Size(134, 66);
            btnhistorial.TabIndex = 2;
            btnhistorial.UseVisualStyleBackColor = false;
            btnhistorial.Click += btnhistorial_Click;
            // 
            // btnsalir
            // 
            btnsalir.BackColor = Color.Transparent;
            btnsalir.BackgroundImage = Properties.Resources.SalirBoton;
            btnsalir.BackgroundImageLayout = ImageLayout.Stretch;
            btnsalir.FlatAppearance.BorderSize = 0;
            btnsalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnsalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnsalir.FlatStyle = FlatStyle.Flat;
            btnsalir.Location = new Point(323, 335);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(134, 66);
            btnsalir.TabIndex = 3;
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(36, 218);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(220, 223);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(503, 239);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(255, 274);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.FondoBasico;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnsalir);
            Controls.Add(btnhistorial);
            Controls.Add(btnpersonajes);
            Controls.Add(btnbatalla);
            ForeColor = SystemColors.ControlText;
            Name = "UserForm";
            Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnbatalla;
        private Button btnpersonajes;
        private Button btnhistorial;
        private Button btnsalir;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}