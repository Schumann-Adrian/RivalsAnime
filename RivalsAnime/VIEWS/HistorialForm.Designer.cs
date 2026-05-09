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
            datagridHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)datagridHistorial).BeginInit();
            SuspendLayout();
            // 
            // datagridHistorial
            // 
            datagridHistorial.AccessibleDescription = "datagridHistorial";
            datagridHistorial.AccessibleName = "datagridHistorial";
            datagridHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridHistorial.Location = new Point(12, 88);
            datagridHistorial.Name = "datagridHistorial";
            datagridHistorial.Size = new Size(776, 350);
            datagridHistorial.TabIndex = 0;
            // 
            // HistorialForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(datagridHistorial);
            Name = "HistorialForm";
            Text = "HistorialForm";
            ((System.ComponentModel.ISupportInitialize)datagridHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView datagridHistorial;
    }
}