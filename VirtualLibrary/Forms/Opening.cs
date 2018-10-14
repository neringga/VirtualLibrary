using System;
using System.Windows.Forms;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private static string _language;
        private readonly FaceRecognitionLogin _faceRecognitionLoginForm;
        private readonly Registration _registrationForm;
        private readonly Login _loginForm;


        public Opening(Registration registrationForm, Login loginForm, FaceRecognitionLogin faceRecognitionLoginForm)
        {
            InitializeComponent();

            _faceRecognitionLoginForm = faceRecognitionLoginForm;
            _registrationForm = registrationForm;
            _loginForm = loginForm;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Hide();
            _registrationForm.ShowDialog();
            Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _loginForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            _faceRecognitionLoginForm.Init();
            _faceRecognitionLoginForm.ShowDialog();
        }

        private void Opening_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _language = "LT";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _language = "EN";
        }
        public static string GetUserLanguageSetting()
        {
            return _language;
        }
    }
}