using System;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using VirtualLibrary.DataSources;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Helpers;
using VirtualLibrary.Localization;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;
using ZXing;

namespace VirtualLibrary.Forms
{
    public partial class BookActions : Form
    {
        private IBook _book;

        private ILibraryData _libraryData;
        private readonly TakenBookPresenter _mTakenBookPresenter;
        private UserPresenter _userPresenter;
        private Library _libraryForm;
        private Result _result;
        private IExceptionLogger _exceptionLogger;

        public BookActions(TakenBookPresenter takenBookPresenter, ILibraryData libraryData,
            UserPresenter userPresenter, IExceptionLogger exceptionLogger)
        {
            InitializeComponent();
            ScannedBookInfo.Enabled = false;
            Info.Enabled = false;

            _libraryForm = new Library(_mTakenBookPresenter, _libraryData, _userPresenter, _exceptionLogger);

            _userPresenter = userPresenter;
            _libraryData = libraryData;
            _mTakenBookPresenter = takenBookPresenter;
            _exceptionLogger = exceptionLogger;
        }

        private void PictureUploadButton_Click(object sender, EventArgs e)
        {
            //var imageLocation = "";
            try
            {
                var dialog = new OpenFileDialog
                {
                    Filter = StaticStrings.PictureFilter
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var scannerPresenter = new ScannerPresenter();

                    var imageLocation = dialog.FileName;
                    barcodePictureBox.ImageLocation = imageLocation;
                    ScannedBookInfo.Visible = false;
                    Info.Visible = false;
                    _result = scannerPresenter.DecodedBarcode(imageLocation);


                    _book = scannerPresenter.ScannedBook(_result.Text);
                    ScannedBookInfo.Text = _book.Author + " " + _book.Title;
                    ScannedBookInfo.Visible = true;
                    Info.Visible = true;

                }
            }
            catch (Exception)
            {
                MessageBox.Show(Translations.GetTranslatedString("tryAgain"), Translations.GetTranslatedString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                _result = null;
            }
        }

        private void ScannedBookInfo_Click(object sender, EventArgs e)
        {
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            if (_result != null)
            {
                try
                {
                    _mTakenBookPresenter.AddTakenBook(view: _book, username: StaticDataSource.CurrUser);

                    var takenBooks = _mTakenBookPresenter.GetTakenBooks();
                    var addedBook = takenBooks.First(item => item.Code == _book.Code && item.TakenByUser ==
                                                             StaticDataSource.CurrUser);

                    var bookReturnWarning = new BookReturnEmail(
                    _userPresenter.FindUser().Email,
                    addedBook.HasToBeReturned,
                    _book.Author,
                    _book.Title);
                    try
                    {
                        bookReturnWarning.SendWarningEmail();
                    }
                    catch (SmtpException ex)
                    {
                        _exceptionLogger.Log(ex);
                    }

                    MessageBox.Show(Translations.GetTranslatedString("returnUntil") + addedBook.HasToBeReturned);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show(Translations.GetTranslatedString("cannotTake"));
                }

            }
            else
            {
                MessageBox.Show(Translations.GetTranslatedString("addPicture"));
            }
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (_result != null)
            {
                var book = _libraryData.bookRepository.CheckForTakenBook(_result.Text);
                if (book != null)
                {
                    _mTakenBookPresenter.RemoveTakenBook(book);
                    MessageBox.Show(Translations.GetTranslatedString("returnSucessfully"));
                }
                else
                {
                    MessageBox.Show(Translations.GetTranslatedString("cannotReturn"));
                }
            }
            else
            {
                MessageBox.Show(Translations.GetTranslatedString("addPicture"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
            var lfrom = new Library(_mTakenBookPresenter, _libraryData, _userPresenter, _exceptionLogger);
            lfrom.ShowDialog();
        }
    }
}