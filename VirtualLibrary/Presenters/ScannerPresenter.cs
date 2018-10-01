using System.Drawing;
using VirtualLibrary.DataSources;
using VirtualLibrary.View;
using ZXing;

namespace VirtualLibrary.Presenters
{
    class ScannerPresenter
    {
        IBarcodeReader reader = new BarcodeReader();

        public Result DecodedBarcode (string imageLocation)
        {
            Bitmap barcodeBitmap = (Bitmap)Image.FromFile(imageLocation);
            return reader.Decode(barcodeBitmap);
        }

        public IBook ScannedBook (string barcode)
        {
            LocalDataSource localDataSource = new LocalDataSource();
            var books = localDataSource.GetBookList();
            foreach ( var book in books)
            {
                if (book.Code.Equals(barcode))
                {
                    return book;
                }
            }
            return null;
        }
    }
}
