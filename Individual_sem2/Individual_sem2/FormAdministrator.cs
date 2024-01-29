using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using SharedLibrary;
using SpaceLibrary;
using UserLibrary;

namespace Individual_sem2
{
    public partial class FormAdministrator : Form
    {
        private Administrator adminLoggedIn;
        public FormAdministrator(Administrator adminLoggedIn)
        {
            InitializeComponent();
            this.adminLoggedIn = adminLoggedIn;
            this.WindowState = FormWindowState.Maximized; //setting to fullscreen
            InitializeList();
            InitializeRadioButtons();
            InitializeUsersLabels();
            InitializeSpaceLabels();
            SetUserLables();
        }

        #region design labels

        public void InitializeRadioButtons()
        {
            rbBlueprintView.Checked = false;
            rbMapView.Checked = true;
            rbModelView.Checked = false;

            rbModelView.Enabled = true;
            rbMapView.Enabled = true;
            rbBlueprintView.Enabled = true;
        }

        public void InitializeSpaceLabels()
        {
            lblObjSize.Text = "Size: ";
            lblObjMass.Text = "Mass: ";
            lblObjPosition.Text = "Position: ";
            lblObjVelocity.Text = "Velocity: ";
            lblObjOrientation.Text = "Orientation: ";
            lblObjSemiMajorAxis.Text = "Semi-Major Axis: ";
            lblObjInclination.Text = "Inclination: ";
            lblObjLongitudeOfAscNode.Text = "Longitude of Ascending Node: ";
            lblObjTrueAnomaly.Text = "True Anomaly: ";
            lblObjOrbitType.Text = "Orbit Type: ";
            lblObjTemperature.Text = "Temperature: ";
            lblObjBatteryLevel.Text = "Battery Level: ";
            lblObjHullIntegrity.Text = "Hull Integrity: ";
            lblObjBoardComputerHealth.Text = "Board Computer Health: ";
            lblObjObjective.Text = "Objective: ";
            lblObjManufacturer.Text = "Manufacturer: ";
            lblObjModel.Text = "Model: ";
            lblObjLaunchDate.Text = "Launch Date: ";
            lblObjLaunchPosition.Text = "Launch Position: ";
            lblObjLandingDate.Text = "Landing Date: ";
            lblObjResearchType.Text = "Research Type: ";
        }


        public void InitializeUsersLabels()
        {
            lblTotalEmployees.Text = "Employees Registered: ";
            lblTotalUsers.Text = "Total Users Registered: ";
            lblTotalGuests.Text = "Guests Registered: ";
        }

        public void SetLabels(SpaceObject sp)
        {
            //base fields
            lblObjSize.Text += sp.Size.ToString();
            lblObjMass.Text += sp.Mass.ToString();
            lblObjPosition.Text += (sp.Position.X.ToString() + ", " + sp.Position.Y.ToString() + ", " + sp.Position.Z.ToString());
            lblObjVelocity.Text += (sp.Velocity.X.ToString() + ", " + sp.Velocity.Y.ToString() + ", " + sp.Velocity.Z.ToString());
            lblObjPosition.Text += (sp.Position.X.ToString() + ", " + sp.Position.Y.ToString() + ", " + sp.Position.Z.ToString());
            lblObjOrientation.Text += (sp.Orientation.X.ToString() + ", " + sp.Orientation.Y.ToString() + ", " + sp.Orientation.Z.ToString());
            lblObjSemiMajorAxis.Text += sp.OrbitalData.SemiMajorAxis.ToString();
            lblObjInclination.Text += sp.OrbitalData.Inclination.ToString();
            lblObjLongitudeOfAscNode.Text += sp.OrbitalData.LongitudeOfAscendingNode.ToString();
            lblObjTrueAnomaly.Text += sp.OrbitalData.TrueAnomaly.ToString();
            lblObjOrbitType.Text += sp.OrbitalData.OrbitType.ToString();
            //specific fields
            if (sp is Satellite sa)
            {
                lblObjTemperature.Text += sa.TelemetryData.Temperature.ToString() + " Kelvin";
                lblObjBatteryLevel.Text += sa.TelemetryData.BatteryLevel.ToString() + "%";
                lblObjHullIntegrity.Text += sa.TelemetryData.HullIntegrity.ToString() + "%";
                lblObjBoardComputerHealth.Text += sa.TelemetryData.BoardComputerHealth.ToString() + "%";

                lblObjObjective.Text += sa.Objective.ToString();
                lblObjManufacturer.Text += sa.Manufacturer.ToString();
                lblObjModel.Text += sa.Model.ToString();

                lblObjLaunchDate.Text += sa.LaunchData.LaunchDate.ToString();
                lblObjLaunchPosition.Text += sa.LaunchData.LaunchLocation.ToString();
                if (sa.LaunchData.LandingDate.HasValue) { lblObjLandingDate.Text += sa.LaunchData.LandingDate.ToString(); }
                else { lblObjLandingDate.Text += "Has not landed"; }
            }
            if (sp is Station st)
            {
                lblObjTemperature.Text += st.TelemetryData.Temperature.ToString() + " Kelvin";
                lblObjBatteryLevel.Text += st.TelemetryData.BatteryLevel.ToString() + "%";
                lblObjHullIntegrity.Text += st.TelemetryData.HullIntegrity.ToString() + "%";
                lblObjBoardComputerHealth.Text += st.TelemetryData.BoardComputerHealth.ToString() + "%";

                lblObjModel.Text += st.Model.ToString();
                lblObjResearchType.Text += st.ResearchType.ToString();
            }
        }

