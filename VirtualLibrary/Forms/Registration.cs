using System;
using System.IO;
using System.Text.RegularExpressions;
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
        private readonly ErrorProvider _emailErrorProvider;

        private Image<Gray, byte>[] _faceImages;

        private readonly UserPresenter _mUserPresenter;
        private readonly ErrorProvider _nameErrorProvider;
        private readonly ErrorProvider _passwordErrorProvider;
        private readonly ErrorProvider _repPasswordErrorProvider;
        private readonly ErrorProvider _surnameErrorProvider;
        private readonly ErrorProvider _usernameErrorProvider;
        private static string _language;

        public Registration(IRepository<IUser> userRepository)
        {
            InitializeComponent();

            registerButton.Enabled = false;

            _usernameErrorProvider = new ErrorProvider();
            _usernameErrorProvider.SetIconAlignment(usernameTextBox, ErrorIconAlignment.MiddleRight);
            _usernameErrorProvider.SetIconPadding(usernameTextBox, 2);
            _usernameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _nameErrorProvider = new ErrorProvider();
            _nameErrorProvider.SetIconAlignment(usernameTextBox, ErrorIconAlignment.MiddleRight);
            _nameErrorProvider.SetIconPadding(usernameTextBox, 2);
            _nameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _surnameErrorProvider = new ErrorProvider();
            _surnameErrorProvider.SetIconAlignment(usernameTextBox, ErrorIconAlignment.MiddleRight);
            _surnameErrorProvider.SetIconPadding(usernameTextBox, 2);
            _surnameErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _emailErrorProvider = new ErrorProvider();
            _emailErrorProvider.SetIconAlignment(usernameTextBox, ErrorIconAlignment.MiddleRight);
            _emailErrorProvider.SetIconPadding(usernameTextBox, 2);
            _emailErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _passwordErrorProvider = new ErrorProvider();
            _passwordErrorProvider.SetIconAlignment(passwordTextBox, ErrorIconAlignment.MiddleRight);
            _passwordErrorProvider.SetIconPadding(passwordTextBox, 2);
            _passwordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

            _repPasswordErrorProvider = new ErrorProvider();
            _repPasswordErrorProvider.SetIconAlignment(repeatPasswTextBox, ErrorIconAlignment.MiddleRight);
            _repPasswordErrorProvider.SetIconPadding(repeatPasswTextBox, 2);
            _repPasswordErrorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;

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
            //var inputValidator = new InputValidator();
            if (string.IsNullOrEmpty(nameTextBox.Text))
                _nameErrorProvider.SetError(nameTextBox, Translations.GetTranslatedString("empty"));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var photoForm = new LiveCamera())
            {
                MessageBox.Show(Translations.GetTranslatedString("lookAtCamera"), Translations.GetTranslatedString("attention"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                photoForm.ShowDialog();
                _faceImages = photoForm.GrayPictures;
                InputCorrect();
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            _mUserPresenter.AddUser();

            UserInformationInXmlFiles xml = new UserInformationInXmlFiles(
                new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\userinformation\\", Constants.FaceImagesPerUser);

            if (File.Exists(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\userinformation\\faceImages.xml"))
            {
                xml.AddUser(_faceImages, this);
            }
            else
            {
                xml.CreateNewUserList(_faceImages, this);
            }

            Close();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }


        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length < 6)
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

        private void Registration_Load(object sender, EventArgs e)
        {
        }

        private void Label4_Click(object sender, EventArgs e)
        {
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
            var inputValidator = new InputValidator();
            if (string.IsNullOrEmpty(usernameTextBox.Text))
                _surnameErrorProvider.SetError(usernameTextBox, Translations.GetTranslatedString("empty"));
            if (inputValidator.ValidUsername(usernameTextBox.Text))
                _usernameErrorProvider.SetError(usernameTextBox, Translations.GetTranslatedString("usernameExists"));
            else
                _usernameErrorProvider.SetError(usernameTextBox, string.Empty);
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            new InputValidator();
            if (string.IsNullOrEmpty(surnameTextBox.Text))
                _surnameErrorProvider.SetError(surnameTextBox, Translations.GetTranslatedString("empty"));
            else
                _surnameErrorProvider.SetError(surnameTextBox, string.Empty);
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(emailTextBox.Text);
            if (!match.Success)
                _emailErrorProvider.SetError(emailTextBox, Translations.GetTranslatedString("incorrectFormat"));
            else
                _emailErrorProvider.SetError(emailTextBox, string.Empty);
        }

        private void InputCorrect()
        {
            if (!string.IsNullOrEmpty(usernameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(nameTextBox.Text) &&
                !string.IsNullOrEmpty(emailTextBox.Text) &&
                _faceImages != null
                )
                registerButton.Enabled = true;
            else
                registerButton.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _language = "EN";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _language = "LT";
        }

        public static  string GetUserLanguageSetting() {
            return _language;
        }
    }
}