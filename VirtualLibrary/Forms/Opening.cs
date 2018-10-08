using System;
using System.Windows.Forms;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private readonly IUserRepository _mUserRepository;

        public Opening(IUserRepository userRepository)
        {
            _mUserRepository = userRepository;
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            
           new Registration(_mUserRepository).ShowDialog();
            this.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var login = new Login(_mUserRepository);
            login.ShowDialog();
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