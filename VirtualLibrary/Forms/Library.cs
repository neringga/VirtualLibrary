﻿using System;
using System.Linq;
using System.Windows.Forms;
using VirtualLibrary.Data;
using VirtualLibrary.DataSources;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Helpers;
using VirtualLibrary.Localization;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Library : Form
    {
        private readonly TakenBookPresenter _takenBookPresenter;
        private ILibraryData _libraryData;

        public Library(TakenBookPresenter takenBookPresenter, ILibraryData libraryData)
        {
            _takenBookPresenter = takenBookPresenter;
            _libraryData = libraryData;

            InitializeComponent();

            var bookListFromFile = new BookList();
            var books = bookListFromFile.GetBookList();
            var takenBooks = _takenBookPresenter.GetTakenBooks();

            foreach (var book in takenBooks)
                if (book.TakenByUser == StaticDataSource.CurrUser)
                {
                    var book1 = books.First(item => item.Code == book.Code);
                    bookListBox.Items.Add(book1.Author + book1.Title + Translations.GetTranslatedString("returnOn") +
                                          book.HasToBeReturned);
                }
        }

        private void ScannerOpenButton_Click(object sender, EventArgs e)
        {
            var bookActionsForm = new BookActions(_takenBookPresenter, _libraryData);
            Hide();
            bookActionsForm.ShowDialog();
            Close();
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