using System;
using System.Windows.Forms;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Forms
{
    public partial class Login : Form
    {
        private IUserRepository m_userRepository;

        public string username
        {
            get => usernameTextBox.Text;
            set => usernameTextBox.Text = value;
        }
        public string password
        {
            get => passwordTextBox.Text;
            set => passwordTextBox.Text = value;
        }

        public Login(IUserRepository userRepository)
        {
            m_userRepository = userRepository;
            InitializeComponent();
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            DataSources.Data.StaticDataSource.currUser = usernameTextBox.Text;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Close();
            if(m_userRepository.Login(username, password))
            {
                Library library = new Library();
                library.ShowDialog();
            } else
            {
                MessageBox.Show("User not found. Please register before trying to log in.");
            }
           
        }
    }
}
