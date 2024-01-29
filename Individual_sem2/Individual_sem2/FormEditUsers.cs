using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedLibrary;
using UserLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Individual_sem2
{
    public partial class FormEditUsers : Form
    {
        private User selectedUser;
        private User loggedIn;
        public FormEditUsers(User loggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;
            cbbEditUser.DataSource = SpaceApp.Instance.UserManager.GetAllUsers();
            cbbEditUser.SelectedIndex = -1;
            tbPassword.UseSystemPasswordChar = true;

        }

        void LoadUser(User user)
        {
            if(user is not null)
            {
                tbFirstName.Text = user.FirstName;
                tbLastName.Text = user.LastName;
                tbEmail.Text = user.Email;
                dtpBirthDate.Value = user.Birthdate;
                if (user is Guest g) tbProfilePic.Text = g.ProfilePictureURL;
            }
            
        }
        private void cbbEditUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUser = (User)cbbEditUser.SelectedItem;
            LoadUser(selectedUser);
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbbEditUser.SelectedIndex <0)
                {
                    MessageBox.Show("No user selected!");
                }
                else if (loggedIn.Email == selectedUser.Email)
                {
                    MessageBox.Show("You cannot remove your own account!");
                }
                else
                {
                    SpaceApp.Instance.UserManager.RemoveUser(selectedUser);
                    //all good
                    MessageBox.Show("User removed succesfully!");
                    this.Hide();
                    this.Close();
                }
                
            }
            catch(Exception ex) { MessageBox.Show("Something went wrong: " + ex.Message) ; }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbPassword.Text) && selectedUser != null)
                {
                    MessageBox.Show("Please enter the user's password to make changes to their details");
                }
                else
                {
                    if (SpaceApp.Instance.UserManager.AuthenthicateUser(tbEmail.Text, tbPassword.Text) == null)
                    {
                        MessageBox.Show("Wrong Password");
                    }
                    else
                    {
                        if (selectedUser is Guest g)
                        {
                            SpaceApp.Instance.UserManager.UpdateUser(g.Email, new Guest(tbProfilePic.Text, tbFirstName.Text, tbLastName.Text, tbEmail.Text, tbPassword.Text, dtpBirthDate.Value)); //with the correct value of password
                        }
                        else if (selectedUser is Administrator a)
                        {
                            SpaceApp.Instance.UserManager.UpdateUser(a.Email, new Administrator(tbFirstName.Text, tbPassword.Text, tbEmail.Text, tbLastName.Text, dtpBirthDate.Value));
                        }
                        else if (selectedUser is Employee emp)
                        {
                            SpaceApp.Instance.UserManager.UpdateUser(emp.Email, new Employee(tbFirstName.Text, tbPassword.Text, tbEmail.Text, tbLastName.Text, dtpBirthDate.Value));
                        }
                        //all good
                        MessageBox.Show("User updated succesfully");
                        this.Hide();
                        this.Close();
                    }
                    
                }
           
            }
            catch(Exception ex) { MessageBox.Show("Something went wrong: " + ex.Message); }

            
        }
    }
}
