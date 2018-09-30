using System;
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
        private Result result;
       

        public BookActions()
        {
            InitializeComponent();
            ScannedBookInfo.Enabled = false;
            Info.Enabled = false;
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
            var takenBookPresenter = new TakenBookPresenter(new TakenBookRepository
                (DataSources.Data.StaticDataSource._dataSource));
            MessageBox.Show("You have to return this book on " + takenBookPresenter.AddTakenBook(view: book, 
                username: DataSources.Data.StaticDataSource.currUser).ToString()); 
        }

        private void ReturnBookButton_Click(object sender, EventArgs e)
        {
            BookReturnValidator bookReturnValidator = new BookReturnValidator();
            var takenBookRepository = new TakenBookRepository(DataSources.Data.StaticDataSource._dataSource);
            TakenBookPresenter takenBookPresenter = new TakenBookPresenter(takenBookRepository);
            var book = bookReturnValidator.TakenBookListCheckForBook(code : result.Text); 
            if (book != null)
            {
                takenBookPresenter.RemoveTakenBook(book);
                MessageBox.Show("Book returned successfully");
            }
            else {
                MessageBox.Show("You can not return this book");
            }
        }
    }
}
