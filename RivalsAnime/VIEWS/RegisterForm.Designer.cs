namespace RivalsAnime.VIEWS
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            button1 = new Button();
            textBoxUsuario = new TextBox();
            textBoxContraseña = new TextBox();
            comboRol = new ComboBox();
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
            button1.Location = new Point(289, 343);
            button1.Name = "button1";
            button1.Size = new Size(183, 126);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.BackColor = Color.Black;
            textBoxUsuario.BorderStyle = BorderStyle.None;
            textBoxUsuario.ForeColor = SystemColors.Window;
            textBoxUsuario.Location = new Point(243, 194);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(281, 16);
            textBoxUsuario.TabIndex = 3;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.BackColor = SystemColors.InactiveCaptionText;
            textBoxContraseña.BorderStyle = BorderStyle.None;
            textBoxContraseña.ForeColor = SystemColors.Window;
            textBoxContraseña.Location = new Point(243, 260);
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.Size = new Size(281, 16);
            textBoxContraseña.TabIndex = 4;
            // 
            // comboRol
            // 
            comboRol.BackColor = Color.Black;
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.FlatStyle = FlatStyle.Flat;
            comboRol.ForeColor = Color.DarkOrange;
            comboRol.FormattingEnabled = true;
            comboRol.Location = new Point(243, 323);
            comboRol.Name = "comboRol";
            comboRol.Size = new Size(281, 23);
            comboRol.TabIndex = 5;
            comboRol.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(comboRol);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxUsuario);
            Controls.Add(button1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBoxUsuario;
        private TextBox textBoxContraseña;
        private ComboBox comboRol;
    }
}