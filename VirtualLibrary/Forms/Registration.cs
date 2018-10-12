using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Helpers;
using VirtualLibrary.Localization;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary
{
    public partial class Registration : Form, IUser
    {
        private static string _language;
        private readonly ErrorProvider _emailErrorProvider;

        private readonly UserPresenter _mUserPresenter;
        private readonly ErrorProvider _nameErrorProvider;
        private readonly ErrorProvider _passwordErrorProvider;
        private readonly ErrorProvider _repPasswordErrorProvider;
        private readonly ErrorProvider _surnameErrorProvider;
        private readonly ErrorProvider _usernameErrorProvider;

        private Image<Gray, byte>[] _faceImages;


        private readonly IInputValidator _inputValidator;

        public Registration(IRepository<IUser> userRepository, IInputValidator inputValidator)
        {
            _inputValidator = inputValidator;

            _usernameErrorProvider = new ErrorProvider();
            _nameErrorProvider = new ErrorProvider();
            _surnameErrorProvider = new ErrorProvider();
            _emailErrorProvider = new ErrorProvider();
            _passwordErrorProvider = new ErrorProvider();
            _repPasswordErrorProvider = new ErrorProvider();

            InitializeComponent();
            SetupErrorProviders();

            registerButton.Enabled = false;

            _mUserPresenter = new UserPresenter(this, userRepository);
        }

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

        public string Language
        {
            get => null;
            set => string.Copy(_language);
        }


        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_inputValidator.ValidString(nameTextBox.Text))
                _nameErrorProvider.SetError(nameTextBox, "Can't be empty");

            if (string.IsNullOrEmpty(nameTextBox.Text))
                _nameErrorProvider.SetError(nameTextBox, Translations.GetTranslatedString("empty"));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var photoForm = new LiveCamera())
            {
                MessageBox.Show(Translations.GetTranslatedString("lookAtCamera"),
                    Translations.GetTranslatedString("attention"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                photoForm.ShowDialog();
                _faceImages = photoForm.GrayPictures;
                InputCorrect();
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_inputValidator.ValidPassword(passwordTextBox.Text))
                _passwordErrorProvider.SetError(passwordTextBox, Translations.GetTranslatedString("shortPassword"));
            else
                _passwordErrorProvider.SetError(passwordTextBox, string.Empty);
        }

        private void RepeatPasswTextBox_TextChanged(object sender, EventArgs e)
        {
            if (repeatPasswTextBox.Text.Equals(passwordTextBox.Text))
            {
                _repPasswordErrorProvider.SetError(repeatPasswTextBox, string.Empty);
                InputCorrect();
            }
            else
            {
                _repPasswordErrorProvider.SetError(repeatPasswTextBox, Translations.GetTranslatedString("doNotMatch"));
                registerButton.Enabled = false;
            }
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_inputValidator.ValidString(usernameTextBox.Text))
                _surnameErrorProvider.SetError(usernameTextBox, Translations.GetTranslatedString("empty"));

            else if (_inputValidator.UsernameTaken(usernameTextBox.Text))
                _usernameErrorProvider.SetError(usernameTextBox, Translations.GetTranslatedString("usernameExists"));
            else
                _usernameErrorProvider.SetError(usernameTextBox, string.Empty);
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_inputValidator.ValidString(surnameTextBox.Text))
                _surnameErrorProvider.SetError(surnameTextBox, Translations.GetTranslatedString("empty"));
            else
                _emailErrorProvider.SetError(emailTextBox, string.Empty);
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!_inputValidator.ValidEmail(emailTextBox.Text))
                _emailErrorProvider.SetError(emailTextBox, Translations.GetTranslatedString("incorrectFormat"));
            else
                _emailErrorProvider.SetError(emailTextBox, string.Empty);
        }

        private void InputCorrect()
        {
            var enteredCredentials = new List<string>
                {usernameTextBox.Text, surnameTextBox.Text, nameTextBox.Text, emailTextBox.Text};
            if (_inputValidator.ValidateStrings(enteredCredentials))
                registerButton.Enabled = true;
            else
                registerButton.Enabled = false;
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            _mUserPresenter.AddUser();

            var xml = new UserInformationInXmlFiles(
                new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\userinformation\\",
                StaticStrings.FaceImagesPerUser);

            if (File.Exists(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName +
                            "\\userinformation\\faceImages.xml"))
                xml.AddUser(_faceImages, this);
            else
                xml.CreateNewUserList(_faceImages, this);

            Close();
        }


        private void SetupErrorProviders()
        {
            _usernameErrorProvider.SetIconAlignment(usernameTextBox, ErrorIconAlignment.MiddleRight);
            _usernameErrorProvider.SetIconPadding(usernameTextBox, 2);
            _usernameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _nameErrorProvider.SetIconAlignment(nameTextBox, ErrorIconAlignment.MiddleRight);
            _nameErrorProvider.SetIconPadding(nameTextBox, 2);
            _nameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _surnameErrorProvider.SetIconAlignment(surnameTextBox, ErrorIconAlignment.MiddleRight);
            _surnameErrorProvider.SetIconPadding(surnameTextBox, 2);
            _surnameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _emailErrorProvider.SetIconAlignment(emailTextBox, ErrorIconAlignment.MiddleRight);
            _emailErrorProvider.SetIconPadding(emailTextBox, 2);
            _emailErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _passwordErrorProvider.SetIconAlignment(passwordTextBox, ErrorIconAlignment.MiddleRight);
            _passwordErrorProvider.SetIconPadding(passwordTextBox, 2);
            _passwordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _repPasswordErrorProvider.SetIconAlignment(repeatPasswTextBox, ErrorIconAlignment.MiddleRight);
            _repPasswordErrorProvider.SetIconPadding(repeatPasswTextBox, 2);
            _repPasswordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
        }


        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void Registration_Load(object sender, EventArgs e)
        {
        }

        private void Label4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _language = "EN";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _language = "LT";
        }

        public static string GetUserLanguageSetting()
        {
            return _language;
        }
    }
}