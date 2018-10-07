﻿using System;
using System.Linq;
using System.Windows.Forms;
using VirtualLibrary.Data;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Localization;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();

            var bookListFromFile = new BookList();
            var mTakenBookPresenter = new TakenBookPresenter
                (new BookRepository(StaticDataSource.DataSource));
            var books = bookListFromFile.GetBookList();
            var takenBooks = mTakenBookPresenter.GetTakenBooks();

            foreach (var book in takenBooks)
                if (book.TakenByUser == StaticDataSource.CurrUser)
                {
                    var book1 = books.First(item => item.Code == book.Code);
                    bookListBox.Items.Add(book1.Author + book1.Title + Translations.GetTranslatedString("returnOn") + book.HasToBeReturned);
                }
        }

        private void ScannerOpenButton_Click(object sender, EventArgs e)
        {
            Close();
            new BookActions().ShowDialog();
       
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

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}