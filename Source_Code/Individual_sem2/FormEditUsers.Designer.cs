namespace Individual_sem2
{
    partial class FormEditUsers
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
            btnRemoveUser = new Button();
            label6 = new Label();
            cbbEditUser = new ComboBox();
            dtpBirthDate = new DateTimePicker();
            label5 = new Label();
            btnEditUser = new Button();
            btnAbort = new Button();
            tbProfilePic = new TextBox();
            tbEmail = new TextBox();
            tbPassword = new TextBox();
            tbLastName = new TextBox();
            tbFirstName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblb = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox2.Controls.Add(btnRemoveUser);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cbbEditUser);
            groupBox2.Controls.Add(dtpBirthDate);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(btnEditUser);
            groupBox2.Controls.Add(btnAbort);
            groupBox2.Controls.Add(tbProfilePic);
            groupBox2.Controls.Add(tbEmail);
            groupBox2.Controls.Add(tbPassword);
            groupBox2.Controls.Add(tbLastName);
            groupBox2.Controls.Add(tbFirstName);
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
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add a user:";
            // 
            // btnRemoveUser
            // 
            btnRemoveUser.BackColor = SystemColors.ActiveCaptionText;
            btnRemoveUser.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveUser.ForeColor = SystemColors.ButtonFace;
            btnRemoveUser.Location = new Point(348, 420);
            btnRemoveUser.Margin = new Padding(3, 2, 3, 2);
            btnRemoveUser.Name = "btnRemoveUser";
            btnRemoveUser.Size = new Size(146, 53);
            btnRemoveUser.TabIndex = 24;
            btnRemoveUser.Text = "Remove";
            btnRemoveUser.UseVisualStyleBackColor = false;
            btnRemoveUser.Click += btnRemoveUser_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(8, 53);
            label6.Name = "label6";
            label6.Size = new Size(144, 20);
            label6.TabIndex = 23;
            label6.Text = "Select User to Edit: ";
            // 
            // cbbEditUser
            // 
            cbbEditUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            cbbEditUser.FormattingEnabled = true;
            cbbEditUser.Location = new Point(166, 51);
            cbbEditUser.Name = "cbbEditUser";
            cbbEditUser.Size = new Size(213, 25);
            cbbEditUser.TabIndex = 22;
            cbbEditUser.SelectedIndexChanged += cbbEditUser_SelectedIndexChanged;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dtpBirthDate.Location = new Point(101, 315);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(259, 25);
            dtpBirthDate.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(6, 322);
            label5.Name = "label5";
            label5.Size = new Size(89, 20);
            label5.TabIndex = 20;
            label5.Text = "Birth Date: ";
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = SystemColors.ActiveCaptionText;
            btnEditUser.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditUser.ForeColor = SystemColors.ButtonFace;
            btnEditUser.Location = new Point(142, 420);
            btnEditUser.Margin = new Padding(3, 2, 3, 2);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(185, 53);
            btnEditUser.TabIndex = 19;
            btnEditUser.Text = "Save Changes";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnAbort
            // 
            btnAbort.BackColor = SystemColors.ActiveCaptionText;
            btnAbort.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnAbort.ForeColor = SystemColors.ButtonFace;
            btnAbort.Location = new Point(6, 420);
            btnAbort.Margin = new Padding(3, 2, 3, 2);
            btnAbort.Name = "btnAbort";
            btnAbort.Size = new Size(118, 53);
            btnAbort.TabIndex = 18;
            btnAbort.Text = "Abort";
            btnAbort.UseVisualStyleBackColor = false;
            btnAbort.Click += btnAbort_Click;
            // 
            // tbProfilePic
            // 
            tbProfilePic.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbProfilePic.Location = new Point(217, 273);
            tbProfilePic.Name = "tbProfilePic";
            tbProfilePic.Size = new Size(277, 25);
            tbProfilePic.TabIndex = 17;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbEmail.Location = new Point(102, 227);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(277, 25);
            tbEmail.TabIndex = 16;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbPassword.Location = new Point(102, 181);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(277, 25);
            tbPassword.TabIndex = 15;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbLastName.Location = new Point(102, 141);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(277, 25);
            tbLastName.TabIndex = 14;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            tbFirstName.Location = new Point(102, 98);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(277, 25);
            tbFirstName.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(6, 274);
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
            label3.Location = new Point(6, 228);
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
            label2.Location = new Point(6, 182);
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
            label1.Location = new Point(6, 140);
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
            lblb.Location = new Point(6, 99);
            lblb.Name = "lblb";
            lblb.Size = new Size(90, 20);
            lblb.TabIndex = 5;
            lblb.Text = "First Name:";
            // 
            // FormEditUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Earth_Background;
            ClientSize = new Size(520, 536);
            Controls.Add(groupBox2);
            Name = "FormEditUsers";
            Text = "FormEditUsers";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button btnRemoveUser;
        private Label label6;
        private ComboBox cbbEditUser;
        private DateTimePicker dtpBirthDate;
        private Label label5;
        private Button btnEditUser;
        private Button btnAbort;
        private TextBox tbProfilePic;
        private TextBox tbEmail;
        private TextBox tbPassword;
        private TextBox tbLastName;
        private TextBox tbFirstName;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblb;
    }
}