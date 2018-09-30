using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualLibrary.Data;
using VirtualLibrary.Model;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();

            BookListFromFile bookListFromFile = new BookListFromFile(); //Putting data to collection
            IList<View.IBook> bookList = bookListFromFile.GetBookList();

            foreach (var book in bookList)                              //iterating through it the right way.
                bookListBox.Items.Add(book.Author + " " + book.Title);

        }

        private void ScannerOpenButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show( System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            BookActions barcodeScanner = new BookActions();
            barcodeScanner.ShowDialog();
        }

        private void BookListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Library_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
