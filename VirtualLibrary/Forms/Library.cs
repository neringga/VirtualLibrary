using System;
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
        private UserPresenter _userPresenter;
        private IExceptionLogger _exceptionLogger;

        public Library(TakenBookPresenter takenBookPresenter, ILibraryData libraryData, UserPresenter userPresenter,
            IExceptionLogger exceptionLogger)
        {
            _takenBookPresenter = takenBookPresenter;
            _libraryData = libraryData;
            _userPresenter = userPresenter;
            _exceptionLogger = exceptionLogger;

            InitializeComponent();


            try
            {
                var userTakenBooks = _takenBookPresenter.FindUserTakenBooks();

                foreach (var book in userTakenBooks)
                {
                    bookListBox.Items.Add(book.Author + book.Title + Translations.GetTranslatedString("returnOn") +
                                          book.HasToBeReturned);
                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private void ScannerOpenButton_Click(object sender, EventArgs e)
        {
            var bookActionsForm = new BookActions(_takenBookPresenter, _libraryData, _userPresenter, _exceptionLogger);
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