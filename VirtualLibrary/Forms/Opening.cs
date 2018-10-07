using System;
using System.Windows.Forms;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private Registration _registrationForm;
        private Login _loginForm;

        public Opening(Registration registrationForm, Login loginForm)
        {
            InitializeComponent();

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
            using (var form = new FaceRecognitionLogin())
            {
                Hide();
                form.ShowDialog();
                Show();
            }
        }
    }
}