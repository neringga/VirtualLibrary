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

namespace VirtualLibrary.Forms
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 registerForm = new Form1();
            registerForm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Library library = new Library();
            library.ShowDialog();
        }
    }
}
