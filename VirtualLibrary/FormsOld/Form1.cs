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
using VirtualLibrary.Model;
using VirtualLibrary.Presenters;
using VirtualLibrary.Data;


namespace VirtualLibrary
{
    public partial class Form1 : Form, IUser
    {

        public string NameText
        {
            get
            {
                return nameTextBox.Text;
            }
            set
            {
                nameTextBox.Text = value;
            }
        }
        public string SurnameText
        {
            get
            {
                return surnameTextBox.Text;
            }
            set
            {
                surnameTextBox.Text = value;
            }
        }
        public string EmailText
        {
            get
            {
                return emailTextBox.Text;
            }
            set
            {
                emailTextBox.Text = value;
            }
        }

        public string DateOfBirthText
        {
            get
            {
                return dateTimeBox.Text;
            }
            set
            {
                dateTimeBox.Text = value;
            }
        }

        //public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        private void registerButton_Click(object sender, EventArgs e)
        {
            UserPresenter userPresenter = new UserPresenter(this);
            userPresenter.UserDataInsertUser();
            //string message = userPresenter.getUserList().ToArray();
            //MessageBox.Show(message);
            //this.Hide();
            //FirstForm f1 = new FirstForm();
            //f1.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
