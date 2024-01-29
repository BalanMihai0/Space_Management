namespace Individual_sem2
{
    partial class FormLogin
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
            lblLogin = new Label();
            tbLoginUsername = new TextBox();
            tbLoginPassword = new TextBox();
            btnLogin = new Button();
            groupBox1 = new GroupBox();
            lblFailedLogIn = new Label();
            label4 = new Label();
            btnRegister = new Button();
            lblLoginError = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Verdana", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogin.ForeColor = SystemColors.ControlLightLight;
            lblLogin.Location = new Point(43, 100);
            lblLogin.Name = "lblLogin";
            lblLogin.RightToLeft = RightToLeft.Yes;
            lblLogin.Size = new Size(500, 45);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Sign in to your account";
            // 
            // tbLoginUsername
            // 
            tbLoginUsername.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbLoginUsername.Location = new Point(246, 200);
            tbLoginUsername.Name = "tbLoginUsername";
            tbLoginUsername.Size = new Size(298, 35);
            tbLoginUsername.TabIndex = 1;
            // 
            // tbLoginPassword
            // 
            tbLoginPassword.Font = new Font("Verdana", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbLoginPassword.Location = new Point(246, 283);
            tbLoginPassword.Name = "tbLoginPassword";
            tbLoginPassword.Size = new Size(298, 35);
            tbLoginPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaptionText;
            btnLogin.Font = new Font("Verdana", 19.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.ForeColor = SystemColors.ButtonFace;
            btnLogin.Location = new Point(38, 411);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(506, 107);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaptionText;
            groupBox1.Controls.Add(lblFailedLogIn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnRegister);
            groupBox1.Controls.Add(lblLoginError);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbLoginUsername);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(lblLogin);
            groupBox1.Controls.Add(tbLoginPassword);
            groupBox1.Location = new Point(1, -12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(587, 1046);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // lblFailedLogIn
            // 
            lblFailedLogIn.AutoSize = true;
            lblFailedLogIn.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblFailedLogIn.ForeColor = Color.Red;
            lblFailedLogIn.Location = new Point(59, 341);
            lblFailedLogIn.Name = "lblFailedLogIn";
            lblFailedLogIn.Size = new Size(202, 34);
            lblFailedLogIn.TabIndex = 10;
            lblFailedLogIn.Text = "warning here";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(43, 533);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(396, 38);
            label4.TabIndex = 9;
            label4.Text = "?Don't have an account yet";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.ActiveCaptionText;
            btnRegister.Font = new Font("Verdana", 19.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = SystemColors.ButtonFace;
            btnRegister.Location = new Point(38, 588);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(506, 107);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            btnRegister.MouseEnter += btnRegister_MouseEnter;
            btnRegister.MouseLeave += btnRegister_MouseLeave;
            // 
            // lblLoginError
            // 
            lblLoginError.AutoSize = true;
            lblLoginError.ForeColor = Color.Red;
            lblLoginError.Location = new Point(19, 245);
            lblLoginError.Margin = new Padding(2, 0, 2, 0);
            lblLoginError.Name = "lblLoginError";
            lblLoginError.Size = new Size(0, 20);
            lblLoginError.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoIndividual;
            pictureBox1.Location = new Point(114, 717);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(325, 219);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(59, 283);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(158, 38);
            label2.TabIndex = 5;
            label2.Text = ":Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(113, 205);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(105, 38);
            label1.TabIndex = 4;
            label1.Text = ":Email";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.solarSystemSpin;
            pictureBox2.Location = new Point(585, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1319, 1035);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(702, 151);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 6;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1902, 1033);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            ForeColor = SystemColors.ButtonFace;
            Name = "FormLogin";
            Text = "Sign In To Your Astra Dynamics Account!";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox tbLoginUsername;
        private TextBox tbLoginPassword;
        private Button btnLogin;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label lblLoginError;
        private Label label4;
        private Button btnRegister;
        private Label lblFailedLogIn;
    }
}