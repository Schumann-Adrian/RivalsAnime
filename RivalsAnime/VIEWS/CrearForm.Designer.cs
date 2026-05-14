namespace RivalsAnime.VIEWS
{
    partial class CrearForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearForm));
            button1 = new Button();
            txtNombre = new TextBox();
            txtVida = new TextBox();
            txtAtaque = new TextBox();
            txtDefensa = new TextBox();
            txtHabilidad = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnsalir = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(609, 352);
            button1.Name = "button1";
            button1.Size = new Size(144, 61);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(256, 122);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(281, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtVida
            // 
            txtVida.Location = new Point(256, 181);
            txtVida.Name = "txtVida";
            txtVida.Size = new Size(281, 23);
            txtVida.TabIndex = 2;
            // 
            // txtAtaque
            // 
            txtAtaque.Location = new Point(256, 239);
            txtAtaque.Name = "txtAtaque";
            txtAtaque.Size = new Size(281, 23);
            txtAtaque.TabIndex = 3;
            // 
            // txtDefensa
            // 
            txtDefensa.Location = new Point(256, 304);
            txtDefensa.Name = "txtDefensa";
            txtDefensa.Size = new Size(281, 23);
            txtDefensa.TabIndex = 4;
            // 
            // txtHabilidad
            // 
            txtHabilidad.Location = new Point(256, 372);
            txtHabilidad.Name = "txtHabilidad";
            txtHabilidad.Size = new Size(281, 23);
            txtHabilidad.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(256, 103);
            label1.Name = "label1";
            label1.Size = new Size(65, 16);
            label1.TabIndex = 6;
            label1.Text = "Nombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(255, 128, 0);
            label6.Location = new Point(256, 162);
            label6.Name = "label6";
            label6.Size = new Size(40, 16);
            label6.TabIndex = 11;
            label6.Text = "Vida";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 128, 0);
            label2.Location = new Point(256, 220);
            label2.Name = "label2";
            label2.Size = new Size(61, 16);
            label2.TabIndex = 12;
            label2.Text = "Ataque";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(255, 128, 0);
            label3.Location = new Point(256, 285);
            label3.Name = "label3";
            label3.Size = new Size(68, 16);
            label3.TabIndex = 13;
            label3.Text = "Defensa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(255, 128, 0);
            label4.Location = new Point(256, 352);
            label4.Name = "label4";
            label4.Size = new Size(157, 16);
            label4.TabIndex = 14;
            label4.Text = "Habilidad (Ultimate)";
            // 
            // btnsalir
            // 
            btnsalir.BackColor = Color.Transparent;
            btnsalir.BackgroundImage = (Image)resources.GetObject("btnsalir.BackgroundImage");
            btnsalir.BackgroundImageLayout = ImageLayout.Stretch;
            btnsalir.FlatAppearance.BorderSize = 0;
            btnsalir.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnsalir.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnsalir.FlatStyle = FlatStyle.Flat;
            btnsalir.Location = new Point(26, 352);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(134, 66);
            btnsalir.TabIndex = 15;
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click;
            // 
            // CrearForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnsalir);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(txtHabilidad);
            Controls.Add(txtDefensa);
            Controls.Add(txtAtaque);
            Controls.Add(txtVida);
            Controls.Add(txtNombre);
            Controls.Add(button1);
            Name = "CrearForm";
            Text = "CrearForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtNombre;
        private TextBox txtVida;
        private TextBox txtAtaque;
        private TextBox txtDefensa;
        private TextBox txtHabilidad;
        private Label label1;
        private Label label6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnsalir;
    }
}