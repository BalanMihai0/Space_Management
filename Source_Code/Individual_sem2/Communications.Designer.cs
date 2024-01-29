namespace Individual_sem2
{
    partial class Communications
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
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            btnCalculate = new Button();
            lbCalculatedResult = new ListBox();
            cbbDestination = new ComboBox();
            cbbStart = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(cbbStart);
            groupBox2.Controls.Add(cbbDestination);
            groupBox2.Controls.Add(lbCalculatedResult);
            groupBox2.Controls.Add(btnCalculate);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(14, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(571, 415);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add:";
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = SystemColors.ActiveCaptionText;
            btnCalculate.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalculate.ForeColor = SystemColors.ButtonFace;
            btnCalculate.Location = new Point(163, 327);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(243, 71);
            btnCalculate.TabIndex = 43;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lbCalculatedResult
            // 
            lbCalculatedResult.FormattingEnabled = true;
            lbCalculatedResult.ItemHeight = 28;
            lbCalculatedResult.Location = new Point(163, 180);
            lbCalculatedResult.Name = "lbCalculatedResult";
            lbCalculatedResult.Size = new Size(243, 116);
            lbCalculatedResult.TabIndex = 44;
            // 
            // cbbDestination
            // 
            cbbDestination.FormattingEnabled = true;
            cbbDestination.Location = new Point(385, 89);
            cbbDestination.Name = "cbbDestination";
            cbbDestination.Size = new Size(151, 36);
            cbbDestination.TabIndex = 45;
            // 
            // cbbStart
            // 
            cbbStart.FormattingEnabled = true;
            cbbStart.Location = new Point(31, 89);
            cbbStart.Name = "cbbStart";
            cbbStart.Size = new Size(151, 36);
            cbbStart.TabIndex = 46;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(385, 48);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 47;
            label1.Text = "Destination:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 48);
            label2.Name = "label2";
            label2.Size = new Size(64, 28);
            label2.TabIndex = 48;
            label2.Text = "Start:";
            // 
            // Communications
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Earth_Background2;
            ClientSize = new Size(603, 462);
            Controls.Add(groupBox2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Communications";
            Text = "Communications";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;

        #endregion

        private Button btnCalculate;
        private ListBox lbCalculatedResult;
        private ComboBox cbbStart;
        private ComboBox cbbDestination;
        private Label label2;
        private Label label1;
    }
}