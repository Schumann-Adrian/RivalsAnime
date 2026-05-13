namespace RivalsAnime.VIEWS
{
    partial class CombateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombateForm));
            picJugador1 = new PictureBox();
            picCPU1 = new PictureBox();
            progressJugador = new ProgressBar();
            progressCPU = new ProgressBar();
            btnAtaque = new Button();
            btnHabilidad = new Button();
            ((System.ComponentModel.ISupportInitialize)picJugador1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCPU1).BeginInit();
            SuspendLayout();
            // 
            // picJugador1
            // 
            picJugador1.BackColor = Color.Transparent;
            picJugador1.BackgroundImageLayout = ImageLayout.Zoom;
            picJugador1.Location = new Point(161, 123);
            picJugador1.Name = "picJugador1";
            picJugador1.Size = new Size(139, 97);
            picJugador1.TabIndex = 0;
            picJugador1.TabStop = false;
            // 
            // picCPU1
            // 
            picCPU1.BackColor = Color.Transparent;
            picCPU1.BackgroundImageLayout = ImageLayout.Zoom;
            picCPU1.Location = new Point(433, 123);
            picCPU1.Name = "picCPU1";
            picCPU1.Size = new Size(139, 97);
            picCPU1.TabIndex = 1;
            picCPU1.TabStop = false;
            // 
            // progressJugador
            // 
            progressJugador.Location = new Point(161, 80);
            progressJugador.Name = "progressJugador";
            progressJugador.Size = new Size(100, 23);
            progressJugador.TabIndex = 2;
            // 
            // progressCPU
            // 
            progressCPU.Location = new Point(487, 80);
            progressCPU.Name = "progressCPU";
            progressCPU.Size = new Size(100, 23);
            progressCPU.TabIndex = 3;
            // 
            // btnAtaque
            // 
            btnAtaque.BackColor = Color.Transparent;
            btnAtaque.BackgroundImage = (Image)resources.GetObject("btnAtaque.BackgroundImage");
            btnAtaque.BackgroundImageLayout = ImageLayout.Stretch;
            btnAtaque.FlatAppearance.BorderSize = 0;
            btnAtaque.FlatStyle = FlatStyle.Flat;
            btnAtaque.Location = new Point(69, 323);
            btnAtaque.Name = "btnAtaque";
            btnAtaque.Size = new Size(160, 103);
            btnAtaque.TabIndex = 4;
            btnAtaque.UseVisualStyleBackColor = false;
            btnAtaque.Click += btnAtaque_Click_1;
            // 
            // btnHabilidad
            // 
            btnHabilidad.BackColor = Color.Transparent;
            btnHabilidad.BackgroundImage = (Image)resources.GetObject("btnHabilidad.BackgroundImage");
            btnHabilidad.BackgroundImageLayout = ImageLayout.Stretch;
            btnHabilidad.FlatAppearance.BorderSize = 0;
            btnHabilidad.FlatStyle = FlatStyle.Flat;
            btnHabilidad.Location = new Point(256, 318);
            btnHabilidad.Name = "btnHabilidad";
            btnHabilidad.Size = new Size(157, 112);
            btnHabilidad.TabIndex = 5;
            btnHabilidad.UseVisualStyleBackColor = false;
            btnHabilidad.Click += btnHabilidad_Click_1;
            // 
            // CombateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHabilidad);
            Controls.Add(btnAtaque);
            Controls.Add(progressCPU);
            Controls.Add(progressJugador);
            Controls.Add(picCPU1);
            Controls.Add(picJugador1);
            Name = "CombateForm";
            Text = "CombateForm";
            ((System.ComponentModel.ISupportInitialize)picJugador1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCPU1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picJugador1;
        private PictureBox picCPU1;
        private ProgressBar progressJugador;
        private ProgressBar progressCPU;
        private Button btnAtaque;
        private Button btnHabilidad;
    }
}