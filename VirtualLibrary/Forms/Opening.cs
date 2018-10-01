using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private IUserRepository m_userRepository;

        public Opening(IUserRepository userRepository)
        {
            m_userRepository = userRepository;
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Registration registerForm = new Registration(m_userRepository);
            registerForm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Login login = new Login(m_userRepository);
            login.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FaceRecognitionLogin form = new FaceRecognitionLogin())
            {
                this.Hide();
                form.ShowDialog();
                this.Show();
            }
        }
    }
}
