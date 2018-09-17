using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnBarcode.Barcode.BarcodeScanner;
using ZXing;
using ZXing.Common;
using ZXing.Presentation;

namespace VirtualLibrary.Forms
{
    public partial class BarcodeScanner : Form
    {
        public BarcodeScanner()
        {
            InitializeComponent();
        }

        private void pictureUploadButton_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    imageLocation = dialog.FileName;

                    barcodePictureBox.ImageLocation = imageLocation;

                    IBarcodeReader reader = new ZXing.BarcodeReader();
                    Bitmap barcodeBitmap = (Bitmap)Image.FromFile(imageLocation);
                    var result = reader.Decode(barcodeBitmap);
                    if (result != null)
                    {
                        MessageBox.Show(result.BarcodeFormat.ToString());
                        MessageBox.Show(result.Text);

                    }
                    else
                    {
                        MessageBox.Show("Couldn't scan the barcode");
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
