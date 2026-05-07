namespace RivalsAnime.VIEWS
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            btnLeer = new Button();
            button1 = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            dataGridPersonajes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridPersonajes).BeginInit();
            SuspendLayout();
            // 
            // btnLeer
            // 
            btnLeer.BackColor = Color.Transparent;
            btnLeer.BackgroundImage = (Image)resources.GetObject("btnLeer.BackgroundImage");
            btnLeer.BackgroundImageLayout = ImageLayout.Stretch;
            btnLeer.FlatAppearance.BorderSize = 0;
            btnLeer.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLeer.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLeer.FlatStyle = FlatStyle.Flat;
            btnLeer.Location = new Point(157, 12);
            btnLeer.Name = "btnLeer";
            btnLeer.Size = new Size(144, 66);
            btnLeer.TabIndex = 2;
            btnLeer.UseVisualStyleBackColor = false;
            btnLeer.Click += btnLeer_Click;
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
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(0, 12);
            button1.Name = "button1";
            button1.Size = new Size(151, 66);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Transparent;
            btnActualizar.BackgroundImage = (Image)resources.GetObject("btnActualizar.BackgroundImage");
            btnActualizar.BackgroundImageLayout = ImageLayout.Stretch;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnActualizar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Location = new Point(497, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(144, 66);
            btnActualizar.TabIndex = 8;
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.BackgroundImage = (Image)resources.GetObject("btnEliminar.BackgroundImage");
            btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnEliminar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Location = new Point(647, 12);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(144, 66);
            btnEliminar.TabIndex = 9;
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dataGridPersonajes
            // 
            dataGridPersonajes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPersonajes.Location = new Point(12, 84);
            dataGridPersonajes.Name = "dataGridPersonajes";
            dataGridPersonajes.Size = new Size(776, 354);
            dataGridPersonajes.TabIndex = 10;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridPersonajes);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(button1);
            Controls.Add(btnLeer);
            Name = "AdminForm";
            Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)dataGridPersonajes).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnLeer;
        private Button button1;
        private Button btnActualizar;
        private Button btnEliminar;
        private DataGridView dataGridPersonajes;
    }
}