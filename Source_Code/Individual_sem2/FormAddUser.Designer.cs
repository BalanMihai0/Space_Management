namespace Individual_sem2
{
    partial class FormAddUser
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
            groupBox2 = new GroupBox();
            btnAddUser = new Button();
            btnAbort = new Button();
            tbProfilePic = new TextBox();
            tbEmail = new TextBox();
            tbPassword = new TextBox();
            tbLastName = new TextBox();
            tbFirstName = new TextBox();
            rbGuest = new RadioButton();
            rbEmployee = new RadioButton();
            rbAdmin = new RadioButton();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblb = new Label();
            label5 = new Label();
            dtpBirthDate = new DateTimePicker();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox2.Controls.Add(dtpBirthDate);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(btnAddUser);
            groupBox2.Controls.Add(btnAbort);
            groupBox2.Controls.Add(tbProfilePic);
            groupBox2.Controls.Add(tbEmail);
            groupBox2.Controls.Add(tbPassword);
            groupBox2.Controls.Add(tbLastName);
            groupBox2.Controls.Add(tbFirstName);
            groupBox2.Controls.Add(rbGuest);
            groupBox2.Controls.Add(rbEmployee);
            groupBox2.Controls.Add(rbAdmin);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(lblb);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(12, 11);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(500, 507);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add a user:";
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = SystemColors.ActiveCaptionText;
            btnAddUser.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddUser.ForeColor = SystemColors.ButtonFace;
            btnAddUser.Location = new Point(272, 420);
            btnAddUser.Margin = new Padding(3, 2, 3, 2);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(213, 53);
            btnAddUser.TabIndex = 19;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnAbort
            // 
            btnAbort.BackColor = SystemColors.ActiveCaptionText;
            btnAbort.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnAbort.ForeColor = SystemColors.ButtonFace;
            btnAbort.Location = new Point(6, 420);
            btnAbort.Margin = new Padding(3, 2, 3, 2);
            btnAbort.Name = "btnAbort";
            btnAbort.Size = new Size(213, 53);
            btnAbort.TabIndex = 18;
            btnAbort.Text = "Abort";
            btnAbort.UseVisualStyleBackColor = false;
            btnAbort.Click += btnAbort_Click;
            // 
            // tbProfilePic
            // 
            tbProfilePic.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbProfilePic.Location = new Point(217, 212);
            tbProfilePic.Name = "tbProfilePic";
            tbProfilePic.Size = new Size(277, 25);
            tbProfilePic.TabIndex = 17;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbEmail.Location = new Point(102, 166);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(277, 25);
            tbEmail.TabIndex = 16;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbPassword.Location = new Point(102, 120);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(277, 25);
            tbPassword.TabIndex = 15;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbLastName.Location = new Point(102, 80);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(277, 25);
            tbLastName.TabIndex = 14;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbFirstName.Location = new Point(102, 37);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(277, 25);
            tbFirstName.TabIndex = 13;
            // 
            // rbGuest
            // 
            rbGuest.AutoSize = true;
            rbGuest.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbGuest.Location = new Point(350, 372);
            rbGuest.Margin = new Padding(3, 2, 3, 2);
            rbGuest.Name = "rbGuest";
            rbGuest.Size = new Size(72, 23);
            rbGuest.TabIndex = 12;
            rbGuest.TabStop = true;
            rbGuest.Text = "Guest: ";
            rbGuest.UseVisualStyleBackColor = true;
            rbGuest.CheckedChanged += rbGuest_CheckedChanged;
            // 
            // rbEmployee
            // 
            rbEmployee.AutoSize = true;
            rbEmployee.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbEmployee.Location = new Point(194, 372);
            rbEmployee.Margin = new Padding(3, 2, 3, 2);
            rbEmployee.Name = "rbEmployee";
            rbEmployee.Size = new Size(93, 23);
            rbEmployee.TabIndex = 11;
            rbEmployee.TabStop = true;
            rbEmployee.Text = "Employee";
            rbEmployee.UseVisualStyleBackColor = true;
            // 
            // rbAdmin
            // 
            rbAdmin.AutoSize = true;
            rbAdmin.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbAdmin.Location = new Point(18, 372);
            rbAdmin.Margin = new Padding(3, 2, 3, 2);
            rbAdmin.Name = "rbAdmin";
            rbAdmin.Size = new Size(120, 23);
            rbAdmin.TabIndex = 10;
            rbAdmin.TabStop = true;
            rbAdmin.Text = "Administrator";
            rbAdmin.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(6, 214);
            label4.Name = "label4";
            label4.Size = new Size(215, 20);
            label4.TabIndex = 9;
            label4.Text = "Profile Picture Url (optional): ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(6, 168);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 8;
            label3.Text = "Email: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(6, 122);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 7;
            label2.Text = "Password: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(6, 80);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 6;
            label1.Text = "Last Name: ";
            // 
            // lblb
            // 
            lblb.AutoSize = true;
            lblb.BackColor = Color.Transparent;
            lblb.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblb.Location = new Point(6, 39);
            lblb.Name = "lblb";
            lblb.Size = new Size(90, 20);
            lblb.TabIndex = 5;
            lblb.Text = "First Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(6, 262);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 20;
            label5.Text = "Birth Date: ";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dtpBirthDate.Location = new Point(101, 254);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(259, 25);
            dtpBirthDate.TabIndex = 21;
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Earth_Background;
            ClientSize = new Size(526, 529);
            Controls.Add(groupBox2);
            Name = "FormAddUser";
            Text = "FormAddUser";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblb;
        private TextBox tbProfilePic;
        private TextBox tbEmail;
        private TextBox tbPassword;
        private TextBox tbLastName;
        private TextBox tbFirstName;
        private RadioButton rbGuest;
        private RadioButton rbEmployee;
        private RadioButton rbAdmin;
        private Button btnAddUser;
        private Button btnAbort;
        private DateTimePicker dtpBirthDate;
        private Label label5;
    }
}