using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrary.Forms
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }

        private void ScannerOpenButton_Click(object sender, EventArgs e)
        {
            BarcodeScanner barcodeScanner = new BarcodeScanner();
            barcodeScanner.ShowDialog();
        }
    }
}
