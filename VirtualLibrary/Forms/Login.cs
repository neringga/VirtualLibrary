using System;
using System.Windows.Forms;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;

namespace VirtualLibrary.Forms
{
    public partial class Login : Form
    {
        private IRepository<IUser> m_userRepository;

        public Login(IRepository<IUser> userRepository)
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
            Library library = new Library();
            library.ShowDialog();
        }
    }
}
