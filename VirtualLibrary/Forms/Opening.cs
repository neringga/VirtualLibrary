using System;
using System.Windows.Forms;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private FaceRecognitionLogin _faceRecognitionLoginForm;
        private Registration _registrationForm;
        private Login _loginForm;

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
            _registrationForm.ShowDialog();
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