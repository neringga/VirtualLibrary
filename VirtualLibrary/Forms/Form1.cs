using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrary.View;
using VirtualLibrary.Presenters;

namespace VirtualLibrary
{
    public partial class Form1 : Form, IUser
    {
        public string NameText
        {
            get => nameTextBox.Text;
            set => nameTextBox.Text = value;
        }
        public string SurnameText
        {
            get => surnameTextBox.Text;
            set => surnameTextBox.Text = value;
        }
        public string EmailText
        {
            get => emailTextBox.Text;
            set => emailTextBox.Text = value;
        }

        public string DateOfBirthText
        {
            get => dateTimeBox.Text;
            set => dateTimeBox.Text = value;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form photoForm = new Form2();
            photoForm.Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            UserPresenter userPresenter = new UserPresenter(this);
            userPresenter.UserDataInsertUser();
            MessageBox.Show("Registered successfully");
        }
    }
}
