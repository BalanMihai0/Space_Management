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
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
            tbProfilePic.Enabled = false;
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void rbGuest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGuest.Checked) { tbProfilePic.Enabled = true; }
            else { tbProfilePic.Enabled = false; }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbAdmin.Checked)
                {
                    SpaceApp.Instance.UserManager.AddAdmin(tbFirstName.Text, tbLastName.Text, tbPassword.Text, tbEmail.Text, dtpBirthDate.Value);
                }
                else if (rbEmployee.Checked)
                {
                    SpaceApp.Instance.UserManager.AddEmployee(tbFirstName.Text, tbLastName.Text, tbPassword.Text, tbEmail.Text,dtpBirthDate.Value);
                }
                else if (rbGuest.Checked)
                {
                    SpaceApp.Instance.UserManager.AddGuest(tbFirstName.Text, tbLastName.Text, tbPassword.Text, tbEmail.Text, dtpBirthDate.Value, tbProfilePic.Text);
                }
                else { MessageBox.Show("Please select the user type"); }

                //nothing went wrong
                MessageBox.Show("User added succesfully");
                this.Hide();
                this.Close();
            }
            catch (FormatException ex) { MessageBox.Show("Invalid data"); }
            catch (ArgumentException ex) { MessageBox.Show("Invalid data"); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            
        }
    }
}
