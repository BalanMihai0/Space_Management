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
    public partial class Communications : Form
    {
        public Communications()
        {
            InitializeComponent();
            //populate listboxes
            InitializeElements();

        }
        private void InitializeElements()
        {
            cbbDestination.Items.Clear();
            cbbDestination.DataSource = SpaceApp.Instance.SpaceManager.GetAllCommunications();
            cbbStart.Items.Clear();
            cbbStart.DataSource = SpaceApp.Instance.SpaceManager.GetAllCommunications();
            lbCalculatedResult.Items.Clear();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                lbCalculatedResult.Items.Clear();
                lbCalculatedResult.DataSource = SpaceApp.Instance.SpaceManager.GetCommunicationPath((Satellite)cbbStart.SelectedItem, (Satellite)cbbDestination.SelectedItem);
            }
            catch (NullReferenceException) { MessageBox.Show("Please select valid satellites!"); }
            catch (Exception) { MessageBox.Show("No trajectory found! Are all positions up to date?"); }
        }
    }
}
