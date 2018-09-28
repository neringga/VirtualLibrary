using System;
using System.Windows.Forms;
using VirtualLibrary.View;
using VirtualLibrary.Presenters;
using VirtualLibrary.DataSources;
using VirtualLibrary.Repositories;
using VirtualLibrary.Helpers;

namespace VirtualLibrary
{
    public partial class Registration : Form, IUser
    {
        private ErrorProvider passwordErrorProvider;
        private ErrorProvider repPasswordErrorProvider;
        private ErrorProvider usernameErrorProvider;

        public new string Name
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
        public string Nickname
        {
            get => UserNameTextBox.Text;
            set => UserNameTextBox.Text = value;
        }



        public Registration()
        {
            InitializeComponent();

            registerButton.Enabled = false;

            usernameErrorProvider = new ErrorProvider();
            usernameErrorProvider.SetIconAlignment(this.UserNameTextBox, ErrorIconAlignment.MiddleRight);
            usernameErrorProvider.SetIconPadding(this.UserNameTextBox, 2);
            usernameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            passwordErrorProvider = new ErrorProvider();
            passwordErrorProvider.SetIconAlignment(this.passwordTextBox, ErrorIconAlignment.MiddleRight);
            passwordErrorProvider.SetIconPadding(this.passwordTextBox, 2);
            passwordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            repPasswordErrorProvider = new ErrorProvider();
            repPasswordErrorProvider.SetIconAlignment(this.repeatPasswTextBox, ErrorIconAlignment.MiddleRight);
            repPasswordErrorProvider.SetIconPadding(this.repeatPasswTextBox, 2);
            repPasswordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form photoForm = new LiveCamera();
            photoForm.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(emailTextBox.Text) &&
                !string.IsNullOrEmpty(repeatPasswTextBox.Text) &&
                !string.IsNullOrEmpty(dateTimeBox.Text))
            {
                var userRepository = new UserRepository(DataSources.Data.StaticDataSource._dataSource);
                UserPresenter userPresenter = new UserPresenter(this, userRepository);
                userPresenter.AddUser();
            }
            else
            {
                MessageBox.Show("All fields have to be filled");
            }
            this.Close();
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

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator inputValidator = new InputValidator();
            if (inputValidator.ValidUsername(UserNameTextBox.Text))
            {
                 usernameErrorProvider.SetError(this.UserNameTextBox, "This username already exist");
            }
            else
            {
                usernameErrorProvider.SetError(this.UserNameTextBox, String.Empty);
            }
        }
    }
}
