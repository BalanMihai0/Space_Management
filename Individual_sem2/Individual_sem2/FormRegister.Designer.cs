namespace Individual_sem2
{
    partial class FormRegister
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogin = new Label();
            tbRegisterEmail = new TextBox();
            tbRegisterPassword = new TextBox();
            groupBox1 = new GroupBox();
            lblInvalidLastName = new Label();
            lblInvalidDate = new Label();
            lblInvalidURL = new Label();
            lblPasswordWeak = new Label();
            lblPasswordsDontMatch = new Label();
            lblInvalidFirstName = new Label();
            lblEmailInvalid = new Label();
            tbRegisterProfilePic = new TextBox();
            dtpRegisterBirthday = new DateTimePicker();
            tbRegisterLastName = new TextBox();
            tbRegisterFirstName = new TextBox();
            tbRegisterConfrimPassword = new TextBox();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
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
            lblLogin.Location = new Point(17, 28);
            lblLogin.Name = "lblLogin";
            lblLogin.RightToLeft = RightToLeft.Yes;
            lblLogin.Size = new Size(368, 36);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "!Create your account";
            // 
            // tbRegisterEmail
            // 
            tbRegisterEmail.BorderStyle = BorderStyle.FixedSingle;
            tbRegisterEmail.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbRegisterEmail.Location = new Point(247, 138);
            tbRegisterEmail.Margin = new Padding(3, 2, 3, 2);
            tbRegisterEmail.Name = "tbRegisterEmail";
            tbRegisterEmail.Size = new Size(235, 25);
            tbRegisterEmail.TabIndex = 1;
            // 
            // tbRegisterPassword
            // 
            tbRegisterPassword.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbRegisterPassword.Location = new Point(247, 220);
            tbRegisterPassword.Margin = new Padding(3, 2, 3, 2);
            tbRegisterPassword.Name = "tbRegisterPassword";
            tbRegisterPassword.Size = new Size(235, 25);
            tbRegisterPassword.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaptionText;
            groupBox1.Controls.Add(lblInvalidLastName);
            groupBox1.Controls.Add(lblInvalidDate);
            groupBox1.Controls.Add(lblInvalidURL);
            groupBox1.Controls.Add(lblPasswordWeak);
            groupBox1.Controls.Add(lblPasswordsDontMatch);
            groupBox1.Controls.Add(lblInvalidFirstName);
            groupBox1.Controls.Add(lblEmailInvalid);
            groupBox1.Controls.Add(tbRegisterProfilePic);
            groupBox1.Controls.Add(dtpRegisterBirthday);
            groupBox1.Controls.Add(tbRegisterLastName);
            groupBox1.Controls.Add(tbRegisterFirstName);
            groupBox1.Controls.Add(tbRegisterConfrimPassword);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnRegister);
            groupBox1.Controls.Add(lblLoginError);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbRegisterEmail);
            groupBox1.Controls.Add(lblLogin);
            groupBox1.Controls.Add(tbRegisterPassword);
            groupBox1.Location = new Point(822, -9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(861, 800);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // lblInvalidLastName
            // 
            lblInvalidLastName.AutoSize = true;
            lblInvalidLastName.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblInvalidLastName.ForeColor = Color.Red;
            lblInvalidLastName.Location = new Point(636, 253);
            lblInvalidLastName.Name = "lblInvalidLastName";
            lblInvalidLastName.Size = new Size(157, 26);
            lblInvalidLastName.TabIndex = 28;
            lblInvalidLastName.Text = "warning here";
            // 
            // lblInvalidDate
            // 
            lblInvalidDate.AutoSize = true;
            lblInvalidDate.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblInvalidDate.ForeColor = Color.Red;
            lblInvalidDate.Location = new Point(636, 328);
            lblInvalidDate.Name = "lblInvalidDate";
            lblInvalidDate.Size = new Size(157, 26);
            lblInvalidDate.TabIndex = 27;
            lblInvalidDate.Text = "warning here";
            // 
            // lblInvalidURL
            // 
            lblInvalidURL.AutoSize = true;
            lblInvalidURL.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblInvalidURL.ForeColor = Color.Red;
            lblInvalidURL.Location = new Point(406, 415);
            lblInvalidURL.Name = "lblInvalidURL";
            lblInvalidURL.Size = new Size(157, 26);
            lblInvalidURL.TabIndex = 26;
            lblInvalidURL.Text = "warning here";
            // 
            // lblPasswordWeak
            // 
            lblPasswordWeak.AutoSize = true;
            lblPasswordWeak.Font = new Font("Verdana", 13.8F, FontStyle.Italic, GraphicsUnit.Point);
            lblPasswordWeak.ForeColor = Color.Red;
            lblPasswordWeak.Location = new Point(36, 253);
            lblPasswordWeak.Name = "lblPasswordWeak";
            lblPasswordWeak.Size = new Size(135, 23);
            lblPasswordWeak.TabIndex = 25;
            lblPasswordWeak.Text = "warning here";
            // 
            // lblPasswordsDontMatch
            // 
            lblPasswordsDontMatch.AutoSize = true;
            lblPasswordsDontMatch.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblPasswordsDontMatch.ForeColor = Color.Red;
            lblPasswordsDontMatch.Location = new Point(247, 335);
            lblPasswordsDontMatch.Name = "lblPasswordsDontMatch";
            lblPasswordsDontMatch.Size = new Size(157, 26);
            lblPasswordsDontMatch.TabIndex = 24;
            lblPasswordsDontMatch.Text = "warning here";
            // 
            // lblInvalidFirstName
            // 
            lblInvalidFirstName.AutoSize = true;
            lblInvalidFirstName.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblInvalidFirstName.ForeColor = Color.Red;
            lblInvalidFirstName.Location = new Point(636, 161);
            lblInvalidFirstName.Name = "lblInvalidFirstName";
            lblInvalidFirstName.Size = new Size(157, 26);
            lblInvalidFirstName.TabIndex = 23;
            lblInvalidFirstName.Text = "warning here";
            // 
            // lblEmailInvalid
            // 
            lblEmailInvalid.AutoSize = true;
            lblEmailInvalid.Font = new Font("Verdana", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            lblEmailInvalid.ForeColor = Color.Red;
            lblEmailInvalid.Location = new Point(247, 162);
            lblEmailInvalid.Name = "lblEmailInvalid";
            lblEmailInvalid.Size = new Size(157, 26);
            lblEmailInvalid.TabIndex = 22;
            lblEmailInvalid.Text = "warning here";
            // 
            // tbRegisterProfilePic
            // 
            tbRegisterProfilePic.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbRegisterProfilePic.Location = new Point(406, 382);
            tbRegisterProfilePic.Margin = new Padding(3, 2, 3, 2);
            tbRegisterProfilePic.Name = "tbRegisterProfilePic";
            tbRegisterProfilePic.Size = new Size(422, 25);
            tbRegisterProfilePic.TabIndex = 21;
            // 
            // dtpRegisterBirthday
            // 
            dtpRegisterBirthday.BackColor = Color.FromArgb(64, 64, 64);
            dtpRegisterBirthday.CalendarForeColor = Color.White;
            dtpRegisterBirthday.CalendarMonthBackground = Color.FromArgb(64, 64, 64);
            dtpRegisterBirthday.CalendarTitleBackColor = Color.FromArgb(64, 64, 64);
            dtpRegisterBirthday.CalendarTitleForeColor = Color.White;
            dtpRegisterBirthday.CalendarTrailingForeColor = Color.Silver;
            dtpRegisterBirthday.CustomFormat = "dd/MM/yyyy";
            dtpRegisterBirthday.ForeColor = Color.White;
            dtpRegisterBirthday.Format = DateTimePickerFormat.Short;
            dtpRegisterBirthday.Location = new Point(694, 295);
            dtpRegisterBirthday.Margin = new Padding(3, 2, 3, 2);
            dtpRegisterBirthday.Name = "dtpRegisterBirthday";
            dtpRegisterBirthday.Size = new Size(134, 23);
            dtpRegisterBirthday.TabIndex = 20;
            dtpRegisterBirthday.Value = new DateTime(2023, 2, 28, 0, 0, 0, 0);
            // 
            // tbRegisterLastName
            // 
            tbRegisterLastName.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbRegisterLastName.Location = new Point(688, 220);
            tbRegisterLastName.Margin = new Padding(3, 2, 3, 2);
            tbRegisterLastName.Name = "tbRegisterLastName";
            tbRegisterLastName.Size = new Size(144, 25);
            tbRegisterLastName.TabIndex = 19;
            // 
            // tbRegisterFirstName
            // 
            tbRegisterFirstName.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbRegisterFirstName.Location = new Point(688, 134);
            tbRegisterFirstName.Margin = new Padding(3, 2, 3, 2);
            tbRegisterFirstName.Name = "tbRegisterFirstName";
            tbRegisterFirstName.Size = new Size(144, 25);
            tbRegisterFirstName.TabIndex = 18;
            // 
            // tbRegisterConfrimPassword
            // 
            tbRegisterConfrimPassword.Font = new Font("Verdana", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbRegisterConfrimPassword.Location = new Point(247, 304);
            tbRegisterConfrimPassword.Margin = new Padding(3, 2, 3, 2);
            tbRegisterConfrimPassword.Name = "tbRegisterConfrimPassword";
            tbRegisterConfrimPassword.Size = new Size(235, 25);
            tbRegisterConfrimPassword.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(21, 297);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.Yes;
            label9.Size = new Size(213, 29);
            label9.TabIndex = 14;
            label9.Text = ":Repeat Password";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(21, 376);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(347, 29);
            label7.TabIndex = 12;
            label7.Text = ":Profile Picture URL(optional)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(507, 290);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(166, 29);
            label6.TabIndex = 11;
            label6.Text = ":Date of Birth";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(536, 214);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(139, 29);
            label5.TabIndex = 10;
            label5.Text = ":Last Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(530, 128);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(144, 29);
            label4.TabIndex = 9;
            label4.Text = ":First Name";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = SystemColors.ActiveCaptionText;
            btnRegister.Font = new Font("Verdana", 19.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.ForeColor = SystemColors.ButtonFace;
            btnRegister.Location = new Point(201, 452);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(443, 80);
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
            lblLoginError.Location = new Point(17, 184);
            lblLoginError.Margin = new Padding(2, 0, 2, 0);
            lblLoginError.Name = "lblLoginError";
            lblLoginError.Size = new Size(0, 15);
            lblLoginError.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoIndividual;
            pictureBox1.Location = new Point(276, 550);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(284, 164);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(102, 214);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(126, 29);
            label2.TabIndex = 5;
            label2.Text = ":Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Trebuchet MS", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(148, 130);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(84, 29);
            label1.TabIndex = 4;
            label1.Text = ":Email";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = Properties.Resources.Earth_Background;
            pictureBox2.Location = new Point(-1, -94);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1154, 857);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(614, 113);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 6;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1681, 715);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            ForeColor = SystemColors.ButtonFace;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormRegister";
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
        private TextBox tbRegisterEmail;
        private TextBox tbRegisterPassword;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label lblLoginError;
        private Button btnRegister;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label7;
        private DateTimePicker dtpRegisterBirthday;
        private TextBox tbRegisterLastName;
        private TextBox tbRegisterFirstName;
        private TextBox tbRegisterConfrimPassword;
        private Label label9;
        private TextBox tbRegisterProfilePic;
        private Label lblInvalidLastName;
        private Label lblInvalidDate;
        private Label lblInvalidURL;
        private Label lblPasswordWeak;
        private Label lblPasswordsDontMatch;
        private Label lblInvalidFirstName;
        private Label lblEmailInvalid;
    }
}