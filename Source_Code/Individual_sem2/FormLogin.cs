
using SharedLibrary;
using UserLibrary;

namespace Individual_sem2
{
    public partial class FormLogin : Form
    {
        private UserManager userManager;
        public FormLogin()
        {
            InitializeComponent();
            //no warning from the start
            lblFailedLogIn.Text = string.Empty;
            //password textbox hidden text
            tbLoginPassword.UseSystemPasswordChar = true;

        }

        //button hover effect

        #region button css
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            if (btnLogin.Visible && btnLogin.Enabled)
            {
                btnLogin.BackColor = System.Drawing.SystemColors.ControlLight;
                btnLogin.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                btnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            }
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            if (btnLogin.Visible && btnLogin.Enabled)
            {
                btnLogin.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                btnLogin.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                btnLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            }

        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            if (btnRegister.Visible && btnRegister.Enabled)
            {
                btnRegister.BackColor = System.Drawing.SystemColors.ControlLight;
                btnRegister.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                btnRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            }
        }
        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            if (btnRegister.Visible && btnRegister.Enabled)
            {
                btnRegister.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                btnRegister.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                btnRegister.ForeColor = System.Drawing.SystemColors.ButtonFace;
            }

        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User tempuser = null;
            if (!string.IsNullOrEmpty(tbLoginUsername.Text) && !string.IsNullOrEmpty(tbLoginPassword.Text))
            {
                tempuser = SpaceApp.Instance.UserManager.AuthenthicateUser(tbLoginUsername.Text, tbLoginPassword.Text);
            }
                
            if (tempuser == null)
            {
                //reset password field for another login attempt
                lblFailedLogIn.Text = "*Credentials did not match";
                tbLoginPassword.Text = string.Empty;
            }
            else if (tempuser is Employee employee)
            {
                FormEmployee employee1 = new FormEmployee(employee);
                this.Hide();
                employee1.ShowDialog();
                this.Close();

            }
            else if (tempuser is Guest guest)
            {
                FormGuest guest1 = new FormGuest(guest);
                this.Hide();
                guest1.ShowDialog();
                this.Close();
            }
            else if (tempuser is Administrator administrator)
            {
                FormAdministrator administrator1 = new FormAdministrator(administrator);
                this.Hide();
                administrator1.ShowDialog();
                this.Close();

            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
            this.Close();
        }

    }
}