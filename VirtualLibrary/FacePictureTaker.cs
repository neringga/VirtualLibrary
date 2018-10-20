using System.IO;
using System.Threading;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace VirtualLibrary
{
    class FacePictureTaker
    {
        private readonly int _numberOfPictures;
        private readonly VideoCapture _capture;
        private readonly CascadeClassifier _cascade;

        public FacePictureTaker(int numberOfPictures)
        {
            _numberOfPictures = numberOfPictures;
            _capture = new VideoCapture();
            _cascade = new CascadeClassifier(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName +
                                             "\\UserInformation\\haarcascade_frontalface_alt2.xml");
        }

        public byte[][] TakePictures()
        {
            byte[][] pictures = new byte[_numberOfPictures][];
            Mat img1;
            Image<Bgr, byte> nextFrame;

            for (var i = 0; i < _numberOfPictures; i++)
            {
                img1 = _capture.QueryFrame();
                nextFrame = img1.ToImage<Bgr, byte>();
                {
                    if (nextFrame != null)
                    {
                        var grayframe = nextFrame.Convert<Gray, byte>();

                        var faces = _cascade.DetectMultiScale(grayframe, 1.2, 1);

                        pictures[i] = grayframe.Copy(faces[0]).Resize(100, 100, Inter.Cubic).Bytes;
                    }

                    Thread.Sleep(500);
                }
            }

            _capture.Dispose();
            System.Console.WriteLine("WTF, help");

            return pictures;
        }
    }
}
