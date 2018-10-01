using System;
using System.IO;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

namespace VirtualLibrary
{
    public partial class LiveCamera : Form
    {
        private VideoCapture capture;
        private CascadeClassifier cascade;

        public Image<Gray, byte>[] grayPictures;
        public byte[][] pictures;

        public LiveCamera()
        {
            cascade = new CascadeClassifier(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\UserInformation\\haarcascade_frontalface_alt2.xml");

            grayPictures = new Image<Gray, byte>[5];
            pictures = new byte[5][];

            InitializeComponent();
        }

        


        private void StartTakingPictures(object sender, EventArgs e)
        {
            Mat img1;
            Image<Bgr, Byte> nextFrame;

            capture = new VideoCapture();

            for (int i = 0; i < 5; i++)
            {
                img1 = capture.QueryFrame();
                nextFrame = img1.ToImage<Bgr, Byte>();
                {
                    if (nextFrame != null)
                    {
                        imageBox1.Image = nextFrame;

                        Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                        var faces = cascade.DetectMultiScale(grayframe, 1.2, 1);

                        if (faces[0] != null)
                        {
                            grayPictures[i] = grayframe.Copy(faces[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        }
                        else
                        {
                            MessageBox.Show("Face was not detected. Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    System.Threading.Thread.Sleep(500);
                }
            }

            capture.Dispose();

            imageBox1.Image = grayPictures[0];
            imageBox2.Image = grayPictures[1];
            imageBox3.Image = grayPictures[2];
            imageBox4.Image = grayPictures[3];
            imageBox5.Image = grayPictures[4];
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                pictures[i] = grayPictures[i].Bytes;
            }

            Close();
        }
    }
}
