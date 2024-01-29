namespace Individual_sem2
{
    partial class FormAdministrator
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
            groupBox1 = new GroupBox();
            lblObjResearchType = new Label();
            tbSearchObject = new TextBox();
            label2 = new Label();
            lblObjObjective = new Label();
            lblObjManufacturer = new Label();
            lblObjVelocity = new Label();
            lblObjOrientation = new Label();
            lblObjPosition = new Label();
            lblObjModel = new Label();
            lblObjMass = new Label();
            label3 = new Label();
            lblObjSize = new Label();
            label1 = new Label();
            lbSpaceObjects = new ListBox();
            groupBox2 = new GroupBox();
            lblObjLandingDate = new Label();
            lblObjLaunchPosition = new Label();
            lblObjLaunchDate = new Label();
            groupBox3 = new GroupBox();
            lblObjOrbitType = new Label();
            lblObjTrueAnomaly = new Label();
            lblObjLongitudeOfAscNode = new Label();
            lblObjInclination = new Label();
            lblObjSemiMajorAxis = new Label();
            groupBox4 = new GroupBox();
            lblObjBoardComputerHealth = new Label();
            lblObjHullIntegrity = new Label();
            lblObjBatteryLevel = new Label();
            lblObjTemperature = new Label();
            pictureBox1 = new PictureBox();
            groupBox5 = new GroupBox();
            rbMapView = new RadioButton();
            rbBlueprintView = new RadioButton();
            rbModelView = new RadioButton();
            groupBox6 = new GroupBox();
            lblTotalGuests = new Label();
            lblTotalEmployees = new Label();
            lblTotalUsers = new Label();
            btnAddNewUser = new Button();
            btnEditUsers = new Button();
            btnLogOut = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox1.Controls.Add(lblObjResearchType);
            groupBox1.Controls.Add(tbSearchObject);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblObjObjective);
            groupBox1.Controls.Add(lblObjManufacturer);
            groupBox1.Controls.Add(lblObjVelocity);
            groupBox1.Controls.Add(lblObjOrientation);
            groupBox1.Controls.Add(lblObjPosition);
            groupBox1.Controls.Add(lblObjModel);
            groupBox1.Controls.Add(lblObjMass);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblObjSize);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lbSpaceObjects);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(25, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(462, 697);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Title";
            // 
            // lblObjResearchType
            // 
            lblObjResearchType.AutoSize = true;
            lblObjResearchType.BackColor = Color.Transparent;
            lblObjResearchType.Location = new Point(18, 617);
            lblObjResearchType.Name = "lblObjResearchType";
            lblObjResearchType.Size = new Size(122, 21);
            lblObjResearchType.TabIndex = 14;
            lblObjResearchType.Text = "Research Type:";
            // 
            // tbSearchObject
            // 
            tbSearchObject.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tbSearchObject.Location = new Point(88, 52);
            tbSearchObject.Margin = new Padding(3, 2, 3, 2);
            tbSearchObject.Name = "tbSearchObject";
            tbSearchObject.Size = new Size(361, 26);
            tbSearchObject.TabIndex = 13;
            tbSearchObject.TextChanged += tbSearchObject_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(18, 58);
            label2.Name = "label2";
            label2.Size = new Size(62, 19);
            label2.TabIndex = 12;
            label2.Text = "Search: ";
            // 
            // lblObjObjective
            // 
            lblObjObjective.AutoSize = true;
            lblObjObjective.BackColor = Color.Transparent;
            lblObjObjective.Location = new Point(18, 578);
            lblObjObjective.Name = "lblObjObjective";
            lblObjObjective.Size = new Size(91, 21);
            lblObjObjective.TabIndex = 10;
            lblObjObjective.Text = "Objective: ";
            // 
            // lblObjManufacturer
            // 
            lblObjManufacturer.AutoSize = true;
            lblObjManufacturer.BackColor = Color.Transparent;
            lblObjManufacturer.Location = new Point(18, 544);
            lblObjManufacturer.Name = "lblObjManufacturer";
            lblObjManufacturer.Size = new Size(123, 21);
            lblObjManufacturer.TabIndex = 9;
            lblObjManufacturer.Text = "Manufacturer: ";
            // 
            // lblObjVelocity
            // 
            lblObjVelocity.AutoSize = true;
            lblObjVelocity.BackColor = Color.Transparent;
            lblObjVelocity.Location = new Point(18, 443);
            lblObjVelocity.Name = "lblObjVelocity";
            lblObjVelocity.Size = new Size(80, 21);
            lblObjVelocity.TabIndex = 8;
            lblObjVelocity.Text = "Velocity: ";
            // 
            // lblObjOrientation
            // 
            lblObjOrientation.AutoSize = true;
            lblObjOrientation.BackColor = Color.Transparent;
            lblObjOrientation.Location = new Point(18, 479);
            lblObjOrientation.Name = "lblObjOrientation";
            lblObjOrientation.Size = new Size(106, 21);
            lblObjOrientation.TabIndex = 7;
            lblObjOrientation.Text = "Orientation: ";
            // 
            // lblObjPosition
            // 
            lblObjPosition.AutoSize = true;
            lblObjPosition.BackColor = Color.Transparent;
            lblObjPosition.Location = new Point(18, 411);
            lblObjPosition.Name = "lblObjPosition";
            lblObjPosition.Size = new Size(77, 21);
            lblObjPosition.TabIndex = 6;
            lblObjPosition.Text = "Position:";
            // 
            // lblObjModel
            // 
            lblObjModel.AutoSize = true;
            lblObjModel.BackColor = Color.Transparent;
            lblObjModel.Location = new Point(18, 512);
            lblObjModel.Name = "lblObjModel";
            lblObjModel.Size = new Size(67, 21);
            lblObjModel.TabIndex = 5;
            lblObjModel.Text = "Model: ";
            // 
            // lblObjMass
            // 
            lblObjMass.AutoSize = true;
            lblObjMass.BackColor = Color.Transparent;
            lblObjMass.Location = new Point(18, 377);
            lblObjMass.Name = "lblObjMass";
            lblObjMass.Size = new Size(56, 21);
            lblObjMass.TabIndex = 4;
            lblObjMass.Text = "Mass: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(183, 320);
            label3.Name = "label3";
            label3.Size = new Size(251, 19);
            label3.TabIndex = 3;
            label3.Text = "*Select an object to display the info!";
            // 
            // lblObjSize
            // 
            lblObjSize.AutoSize = true;
            lblObjSize.BackColor = Color.Transparent;
            lblObjSize.Location = new Point(18, 347);
            lblObjSize.Name = "lblObjSize";
            lblObjSize.Size = new Size(49, 21);
            lblObjSize.TabIndex = 2;
            lblObjSize.Text = "Size: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(18, 99);
            label1.Name = "label1";
            label1.Size = new Size(136, 19);
            label1.TabIndex = 1;
            label1.Text = "All objects in orbit:";
            // 
            // lbSpaceObjects
            // 
            lbSpaceObjects.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lbSpaceObjects.FormattingEnabled = true;
            lbSpaceObjects.ItemHeight = 19;
            lbSpaceObjects.Location = new Point(18, 119);
            lbSpaceObjects.Margin = new Padding(3, 2, 3, 2);
            lbSpaceObjects.Name = "lbSpaceObjects";
            lbSpaceObjects.Size = new Size(430, 194);
            lbSpaceObjects.TabIndex = 0;
            lbSpaceObjects.SelectedIndexChanged += lbSpaceObjects_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox2.Controls.Add(lblObjLandingDate);
            groupBox2.Controls.Add(lblObjLaunchPosition);
            groupBox2.Controls.Add(lblObjLaunchDate);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(533, 11);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(500, 196);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Launch Data:";
            // 
            // lblObjLandingDate
            // 
            lblObjLandingDate.AutoSize = true;
            lblObjLandingDate.BackColor = Color.Transparent;
            lblObjLandingDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjLandingDate.Location = new Point(17, 118);
            lblObjLandingDate.Name = "lblObjLandingDate";
            lblObjLandingDate.Size = new Size(110, 20);
            lblObjLandingDate.TabIndex = 5;
            lblObjLandingDate.Text = "Landing Date: ";
            // 
            // lblObjLaunchPosition
            // 
            lblObjLaunchPosition.AutoSize = true;
            lblObjLaunchPosition.BackColor = Color.Transparent;
            lblObjLaunchPosition.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjLaunchPosition.Location = new Point(17, 74);
            lblObjLaunchPosition.Name = "lblObjLaunchPosition";
            lblObjLaunchPosition.Size = new Size(128, 20);
            lblObjLaunchPosition.TabIndex = 4;
            lblObjLaunchPosition.Text = "Launch Position: ";
            // 
            // lblObjLaunchDate
            // 
            lblObjLaunchDate.AutoSize = true;
            lblObjLaunchDate.BackColor = Color.Transparent;
            lblObjLaunchDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjLaunchDate.Location = new Point(17, 30);
            lblObjLaunchDate.Name = "lblObjLaunchDate";
            lblObjLaunchDate.Size = new Size(104, 20);
            lblObjLaunchDate.TabIndex = 3;
            lblObjLaunchDate.Text = "Launch Date: ";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox3.Controls.Add(lblObjOrbitType);
            groupBox3.Controls.Add(lblObjTrueAnomaly);
            groupBox3.Controls.Add(lblObjLongitudeOfAscNode);
            groupBox3.Controls.Add(lblObjInclination);
            groupBox3.Controls.Add(lblObjSemiMajorAxis);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox3.ForeColor = SystemColors.ButtonHighlight;
            groupBox3.Location = new Point(1089, 11);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(462, 196);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Orbital Data: ";
            // 
            // lblObjOrbitType
            // 
            lblObjOrbitType.AutoSize = true;
            lblObjOrbitType.BackColor = Color.Transparent;
            lblObjOrbitType.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjOrbitType.Location = new Point(5, 150);
            lblObjOrbitType.Name = "lblObjOrbitType";
            lblObjOrbitType.Size = new Size(90, 20);
            lblObjOrbitType.TabIndex = 8;
            lblObjOrbitType.Text = "Orbit Type: ";
            // 
            // lblObjTrueAnomaly
            // 
            lblObjTrueAnomaly.AutoSize = true;
            lblObjTrueAnomaly.BackColor = Color.Transparent;
            lblObjTrueAnomaly.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjTrueAnomaly.Location = new Point(5, 118);
            lblObjTrueAnomaly.Name = "lblObjTrueAnomaly";
            lblObjTrueAnomaly.Size = new Size(115, 20);
            lblObjTrueAnomaly.TabIndex = 7;
            lblObjTrueAnomaly.Text = "True Anomaly: ";
            // 
            // lblObjLongitudeOfAscNode
            // 
            lblObjLongitudeOfAscNode.AutoSize = true;
            lblObjLongitudeOfAscNode.BackColor = Color.Transparent;
            lblObjLongitudeOfAscNode.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjLongitudeOfAscNode.Location = new Point(5, 88);
            lblObjLongitudeOfAscNode.Name = "lblObjLongitudeOfAscNode";
            lblObjLongitudeOfAscNode.Size = new Size(223, 20);
            lblObjLongitudeOfAscNode.TabIndex = 6;
            lblObjLongitudeOfAscNode.Text = "Longitude of ascending Node: ";
            // 
            // lblObjInclination
            // 
            lblObjInclination.AutoSize = true;
            lblObjInclination.BackColor = Color.Transparent;
            lblObjInclination.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjInclination.Location = new Point(5, 56);
            lblObjInclination.Name = "lblObjInclination";
            lblObjInclination.Size = new Size(91, 20);
            lblObjInclination.TabIndex = 5;
            lblObjInclination.Text = "Inclination: ";
            // 
            // lblObjSemiMajorAxis
            // 
            lblObjSemiMajorAxis.AutoSize = true;
            lblObjSemiMajorAxis.BackColor = Color.Transparent;
            lblObjSemiMajorAxis.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjSemiMajorAxis.Location = new Point(5, 30);
            lblObjSemiMajorAxis.Name = "lblObjSemiMajorAxis";
            lblObjSemiMajorAxis.Size = new Size(134, 20);
            lblObjSemiMajorAxis.TabIndex = 4;
            lblObjSemiMajorAxis.Text = "Semi Major Axis:  ";
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox4.Controls.Add(lblObjBoardComputerHealth);
            groupBox4.Controls.Add(lblObjHullIntegrity);
            groupBox4.Controls.Add(lblObjBatteryLevel);
            groupBox4.Controls.Add(lblObjTemperature);
            groupBox4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox4.ForeColor = SystemColors.ButtonHighlight;
            groupBox4.Location = new Point(1089, 234);
            groupBox4.Margin = new Padding(3, 2, 3, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 2, 3, 2);
            groupBox4.Size = new Size(462, 158);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Telemetry Data: ";
            // 
            // lblObjBoardComputerHealth
            // 
            lblObjBoardComputerHealth.AutoSize = true;
            lblObjBoardComputerHealth.BackColor = Color.Transparent;
            lblObjBoardComputerHealth.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjBoardComputerHealth.Location = new Point(6, 122);
            lblObjBoardComputerHealth.Name = "lblObjBoardComputerHealth";
            lblObjBoardComputerHealth.Size = new Size(196, 20);
            lblObjBoardComputerHealth.TabIndex = 12;
            lblObjBoardComputerHealth.Text = "Board Computer Health: %";
            // 
            // lblObjHullIntegrity
            // 
            lblObjHullIntegrity.AutoSize = true;
            lblObjHullIntegrity.BackColor = Color.Transparent;
            lblObjHullIntegrity.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjHullIntegrity.Location = new Point(5, 94);
            lblObjHullIntegrity.Name = "lblObjHullIntegrity";
            lblObjHullIntegrity.Size = new Size(123, 20);
            lblObjHullIntegrity.TabIndex = 11;
            lblObjHullIntegrity.Text = "Hull Integrity: %";
            // 
            // lblObjBatteryLevel
            // 
            lblObjBatteryLevel.AutoSize = true;
            lblObjBatteryLevel.BackColor = Color.Transparent;
            lblObjBatteryLevel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjBatteryLevel.Location = new Point(5, 68);
            lblObjBatteryLevel.Name = "lblObjBatteryLevel";
            lblObjBatteryLevel.Size = new Size(123, 20);
            lblObjBatteryLevel.TabIndex = 10;
            lblObjBatteryLevel.Text = "Battery Level: %";
            // 
            // lblObjTemperature
            // 
            lblObjTemperature.AutoSize = true;
            lblObjTemperature.BackColor = Color.Transparent;
            lblObjTemperature.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblObjTemperature.Location = new Point(5, 43);
            lblObjTemperature.Name = "lblObjTemperature";
            lblObjTemperature.Size = new Size(154, 20);
            lblObjTemperature.TabIndex = 9;
            lblObjTemperature.Text = "Temperature:  Kelvin";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.AppWorkspace;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.not_available;
            pictureBox1.Location = new Point(533, 234);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 380);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox5.Controls.Add(rbMapView);
            groupBox5.Controls.Add(rbBlueprintView);
            groupBox5.Controls.Add(rbModelView);
            groupBox5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox5.ForeColor = SystemColors.ButtonHighlight;
            groupBox5.Location = new Point(533, 652);
            groupBox5.Margin = new Padding(3, 2, 3, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 2, 3, 2);
            groupBox5.Size = new Size(500, 54);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "Change view:";
            // 
            // rbMapView
            // 
            rbMapView.AutoSize = true;
            rbMapView.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbMapView.Location = new Point(299, 25);
            rbMapView.Margin = new Padding(3, 2, 3, 2);
            rbMapView.Name = "rbMapView";
            rbMapView.Size = new Size(92, 23);
            rbMapView.TabIndex = 2;
            rbMapView.TabStop = true;
            rbMapView.Text = "Map view";
            rbMapView.UseVisualStyleBackColor = true;
            rbMapView.CheckedChanged += rbMapView_CheckedChanged;
            // 
            // rbBlueprintView
            // 
            rbBlueprintView.AutoSize = true;
            rbBlueprintView.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbBlueprintView.Location = new Point(147, 25);
            rbBlueprintView.Margin = new Padding(3, 2, 3, 2);
            rbBlueprintView.Name = "rbBlueprintView";
            rbBlueprintView.Size = new Size(123, 23);
            rbBlueprintView.TabIndex = 1;
            rbBlueprintView.TabStop = true;
            rbBlueprintView.Text = "Blueprint view";
            rbBlueprintView.UseVisualStyleBackColor = true;
            rbBlueprintView.CheckedChanged += rbBlueprintView_CheckedChanged_1;
            // 
            // rbModelView
            // 
            rbModelView.AutoSize = true;
            rbModelView.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            rbModelView.Location = new Point(17, 25);
            rbModelView.Margin = new Padding(3, 2, 3, 2);
            rbModelView.Name = "rbModelView";
            rbModelView.Size = new Size(105, 23);
            rbModelView.TabIndex = 0;
            rbModelView.TabStop = true;
            rbModelView.Text = "Model view";
            rbModelView.UseVisualStyleBackColor = true;
            rbModelView.CheckedChanged += rbModelView_CheckedChanged;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.FromArgb(170, 0, 0, 0);
            groupBox6.Controls.Add(lblTotalGuests);
            groupBox6.Controls.Add(lblTotalEmployees);
            groupBox6.Controls.Add(lblTotalUsers);
            groupBox6.Controls.Add(btnAddNewUser);
            groupBox6.Controls.Add(btnEditUsers);
            groupBox6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox6.ForeColor = SystemColors.ButtonHighlight;
            groupBox6.Location = new Point(1089, 420);
            groupBox6.Margin = new Padding(3, 2, 3, 2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 2, 3, 2);
            groupBox6.Size = new Size(462, 286);
            groupBox6.TabIndex = 8;
            groupBox6.TabStop = false;
            groupBox6.Text = "Users";
            // 
            // lblTotalGuests
            // 
            lblTotalGuests.AutoSize = true;
            lblTotalGuests.BackColor = Color.Transparent;
            lblTotalGuests.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalGuests.Location = new Point(237, 103);
            lblTotalGuests.Name = "lblTotalGuests";
            lblTotalGuests.Size = new Size(144, 20);
            lblTotalGuests.TabIndex = 16;
            lblTotalGuests.Text = "Guests Registered: ";
            // 
            // lblTotalEmployees
            // 
            lblTotalEmployees.AutoSize = true;
            lblTotalEmployees.BackColor = Color.Transparent;
            lblTotalEmployees.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalEmployees.Location = new Point(18, 103);
            lblTotalEmployees.Name = "lblTotalEmployees";
            lblTotalEmployees.Size = new Size(171, 20);
            lblTotalEmployees.TabIndex = 15;
            lblTotalEmployees.Text = "Employees Registered: ";
            // 
            // lblTotalUsers
            // 
            lblTotalUsers.AutoSize = true;
            lblTotalUsers.BackColor = Color.Transparent;
            lblTotalUsers.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalUsers.Location = new Point(18, 56);
            lblTotalUsers.Name = "lblTotalUsers";
            lblTotalUsers.Size = new Size(174, 20);
            lblTotalUsers.TabIndex = 14;
            lblTotalUsers.Text = "Total Users Registered: ";
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.BackColor = SystemColors.ActiveCaptionText;
            btnAddNewUser.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddNewUser.ForeColor = SystemColors.ButtonFace;
            btnAddNewUser.Location = new Point(237, 224);
            btnAddNewUser.Margin = new Padding(3, 2, 3, 2);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.Size = new Size(213, 53);
            btnAddNewUser.TabIndex = 13;
            btnAddNewUser.Text = "Add User";
            btnAddNewUser.UseVisualStyleBackColor = false;
            btnAddNewUser.Click += btnAddNewUser_Click;
            // 
            // btnEditUsers
            // 
            btnEditUsers.BackColor = SystemColors.ActiveCaptionText;
            btnEditUsers.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditUsers.ForeColor = SystemColors.ButtonFace;
            btnEditUsers.Location = new Point(18, 224);
            btnEditUsers.Margin = new Padding(3, 2, 3, 2);
            btnEditUsers.Name = "btnEditUsers";
            btnEditUsers.Size = new Size(213, 53);
            btnEditUsers.TabIndex = 12;
            btnEditUsers.Text = "Edit Users";
            btnEditUsers.UseVisualStyleBackColor = false;
            btnEditUsers.Click += btnEditUsers_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = SystemColors.ActiveCaptionText;
            btnLogOut.Font = new Font("Verdana", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogOut.ForeColor = SystemColors.ButtonFace;
            btnLogOut.Location = new Point(653, 713);
            btnLogOut.Margin = new Padding(3, 2, 3, 2);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(213, 53);
            btnLogOut.TabIndex = 13;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // FormAdministrator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Earth_Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1567, 777);
            Controls.Add(btnLogOut);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormAdministrator";
            Text = "FormAdministrator";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private PictureBox pictureBox1;
        private Label label1;
        private ListBox lbSpaceObjects;
        private Label lblObjVelocity;
        private Label lblObjOrientation;
        private Label lblObjPosition;
        private Label lblObjModel;
        private Label lblObjMass;
        private Label label3;
        private Label lblObjSize;
        private Label lblObjObjective;
        private Label lblObjManufacturer;
        private Label lblObjLaunchPosition;
        private Label lblObjLaunchDate;
        private Label lblObjLandingDate;
        private Label lblObjSemiMajorAxis;
        private Label lblObjInclination;
        private Label lblObjLongitudeOfAscNode;
        private Label lblObjOrbitType;
        private Label lblObjTrueAnomaly;
        private Label lblObjBoardComputerHealth;
        private Label lblObjHullIntegrity;
        private Label lblObjBatteryLevel;
        private Label lblObjTemperature;
        private GroupBox groupBox5;
        private RadioButton rbMapView;
        private RadioButton rbBlueprintView;
        private RadioButton rbModelView;
        private TextBox tbSearchObject;
        private Label label2;
        private GroupBox groupBox6;
        private Button btnAddNewUser;
        private Button btnEditUsers;
        private Label lblTotalUsers;
        private Label lblTotalGuests;
        private Label lblTotalEmployees;
        private Label lblObjResearchType;
        private Button btnLogOut;
    }
}