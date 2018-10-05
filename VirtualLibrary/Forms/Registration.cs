using System;
using System.Windows.Forms;
using VirtualLibrary.View;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.Helpers;
using System.Text.RegularExpressions;
using VirtualLibrary.DataSources.Data;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

namespace VirtualLibrary
{
    public partial class Registration : Form, IUser
    {
        private ErrorProvider passwordErrorProvider;
        private ErrorProvider repPasswordErrorProvider;
        private ErrorProvider usernameErrorProvider;
        private ErrorProvider nameErrorProvider;
        private ErrorProvider emailErrorProvider;
        private ErrorProvider surnameErrorProvider;

        private UserPresenter m_userPresenter;

        private Image<Gray, byte>[] faceImages = null;

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
            get => usernameTextBox.Text;
            set => usernameTextBox.Text = value;
        }



        public Registration(IRepository<IUser> userRepository)
        {
            InitializeComponent();

            registerButton.Enabled = false;

            usernameErrorProvider = new ErrorProvider();
            usernameErrorProvider.SetIconAlignment(this.usernameTextBox, ErrorIconAlignment.MiddleRight);
            usernameErrorProvider.SetIconPadding(this.usernameTextBox, 2);
            usernameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            nameErrorProvider = new ErrorProvider();
            nameErrorProvider.SetIconAlignment(this.usernameTextBox, ErrorIconAlignment.MiddleRight);
            nameErrorProvider.SetIconPadding(this.usernameTextBox, 2);
            nameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            surnameErrorProvider = new ErrorProvider();
            surnameErrorProvider.SetIconAlignment(this.usernameTextBox, ErrorIconAlignment.MiddleRight);
            surnameErrorProvider.SetIconPadding(this.usernameTextBox, 2);
            surnameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            emailErrorProvider = new ErrorProvider();
            emailErrorProvider.SetIconAlignment(this.usernameTextBox, ErrorIconAlignment.MiddleRight);
            emailErrorProvider.SetIconPadding(this.usernameTextBox, 2);
            emailErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            passwordErrorProvider = new ErrorProvider();
            passwordErrorProvider.SetIconAlignment(this.passwordTextBox, ErrorIconAlignment.MiddleRight);
            passwordErrorProvider.SetIconPadding(this.passwordTextBox, 2);
            passwordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            repPasswordErrorProvider = new ErrorProvider();
            repPasswordErrorProvider.SetIconAlignment(this.repeatPasswTextBox, ErrorIconAlignment.MiddleRight);
            repPasswordErrorProvider.SetIconPadding(this.repeatPasswTextBox, 2);
            repPasswordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            m_userPresenter = new UserPresenter(this, userRepository);

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator inputValidator = new InputValidator();
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                nameErrorProvider.SetError(this.nameTextBox, "Can't be empty");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (LiveCamera photoForm = new LiveCamera())
            {
                MessageBox.Show("Look to the camera for 3 seconds", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                photoForm.ShowDialog();
                this.faceImages = photoForm.grayPictures;
                InputCorrect();
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            m_userPresenter.AddUser();
      
            //UserInformationInXMLFiles xml = new UserInformationInXMLFiles(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\UserInformation\\", 5);
            //xml.AddUser(faceImages, this);

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
                InputCorrect();
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
            if (string.IsNullOrEmpty(usernameTextBox.Text))
            {
                surnameErrorProvider.SetError(this.usernameTextBox, "Can't be empty");
            }
            if (inputValidator.ValidUsername(usernameTextBox.Text))
            {
                usernameErrorProvider.SetError(this.usernameTextBox, "This username already exist");
            }
            else
            {
                usernameErrorProvider.SetError(this.usernameTextBox, String.Empty);
            }
        }
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            InputValidator inputValidator = new InputValidator();
            if (string.IsNullOrEmpty(surnameTextBox.Text))
            {
                surnameErrorProvider.SetError(this.surnameTextBox, "Can't be empty");
            }
            else
            {
                surnameErrorProvider.SetError(this.surnameTextBox, String.Empty);
            }
        }
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailTextBox.Text);
            if (!match.Success)
            {
                emailErrorProvider.SetError(this.emailTextBox, "Incorrect format");
            }
            else
            {
                emailErrorProvider.SetError(this.emailTextBox, String.Empty);
            }
        }

        private void InputCorrect()
        {
            if (!string.IsNullOrEmpty(usernameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(nameTextBox.Text) &&
                !string.IsNullOrEmpty(emailTextBox.Text) //&&
                //faceImages != null
                )
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }

    }
}
