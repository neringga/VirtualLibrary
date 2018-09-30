using System;
using System.Linq;
using System.Windows.Forms;
using VirtualLibrary.Helpers;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;
using VirtualLibrary.View;
using ZXing;

namespace VirtualLibrary.Forms
{
    public partial class BookActions : Form
    {
        private IBook book;
        private TakenBookPresenter m_takenBookPresenter;
        private Result result;


        public BookActions()
        {
            InitializeComponent();
            ScannedBookInfo.Enabled = false;
            Info.Enabled = false;
            m_takenBookPresenter = new TakenBookPresenter(new BookRepository(DataSources.Data.StaticDataSource._dataSource));
        }

        private void PictureUploadButton_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "jpg files(*.jpg)|*.jpg| All Files(*.*)|*.*"
                };

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    ScannerPresenter scannerPresenter = new ScannerPresenter();

                    imageLocation = dialog.FileName;
                    barcodePictureBox.ImageLocation = imageLocation;
                    ScannedBookInfo.Visible = false;
                    Info.Visible = false;
                    result = scannerPresenter.DecodedBarcode(imageLocation);

                    if (result != null)
                    {
                        book = scannerPresenter.ScannedBook(result.Text);
                        ScannedBookInfo.Text = book.Author + " " + book.Title;
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
            if (result.Text != null)
            {
                m_takenBookPresenter.AddTakenBook(view: book, username: DataSources.Data.StaticDataSource.currUser);
                var takenBooks = m_takenBookPresenter.GetTakenBooks();
                var addedBook = takenBooks.First(item => item.Code == book.Code && item.TakenByUser ==
                DataSources.Data.StaticDataSource.currUser);
                MessageBox.Show("You have to return this book on " + addedBook.HasToBeReturned);
            }
            else MessageBox.Show("Please add picture of the barcode");
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            if (result.Text != null)
            {
                BookReturnValidator bookReturnValidator = new BookReturnValidator();
                var book = bookReturnValidator.TakenBookListCheckForBook(code: result.Text);
                if (book != null)
                {
                    m_takenBookPresenter.RemoveTakenBook(book);
                    MessageBox.Show("Book returned successfully.");
                }
                else
                {
                    MessageBox.Show("You can not return this book.");
                }
            }
            else MessageBox.Show("Please add picture of the barcode");
        }
    }
}
