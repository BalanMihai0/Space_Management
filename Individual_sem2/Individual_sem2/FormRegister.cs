using CustomExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLibrary;
using SharedLibrary;

namespace Individual_sem2
{
    public partial class FormRegister : Form
    {
        private UserManager userManager;
        public FormRegister()
        {
            InitializeComponent();
            ResetWarnings();
            //password boxes hidden
            tbRegisterPassword.UseSystemPasswordChar = true;
            tbRegisterConfrimPassword.UseSystemPasswordChar = true;

        }

        private void ResetWarnings()
        {
            lblInvalidURL.Text = string.Empty;
            lblInvalidDate.Text = string.Empty;
            lblInvalidLastName.Text = string.Empty;
            lblInvalidFirstName.Text = string.Empty;
            lblEmailInvalid.Text = string.Empty;
            lblPasswordWeak.Text = string.Empty;
            lblPasswordsDontMatch.Text = string.Empty;
        }

        #region button css

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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ResetWarnings();
                //checking for the confirm password
                if (!(tbRegisterConfrimPassword.Text == tbRegisterPassword.Text))
                    throw new PasswordMatchException("Confirm password wrong");

                //Guest accounts can be created here
                SpaceApp.Instance.UserManager.AddGuest(tbRegisterFirstName.Text, tbRegisterLastName.Text, tbRegisterPassword.Text, tbRegisterEmail.Text, dtpRegisterBirthday.Value, tbRegisterProfilePic.Text);
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
            catch (InvalidEmailException) { lblEmailInvalid.Text = "Invalid Email!"; }
            catch (InvalidFirstNameException) { lblInvalidFirstName.Text = "Invalid Name!"; }
            catch (InvalidLastNameException) { lblInvalidLastName.Text = "Invalid Name!"; }
            catch (WeakPasswordException) { lblPasswordWeak.Text = "Password too weak! Must contain: letters, numbers, over 8 characters lenght"; }
            catch (InvalidBirthDateException) { lblInvalidDate.Text = "Invalid date!"; }
            catch (InvalidURLException) { lblInvalidURL.Text = "Invalid Link"; }
            catch (PasswordMatchException) { lblPasswordsDontMatch.Text = "Passwords don't match!"; }
        }

    }
}
