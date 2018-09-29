using System;
using System.Windows.Forms;

namespace VirtualLibrary.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
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
