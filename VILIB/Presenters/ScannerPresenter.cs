using System.Drawing;
using VILIB.DataSources;
using VILIB.View;
using ZXing;

namespace VILIB.Presenters
{
    internal class ScannerPresenter
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
            if (books != null)
            {
                foreach (var book in books)
                {
                    if (book.Code.Equals(barcode))
                        return book;
                }
            }
            return null;
        }
    }
}