        public void SetUserLables()
        {
            lblTotalUsers.Text += SpaceApp.Instance.UserManager.GetAllUsers().Count().ToString();
            lblTotalEmployees.Text += SpaceApp.Instance.UserManager.GetEmployees().Count().ToString();
            lblTotalGuests.Text += SpaceApp.Instance.UserManager.GetGuests().Count().ToString();
        }

        public void InitializeList()
        {
            foreach (SpaceObject s in SpaceApp.Instance.SpaceManager.GetAllObjects())
            {
                lbSpaceObjects.Items.Add(s);
            }
        }

        #endregion


        private void rbModelView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbModelView.Checked)
                {
                    // change picture to model view, depending on selected block
                    SpaceObject temp = (SpaceObject)lbSpaceObjects.SelectedItem;
                    if (temp is Satellite satellite)
                        pictureBox1.Image = (Image)Properties.Resources.Satellite_model;
                    else if (temp is Station st)
                        pictureBox1.Image = (Image)Properties.Resources.Station_model;
                    else pictureBox1.Image = (Image)Properties.Resources.Debris_model;
                }
            }
            catch (NullReferenceException) { return; }

        }
        private void rbBlueprintView_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (rbBlueprintView.Checked)
                {
                    // change picture to blueprint view, depending on selected block
                    SpaceObject temp = (SpaceObject)lbSpaceObjects.SelectedItem;
                    if (temp is Satellite satellite)
                        pictureBox1.Image = (Image)Properties.Resources.Satellite_blueprint;
                    else if (temp is Station st)
                        pictureBox1.Image = (Image)Properties.Resources.Station_blueprint;
                    else pictureBox1.Image = (Image)Properties.Resources.not_available;
                }
            }
            catch (NullReferenceException) { return; }

        }
        private void rbMapView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbMapView.Checked)
                {
                    // change picture to map view
                    pictureBox1.Image = Properties.Resources.not_available;
                }
            }
            catch (NullReferenceException) { return; }

        }


        private void lbSpaceObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeSpaceLabels();
            SetLabels((SpaceObject)lbSpaceObjects.SelectedItem);
            rbModelView.Checked = true;
            rbModelView_CheckedChanged(null, null); //force event to update picture
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin f = new FormLogin();
            f.ShowDialog();
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new FormAddUser();
            formAddUser.ShowDialog();
        }

        private void tbSearchObject_TextChanged(object sender, EventArgs e)
        {
            lbSpaceObjects.DataSource = SpaceApp.Instance.SpaceManager.SearchSpaceObjects(tbSearchObject.Text);
        }

        private void btnEditUsers_Click(object sender, EventArgs e)
        {
            FormEditUsers f = new FormEditUsers(adminLoggedIn);
            f.ShowDialog();
        }
    }
}
