using System.Drawing;
using VILIB.DataSources;
using VILIB.View;
using ZXing;

namespace VILIB.Presenters
{
    public class ScannerPresenter
    {
        private readonly IBarcodeReader _reader = new BarcodeReader();

        public string DecodedBarcode(string imageLocation)
        {
            var barcodeBitmap = (Bitmap)Image.FromFile(imageLocation);
            var result = _reader.Decode(barcodeBitmap);
            return result.Text;
            //return _reader.Decode(barcodeBitmap);
        }

        public string DecodeToText(Bitmap image)
        {
            var result = _reader.Decode(image);
            return result.Text;
        }

    }
}