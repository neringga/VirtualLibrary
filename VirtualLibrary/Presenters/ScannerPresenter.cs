using System.Drawing;
using System.Linq;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;
using ZXing;

namespace VirtualLibrary.Presenters
{
    public class ScannerPresenter
    {
        private readonly IBarcodeReader _reader = new BarcodeReader();

        public Result DecodedBarcode(string imageLocation)
        {
            var barcodeBitmap = (Bitmap) Image.FromFile(imageLocation);
            return _reader.Decode(barcodeBitmap);
        }

        public IBook ScannedBook(string barcode)
        {
            var localDataSource = new LocalDataSource();
            var books = localDataSource.GetBookList();
            return books.FirstOrDefault(book => book.Code.Equals(barcode));
        }
    }
}