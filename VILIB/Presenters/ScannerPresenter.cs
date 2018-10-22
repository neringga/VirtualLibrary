using System.Drawing;
using VILIB.DataSources;
using VILIB.View;
using ZXing;

namespace VILIB.Presenters
{
    public class ScannerPresenter
    {
        private readonly IBarcodeReader _reader = new BarcodeReader();

        public Result DecodedBarcode(string imageLocation)
        {
            var barcodeBitmap = (Bitmap) Image.FromFile(imageLocation);
            return _reader.Decode(barcodeBitmap);
        }

    }
}