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
            panelNarracion = new Panel();
            lblNarracion = new Label();
            btnsalir = new Button();
            ((System.ComponentModel.ISupportInitialize)picJugador1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCPU1).BeginInit();
            panelNarracion.SuspendLayout();
            SuspendLayout();
            // 
            // picJugador1
            // 
            picJugador1.BackColor = Color.Transparent;
            picJugador1.BackgroundImageLayout = ImageLayout.Zoom;
            picJugador1.Location = new Point(105, 123);
            picJugador1.Name = "picJugador1";
            picJugador1.Size = new Size(201, 194);
            picJugador1.TabIndex = 0;
            picJugador1.TabStop = false;
            // 
            // picCPU1
            // 
            picCPU1.BackColor = Color.Transparent;
            picCPU1.BackgroundImageLayout = ImageLayout.Zoom;
            picCPU1.Location = new Point(433, 123);
            picCPU1.Name = "picCPU1";
            picCPU1.Size = new Size(198, 194);
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
            btnAtaque.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnAtaque.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnAtaque.FlatStyle = FlatStyle.Flat;
            btnAtaque.Font = new Font("Stencil", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAtaque.ForeColor = Color.OrangeRed;
            btnAtaque.Location = new Point(69, 323);
            btnAtaque.Name = "btnAtaque";
            btnAtaque.Size = new Size(160, 103);
            btnAtaque.TabIndex = 4;
            btnAtaque.Text = "ATAQUE";
            btnAtaque.UseVisualStyleBackColor = false;
            btnAtaque.Click += btnAtaque_Click_1;
            // 
            // btnHabilidad
            // 
            btnHabilidad.BackColor = Color.Transparent;
            btnHabilidad.BackgroundImage = (Image)resources.GetObject("btnHabilidad.BackgroundImage");
            btnHabilidad.BackgroundImageLayout = ImageLayout.Stretch;
            btnHabilidad.FlatAppearance.BorderSize = 0;
            btnHabilidad.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnHabilidad.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHabilidad.FlatStyle = FlatStyle.Flat;
            btnHabilidad.Font = new Font("Stencil", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilidad.ForeColor = Color.OrangeRed;
            btnHabilidad.Location = new Point(256, 318);
            btnHabilidad.Name = "btnHabilidad";
            btnHabilidad.Size = new Size(157, 112);
            btnHabilidad.TabIndex = 5;
            btnHabilidad.Text = "HABILIDAD";
            btnHabilidad.UseVisualStyleBackColor = false;
            btnHabilidad.Click += btnHabilidad_Click_1;
            // 
            // panelNarracion
            // 
            panelNarracion.BackColor = SystemColors.Control;
            panelNarracion.Controls.Add(lblNarracion);
            panelNarracion.Dock = DockStyle.Bottom;
            panelNarracion.Location = new Point(0, 350);
            panelNarracion.MaximumSize = new Size(0, 100);
            panelNarracion.Name = "panelNarracion";
            panelNarracion.Size = new Size(800, 100);
            panelNarracion.TabIndex = 6;
            panelNarracion.Visible = false;
            // 
            // lblNarracion
            // 
            lblNarracion.AutoSize = true;
            lblNarracion.Dock = DockStyle.Fill;
            lblNarracion.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNarracion.ForeColor = SystemColors.Control;
            lblNarracion.Location = new Point(0, 0);
            lblNarracion.Name = "lblNarracion";
            lblNarracion.Size = new Size(0, 25);
            lblNarracion.TabIndex = 7;
            lblNarracion.TextAlign = ContentAlignment.MiddleCenter;
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
            btnsalir.Location = new Point(654, 12);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(134, 66);
            btnsalir.TabIndex = 16;
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click;
            // 
            // CombateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(btnsalir);
            Controls.Add(panelNarracion);
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
            panelNarracion.ResumeLayout(false);
            panelNarracion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picJugador1;
        private PictureBox picCPU1;
        private ProgressBar progressJugador;
        private ProgressBar progressCPU;
        private Button btnAtaque;
        private Button btnHabilidad;
        private Panel panelNarracion;
        private Label lblNarracion;
        private Button btnsalir;
    }
}