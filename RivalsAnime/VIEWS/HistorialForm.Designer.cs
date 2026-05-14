namespace RivalsAnime.VIEWS
{
    partial class HistorialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialForm));
            dgvHistorial = new DataGridView();
            btnsalir = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorial
            // 
            dgvHistorial.AccessibleDescription = "dgvHistorial";
            dgvHistorial.AccessibleName = "datagridHistorial";
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(12, 88);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(776, 350);
            dgvHistorial.TabIndex = 0;
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
            btnsalir.Location = new Point(12, 12);
            btnsalir.Name = "btnsalir";
            btnsalir.Size = new Size(134, 66);
            btnsalir.TabIndex = 19;
            btnsalir.UseVisualStyleBackColor = false;
            btnsalir.Click += btnsalir_Click;
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
            button1.Font = new Font("Stencil", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.OrangeRed;
            button1.Location = new Point(626, 2);
            button1.Name = "button1";
            button1.Size = new Size(162, 86);
            button1.TabIndex = 20;
            button1.Text = "EXPORTAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // HistorialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnsalir);
            Controls.Add(dgvHistorial);
            Name = "HistorialForm";
            Text = "HistorialForm";
            Load += HistorialForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHistorial;
        private Button btnsalir;
        private Button button1;
    }
}