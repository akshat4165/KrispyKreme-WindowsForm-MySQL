﻿namespace YourNamespace
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtUsername.Location = new Point(808, 609);
            txtUsername.Margin = new Padding(5, 6, 5, 6);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(322, 50);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtPassword.Location = new Point(808, 704);
            txtPassword.Margin = new Padding(5, 6, 5, 6);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(322, 50);
            txtPassword.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold | FontStyle.Italic);
            lblUsername.ForeColor = Color.White;
            lblUsername.Location = new Point(532, 607);
            lblUsername.Margin = new Padding(5, 0, 5, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(206, 50);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold | FontStyle.Italic);
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(532, 702);
            lblPassword.Margin = new Padding(5, 0, 5, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(196, 50);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.DarkGreen;
            btnLogin.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(751, 828);
            btnLogin.Margin = new Padding(5, 6, 5, 6);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(162, 80);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = KrispyKreme.Properties.Resources.Krispy_Kreme_Login_Logo;
            pictureBox1.Location = new Point(-110, -131);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1797, 659);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGreen;
            ClientSize = new Size(1648, 1034);
            Controls.Add(btnLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnLogin;
        private PictureBox pictureBox1;
    }
}
