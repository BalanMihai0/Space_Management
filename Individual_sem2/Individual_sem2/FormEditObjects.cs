using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Individual_sem2
{
    public partial class FormEditObjects : Form
    {
        public FormEditObjects()
        {
            InitializeComponent();
            cbbObjects.Items.Clear();
            cbbObjects.DataSource = SpaceApp.Instance.SpaceManager.GetAllObjects();
            cbbObjects.SelectedIndex = -1;
            cbbOrbitType.DataSource = SpaceApp.Instance.SpaceManager.GetOrbitTypes();
            cbbOrbitType.SelectedIndex = -1;
            cbbResearchTypes.DataSource = SpaceApp.Instance.SpaceManager.GetResearchTypes();
            cbbResearchTypes.SelectedIndex = -1;
        }

        public void LoadObject(SpaceObject sp)
        {
            try
            {
                //general fields
                tbName.Text = sp.Name;
                tbSize.Text = sp.Size.ToString();
                tbMass.Text = sp.Mass.ToString();
                tbPositionX.Text = sp.Position.X.ToString();
                tbPositionY.Text = sp.Position.Y.ToString();
                tbPositionZ.Text = sp.Position.Z.ToString();

                tbVelocityX.Text = sp.Velocity.X.ToString();
                tbVelocityY.Text = sp.Velocity.Y.ToString();
                tbVelocityZ.Text = sp.Velocity.Z.ToString();

                tbOrientationX.Text = sp.Orientation.X.ToString();
                tbOrientationY.Text = sp.Orientation.Y.ToString();
                tbOrientationZ.Text = sp.Orientation.Z.ToString();

                cbbOrbitType.SelectedItem = sp.OrbitalData.OrbitType;


                //cbbResearchTypes.SelectedItem = cbbResearchTypes.Items.Cast<OrbitType>().First(x => ((ResearchType)x.Value) == ResearchType.(sp.ResearchType));

                //subtype fields
                if (sp is Satellite st)
                {

                    tbModel.Text = st.Model;
                    tbObjective.Text = st.Objective;
                    tbManufacturer.Text = st.Manufacturer;
                    tbLaunchPositionX.Text = st.LaunchData.LaunchLocation.X.ToString();
                    tbLaunchPositionY.Text = st.LaunchData.LaunchLocation.Y.ToString();
                    tbLaunchPositionZ.Text = st.LaunchData.LaunchLocation.Z.ToString();
                    dtpLaunchDate.Value = st.LaunchData.LaunchDate;
                    dtpLandingDate.CustomFormat = "   ";

                    if (st.LaunchData.LandingDate is null)
                    {
                        dtpLandingDate.Format = DateTimePickerFormat.Custom; //will be empty
                    }
                    else dtpLandingDate.Value = (DateTime)st.LaunchData.LandingDate;
                }
                else if (sp is Station station)
                {
                    tbModel.Text = station.Model;

                    cbbResearchTypes.SelectedItem = station.ResearchType;
                }
                else if (sp is Debris d)
                {
                    tbDangerRadius.Text = d.DangerRadius.ToString();
                }

                //changing the image
                if (sp is Satellite satellite)
                    pictureBox1.Image = (Image)Properties.Resources.Satellite_model;
                else if (sp is Station station)
                    pictureBox1.Image = (Image)Properties.Resources.Station_model;
                else pictureBox1.Image = (Image)Properties.Resources.Debris_model;
            }
            catch (NullReferenceException) { } //first load will have no object
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }


        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                SpaceObject temp = (SpaceObject)cbbObjects.SelectedItem;
                if (temp != null)
                {
                    if (temp is Satellite satellite)
                    {
                        if (string.IsNullOrEmpty(tbModel.Text) || string.IsNullOrEmpty(tbObjective.Text) ||
                            string.IsNullOrEmpty(tbLaunchPositionX.Text) || string.IsNullOrEmpty(tbLaunchPositionY.Text) || string.IsNullOrEmpty(tbLaunchPositionZ.Text) ||
                            string.IsNullOrEmpty(tbManufacturer.Text) || string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbSize.Text) ||
                            string.IsNullOrEmpty(tbMass.Text) || string.IsNullOrEmpty(tbPositionX.Text) || string.IsNullOrEmpty(tbPositionY.Text) ||
                            string.IsNullOrEmpty(tbPositionZ.Text) || string.IsNullOrEmpty(tbVelocityX.Text) || string.IsNullOrEmpty(tbVelocityY.Text) ||
                            string.IsNullOrEmpty(tbVelocityZ.Text) || string.IsNullOrEmpty(tbOrientationX.Text) || string.IsNullOrEmpty(tbOrientationY.Text) ||
                            string.IsNullOrEmpty(tbOrientationZ.Text) || cbbOrbitType.SelectedItem == null) throw new ArgumentException();

                        SpaceApp.Instance.SpaceManager.EditObject(((SpaceObject)cbbObjects.SelectedItem).Name, new Satellite(tbModel.Text, tbObjective.Text, new Launch(new System.Numerics.Vector3(float.Parse(tbLaunchPositionX.Text), float.Parse(tbLaunchPositionY.Text), float.Parse(tbLaunchPositionZ.Text))), tbManufacturer.Text
                        , tbName.Text, double.Parse(tbSize.Text), double.Parse(tbMass.Text),
                        new System.Numerics.Vector3(float.Parse(tbPositionX.Text), float.Parse(tbPositionY.Text), float.Parse(tbPositionZ.Text)),
                        new System.Numerics.Vector3(float.Parse(tbVelocityX.Text), float.Parse(tbVelocityY.Text), float.Parse(tbVelocityZ.Text)),
                        new System.Numerics.Vector3(float.Parse(tbOrientationX.Text), float.Parse(tbOrientationY.Text), float.Parse(tbOrientationZ.Text)),
                        (OrbitType)cbbOrbitType.SelectedItem
                        ));
                        MessageBox.Show("Changes made succesfully");
                        this.Hide();
                        this.Close();
                    }
                    else if (temp is Station station)
                    {
                        if (string.IsNullOrEmpty(tbModel.Text) || cbbResearchTypes.SelectedItem == null || string.IsNullOrEmpty(tbName.Text) ||
                            string.IsNullOrEmpty(tbSize.Text) || string.IsNullOrEmpty(tbMass.Text) || string.IsNullOrEmpty(tbPositionX.Text) ||
                            string.IsNullOrEmpty(tbPositionY.Text) || string.IsNullOrEmpty(tbPositionZ.Text) || string.IsNullOrEmpty(tbVelocityX.Text) ||
                            string.IsNullOrEmpty(tbVelocityY.Text) || string.IsNullOrEmpty(tbVelocityZ.Text) || string.IsNullOrEmpty(tbOrientationX.Text) ||
                            string.IsNullOrEmpty(tbOrientationY.Text) || string.IsNullOrEmpty(tbOrientationZ.Text) || cbbOrbitType.SelectedItem == null) throw new ArgumentException();

                        SpaceApp.Instance.SpaceManager.EditObject(((SpaceObject)cbbObjects.SelectedItem).Name, new Station(tbModel.Text, (ResearchType)cbbResearchTypes.SelectedItem,
                            tbName.Text, double.Parse(tbSize.Text), double.Parse(tbMass.Text),
                        new System.Numerics.Vector3(float.Parse(tbPositionX.Text), float.Parse(tbPositionY.Text), float.Parse(tbPositionZ.Text)),
                        new System.Numerics.Vector3(float.Parse(tbVelocityX.Text), float.Parse(tbVelocityY.Text), float.Parse(tbVelocityZ.Text)),
                        new System.Numerics.Vector3(float.Parse(tbOrientationX.Text), float.Parse(tbOrientationY.Text), float.Parse(tbOrientationZ.Text)),
                        (OrbitType)cbbOrbitType.SelectedItem
                        ));
                        MessageBox.Show("Changes made succesfully");
                        this.Hide();
                        this.Close();
                    }
                    else if (temp is Debris debris)
                    {
                        if (string.IsNullOrEmpty(tbDangerRadius.Text) || string.IsNullOrEmpty(tbName.Text) ||
                            string.IsNullOrEmpty(tbSize.Text) || string.IsNullOrEmpty(tbMass.Text) || string.IsNullOrEmpty(tbPositionX.Text) ||
                            string.IsNullOrEmpty(tbPositionY.Text) || string.IsNullOrEmpty(tbPositionZ.Text) || string.IsNullOrEmpty(tbVelocityX.Text) ||
                            string.IsNullOrEmpty(tbVelocityY.Text) || string.IsNullOrEmpty(tbVelocityZ.Text) || string.IsNullOrEmpty(tbOrientationX.Text) ||
                            string.IsNullOrEmpty(tbOrientationY.Text) || string.IsNullOrEmpty(tbOrientationZ.Text) || cbbOrbitType.SelectedItem == null) throw new ArgumentException();

                        SpaceApp.Instance.SpaceManager.EditObject(((SpaceObject)cbbObjects.SelectedItem).Name, new Debris(double.Parse(tbDangerRadius.Text), tbName.Text, double.Parse(tbSize.Text), double.Parse(tbMass.Text),
                        new System.Numerics.Vector3(float.Parse(tbPositionX.Text), float.Parse(tbPositionY.Text), float.Parse(tbPositionZ.Text)),
                        new System.Numerics.Vector3(float.Parse(tbVelocityX.Text), float.Parse(tbVelocityY.Text), float.Parse(tbVelocityZ.Text)),
                        new System.Numerics.Vector3(float.Parse(tbOrientationX.Text), float.Parse(tbOrientationY.Text), float.Parse(tbOrientationZ.Text)),
                        (OrbitType)cbbOrbitType.SelectedItem
                        ));
                        MessageBox.Show("Changes made succesfully");
                        this.Hide();
                        this.Close();
                    }
                }
            }
            catch (FormatException) { MessageBox.Show("Invalid data!"); }
            catch (ArgumentException) { MessageBox.Show("Invalid data!"); }
            catch (NullReferenceException) { MessageBox.Show("Please fill in all fields!"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void cbbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadObject((SpaceObject)cbbObjects.SelectedItem);
        }


        private void btnAbort_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbObjects.SelectedIndex < 0) throw new ArgumentException("No object selected");
                SpaceApp.Instance.SpaceManager.DeleteObject((SpaceObject)cbbObjects.SelectedItem);
                MessageBox.Show("Changes made succesfully");
                this.Hide();
                this.Close();
            }
            catch(ArgumentException ex) { MessageBox.Show(ex.Message); }
            catch (Exception) { MessageBox.Show("An error occurred. Please try again later."); }
        }
    }
}
