using System;
using System.Linq;
using System.Windows.Forms;
using VirtualLibrary.DataSources;
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
        private Library _libraryForm;
        private Result _result;
        private IUserRepository _userRepository;
        private IDataSource _dataSource;


        public BookActions(TakenBookPresenter takenBookPresenter, Library libraryForm, IUserRepository userRepository, IDataSource dataSource)
        {
            InitializeComponent();
            ScannedBookInfo.Enabled = false;
            Info.Enabled = false;
            _mTakenBookPresenter = takenBookPresenter;
            _libraryForm = libraryForm;
            _userRepository = userRepository;
            _dataSource = dataSource;
        }

        private void PictureUploadButton_Click(object sender, EventArgs e)
        {
            //var imageLocation = "";
            try
            {
                var dialog = new OpenFileDialog
                {
                    Filter = Constants.PictureFilter
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
                MessageBox.Show("Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //_mTakenBookPresenter.AddTakenBook(_book, StaticDataSource.CurrUser);
                    var takenBooks = _mTakenBookPresenter.GetTakenBooks();
                    var addedBook = takenBooks.First(item => item.Code == _book.Code && item.TakenByUser ==
                                                             _dataSource.CurrUser);

                    var userPresenter = new UserPresenter(null, _userRepository);
                    var users = userPresenter.GetUserList();


                    var userToSendEmailTo =
                        users.First(user => user.Nickname == _dataSource.CurrUser);
                    var bookReturnWarning = new BookReturnWarning(
                    userToSendEmailTo.Email,
                    addedBook.HasToBeReturned,
                    _book.Author,
                    _book.Title);
                    bookReturnWarning.SendWarningEmail();
                    MessageBox.Show("You have to return this book on " + addedBook.HasToBeReturned);
                }
                catch (Exception)
                {
                    MessageBox.Show("You can not return this book");
                }

            }
            else
            {
                MessageBox.Show("Please add picture of the barcode");
            }
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (_result != null)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            _libraryForm.ShowDialog();
        }
    }
}