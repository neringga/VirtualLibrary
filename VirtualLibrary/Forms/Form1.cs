using System;
using System.Windows.Forms;
using VirtualLibrary.View;
using VirtualLibrary.Presenters;

namespace VirtualLibrary
{
    public partial class Form1 : Form, IUser
    {
        private ErrorProvider passwordErrorProvider;
        private ErrorProvider repPasswordErrorProvider;

        public string Name
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value;
        }
        public string Surname
        {
            get => surnameTextBox.Text;
            set => surnameTextBox.Text = value;
        }
        public string Email
        {
            get => emailTextBox.Text;
            set => emailTextBox.Text = value;
        }

        public string DateOfBirth
        {
            get => dateTimeBox.Text;
            set => dateTimeBox.Text = value;
        }
        public string Password
        {
            get => passwordTextBox.Text;
            set => passwordTextBox.Text = value;
        }


        public Form1()
        {
            InitializeComponent();

            registerButton.Enabled = false;

            passwordErrorProvider = new System.Windows.Forms.ErrorProvider();
            passwordErrorProvider.SetIconAlignment(this.passwordTextBox, ErrorIconAlignment.MiddleRight);
            passwordErrorProvider.SetIconPadding(this.passwordTextBox, 2);
            passwordErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;

            repPasswordErrorProvider = new System.Windows.Forms.ErrorProvider();
            repPasswordErrorProvider.SetIconAlignment(this.repeatPasswTextBox, ErrorIconAlignment.MiddleRight);
            repPasswordErrorProvider.SetIconPadding(this.repeatPasswTextBox, 2);
            repPasswordErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form photoForm = new Form2();
            photoForm.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(nameTextBox.Text)) &&
                !(String.IsNullOrEmpty(surnameTextBox.Text)) &&
                !(String.IsNullOrEmpty(emailTextBox.Text)) &&
                !(String.IsNullOrEmpty(repeatPasswTextBox.Text)) &&
                !(String.IsNullOrEmpty(dateTimeBox.Text)))
            {
                UserPresenter userPresenter = new UserPresenter(this);
                userPresenter.UserDataInsertUser();
            }
            else
            {
                MessageBox.Show("All fields have to be filled");
            }

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }


        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length < 6)
            {
                passwordErrorProvider.SetError(this.passwordTextBox, "Password needs to be longer than 6 letters");
            }
            else
            {
                passwordErrorProvider.SetError(this.passwordTextBox, String.Empty);

            }
        }

        private void RepeatPasswTextBox_TextChanged(object sender, EventArgs e)
        {
            if (repeatPasswTextBox.Text.Equals(passwordTextBox.Text))
            {
                repPasswordErrorProvider.SetError(this.repeatPasswTextBox, String.Empty);
                registerButton.Enabled = true;
            }
            else
            {
                repPasswordErrorProvider.SetError(this.repeatPasswTextBox, "Passwords do not match");
                registerButton.Enabled = false;
            }
        }
    }
}
