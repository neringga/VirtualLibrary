using System;
using System.Windows.Forms;
using VirtualLibrary.Presenters;

namespace VirtualLibrary.Forms
{
    public partial class BarcodeScanner : Form
    {
        public BarcodeScanner()
        {
            InitializeComponent();
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

                    var result = scannerPresenter.DecodedBarcode(imageLocation);

                    if (result != null)
                    {
                        MessageBox.Show(result.Text);
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
    }
}
