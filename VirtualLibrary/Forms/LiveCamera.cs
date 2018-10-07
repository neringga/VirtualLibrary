using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace VirtualLibrary
{
    public partial class LiveCamera : Form
    {
        private VideoCapture _capture;
        private readonly CascadeClassifier _cascade;

        public Image<Gray, byte>[] GrayPictures;
        public byte[][] Pictures;

        public LiveCamera()
        {
            _cascade = new CascadeClassifier(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName +
                                            "\\UserInformation\\haarcascade_frontalface_alt2.xml");

            GrayPictures = new Image<Gray, byte>[5];
            Pictures = new byte[5][];

            InitializeComponent();
        }


        private void StartTakingPictures(object sender, EventArgs e)
        {
            Mat img1;
            Image<Bgr, byte> nextFrame;

            _capture = new VideoCapture();

            for (var i = 0; i < 5; i++)
            {
                img1 = _capture.QueryFrame();
                nextFrame = img1.ToImage<Bgr, byte>();
                {
                    if (nextFrame != null)
                    {
                        imageBox1.Image = nextFrame;

                        var grayframe = nextFrame.Convert<Gray, byte>();
                        var faces = _cascade.DetectMultiScale(grayframe, 1.2, 1);

                        if (faces[0] != null)
                            GrayPictures[i] = grayframe.Copy(faces[0]).Resize(100, 100, Inter.Cubic);
                        else
                            MessageBox.Show("Face was not detected. Try again", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }

                    Thread.Sleep(500);
                }
            }

            _capture.Dispose();

            imageBox1.Image = GrayPictures[0];
            imageBox2.Image = GrayPictures[1];
            imageBox3.Image = GrayPictures[2];
            imageBox4.Image = GrayPictures[3];
            imageBox5.Image = GrayPictures[4];
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 5; i++) Pictures[i] = GrayPictures[i].Bytes;

            Close();
        }
    }
}