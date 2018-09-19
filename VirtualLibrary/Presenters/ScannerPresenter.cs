using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;

namespace VirtualLibrary.Presenters
{
    class ScannerPresenter
    {
        IBarcodeReader reader = new ZXing.BarcodeReader();

        public Result DecodedBarcode (string imageLocation)
        {
            Bitmap barcodeBitmap = (Bitmap)Image.FromFile(imageLocation);
            return reader.Decode(barcodeBitmap);
        }
    }
}
