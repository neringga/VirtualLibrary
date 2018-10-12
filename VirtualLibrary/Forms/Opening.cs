using System;
using System.Windows.Forms;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private readonly FaceRecognitionLogin _faceRecognitionLoginForm;
        private readonly Login _loginForm;
        private readonly Registration _registrationForm;

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
            Show();
        }
    }
}