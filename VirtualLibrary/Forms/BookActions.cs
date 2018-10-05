using System;
using System.Linq;
using System.Windows.Forms;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Helpers;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;
using ZXing;

namespace VirtualLibrary.Forms
{
    public partial class BookActions : Form
    {
        private IBook _book;
        private readonly TakenBookPresenter _mTakenBookPresenter;
        private Result _result;


        public BookActions()
        {
            InitializeComponent();
            ScannedBookInfo.Enabled = false;
            Info.Enabled = false;
            _mTakenBookPresenter = new TakenBookPresenter(new BookRepository(StaticDataSource.DataSource));
        }

        private void PictureUploadButton_Click(object sender, EventArgs e)
        {
            var imageLocation = "";
            try
            {
                var dialog = new OpenFileDialog
                {
                    Filter = "jpg files(*.jpg)|*.jpg| All Files(*.*)|*.*"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var scannerPresenter = new ScannerPresenter();

                    imageLocation = dialog.FileName;
                    barcodePictureBox.ImageLocation = imageLocation;
                    ScannedBookInfo.Visible = false;
                    Info.Visible = false;
                    _result = scannerPresenter.DecodedBarcode(imageLocation);

                    if (_result != null)
                    {
                        _book = scannerPresenter.ScannedBook(_result.Text);
                        ScannedBookInfo.Text = _book.Author + " " + _book.Title;
                        ScannedBookInfo.Visible = true;
                        Info.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Picture is too big");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScannedBookInfo_Click(object sender, EventArgs e)
        {
        }

        private void TakeBookButton_Click(object sender, EventArgs e)
        {
            if (_result.Text != null)
            {
                _mTakenBookPresenter.AddTakenBook(_book, StaticDataSource.CurrUser);
                var takenBooks = _mTakenBookPresenter.GetTakenBooks();
                var addedBook = takenBooks.First(item => item.Code == _book.Code && item.TakenByUser ==
                                                         StaticDataSource.CurrUser);
                MessageBox.Show("You have to return this book on " + addedBook.HasToBeReturned);
                var userRepository = new UserRepository(StaticDataSource.DataSource);
                var userPresenter = new UserPresenter(null, userRepository);
                var users = userPresenter.GetUserList();


                var userToSendEmailTo =
                    users.First(user => user.Nickname == StaticDataSource.CurrUser);

                var bookReturnWarning = new BookReturnWarning(
                    userToSendEmailTo.Email,
                    addedBook.HasToBeReturned,
                    _book.Author,
                    _book.Title);
                bookReturnWarning.SendWarningEmail();
            }
            else
            {
                MessageBox.Show("Please add picture of the barcode");
            }
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (_result.Text != null)
            {
                var bookReturnValidator = new BookReturnValidator();
                var book = bookReturnValidator.TakenBookListCheckForBook(_result.Text);
                if (book != null)
                {
                    _mTakenBookPresenter.RemoveTakenBook(book);
                    MessageBox.Show("Book returned successfully.");
                }
                else
                {
                    MessageBox.Show("You can not return this book.");
                }
            }
            else
            {
                MessageBox.Show("Please add picture of the barcode");
            }
        }
    }
}