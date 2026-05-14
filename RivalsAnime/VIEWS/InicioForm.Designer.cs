namespace RivalsAnime
{
    partial class InicioForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioForm));
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.NoMove2D;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Alagard", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.OrangeRed;
            button1.Location = new Point(388, 307);
            button1.MaximumSize = new Size(256, 131);
            button1.MinimumSize = new Size(256, 131);
            button1.Name = "button1";
            button1.Size = new Size(256, 131);
            button1.TabIndex = 1;
            button1.Text = " COMENZAR!";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // InicioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Inicio;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1043, 534);
            Controls.Add(button1);
            Name = "InicioForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}
