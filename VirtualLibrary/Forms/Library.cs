using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VirtualLibrary.Data;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.DataSources;
using System.Linq;

namespace VirtualLibrary.Forms
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();

            BookListFromFile bookListFromFile = new BookListFromFile(); 
            var m_takenBookPresenter = new TakenBookPresenter
                (new BookRepository(DataSources.Data.StaticDataSource._dataSource));
            var books = bookListFromFile.GetBookList();
            var takenBooks = m_takenBookPresenter.GetTakenBooks();

            foreach(var book in takenBooks)
            {
                if (book.TakenByUser == DataSources.Data.StaticDataSource.currUser)
                {
                    var book1 = books.First(item => item.Code == book.Code);
                    bookListBox.Items.Add(book1.Author + book1.Title + " RETURN ON " + book.HasToBeReturned);
                }
            }

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
