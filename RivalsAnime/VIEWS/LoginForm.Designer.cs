namespace RivalsAnime
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            button1 = new Button();
            button2 = new Button();
            textBoxUsuarioLogin = new TextBox();
            textBoxContraseñaLogin = new TextBox();
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
            button1.Location = new Point(173, 264);
            button1.Name = "button1";
            button1.Size = new Size(183, 126);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(431, 228);
            button2.Name = "button2";
            button2.Size = new Size(200, 184);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBoxUsuarioLogin
            // 
            textBoxUsuarioLogin.BackColor = SystemColors.InactiveCaptionText;
            textBoxUsuarioLogin.BorderStyle = BorderStyle.None;
            textBoxUsuarioLogin.ForeColor = SystemColors.Window;
            textBoxUsuarioLogin.Location = new Point(244, 188);
            textBoxUsuarioLogin.Name = "textBoxUsuarioLogin";
            textBoxUsuarioLogin.Size = new Size(281, 16);
            textBoxUsuarioLogin.TabIndex = 2;
            // 
            // textBoxContraseñaLogin
            // 
            textBoxContraseñaLogin.BackColor = SystemColors.InactiveCaptionText;
            textBoxContraseñaLogin.BorderStyle = BorderStyle.None;
            textBoxContraseñaLogin.ForeColor = SystemColors.Menu;
            textBoxContraseñaLogin.Location = new Point(244, 252);
            textBoxContraseñaLogin.Name = "textBoxContraseñaLogin";
            textBoxContraseñaLogin.Size = new Size(281, 16);
            textBoxContraseñaLogin.TabIndex = 3;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 445);
            Controls.Add(textBoxContraseñaLogin);
            Controls.Add(textBoxUsuarioLogin);
            Controls.Add(button2);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBoxUsuarioLogin;
        private TextBox textBoxContraseñaLogin;
    }
}