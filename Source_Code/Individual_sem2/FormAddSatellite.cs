using DataLibrary;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_sem2
{
    public partial class FormAddSatellite : Form
    {
        public FormAddSatellite()
        {
            InitializeComponent();
            cbbOrbitType.DataSource = SpaceApp.Instance.SpaceManager.GetOrbitTypes();
            cbbOrbitType.SelectedIndex = -1;
        }

        private void btnAddSatellite_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbModel.Text) || string.IsNullOrEmpty(tbObjective.Text) ||
                    string.IsNullOrEmpty(tbLaunchPositionX.Text) || string.IsNullOrEmpty(tbLaunchPositionY.Text) || string.IsNullOrEmpty(tbLaunchPositionZ.Text) ||
                    string.IsNullOrEmpty(tbManufacturer.Text) || string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbSize.Text) ||
                    string.IsNullOrEmpty(tbMass.Text) || string.IsNullOrEmpty(tbPositionX.Text) || string.IsNullOrEmpty(tbPositionY.Text) ||
                    string.IsNullOrEmpty(tbPositionZ.Text) || string.IsNullOrEmpty(tbVelocityX.Text) || string.IsNullOrEmpty(tbVelocityY.Text) ||
                    string.IsNullOrEmpty(tbVelocityZ.Text) || string.IsNullOrEmpty(tbOrientationX.Text) || string.IsNullOrEmpty(tbOrientationY.Text) ||
                    string.IsNullOrEmpty(tbOrientationZ.Text) || cbbOrbitType.SelectedItem == null) throw new ArgumentException();

                    SpaceApp.Instance.SpaceManager.AddObject(new Satellite( tbModel.Text, tbObjective.Text, new Launch(new System.Numerics.Vector3(float.Parse(tbLaunchPositionX.Text), float.Parse(tbLaunchPositionY.Text), float.Parse(tbLaunchPositionZ.Text))), tbManufacturer.Text
                , tbName.Text, double.Parse(tbSize.Text), double.Parse(tbMass.Text),
                new System.Numerics.Vector3(float.Parse(tbPositionX.Text), float.Parse(tbPositionY.Text), float.Parse(tbPositionZ.Text)),
                new System.Numerics.Vector3(float.Parse(tbVelocityX.Text), float.Parse(tbVelocityY.Text), float.Parse(tbVelocityZ.Text)),
                new System.Numerics.Vector3(float.Parse(tbOrientationX.Text), float.Parse(tbOrientationY.Text), float.Parse(tbOrientationZ.Text)),
                (OrbitType)cbbOrbitType.SelectedItem
                ));

                //all good
                MessageBox.Show("Satellite added succesfully");
                this.Hide();
                this.Close();
            }
            catch (FormatException) { MessageBox.Show("Invalid data"); }
            catch (ArgumentException) { MessageBox.Show("Invalid data"); }
            catch (Exception ex) { MessageBox.Show("Something went wrong: " + ex.Message); }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
