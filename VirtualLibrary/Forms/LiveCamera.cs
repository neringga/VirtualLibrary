using System;
using System.IO;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

using VirtualLibrary.DataSources.Data;

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

            grayPictures = new Image<Gray, byte>[Constants.FaceImagesPerUser];
            pictures = new byte[Constants.FaceImagesPerUser][];

            InitializeComponent();
        }



        private void StartTakingPictures(object sender, EventArgs e)
        {
            MessageBox.Show("Look to the camera for 3 seconds", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Mat img1;
            Image<Bgr, Byte> nextFrame;

            capture = new VideoCapture();

            for (int i = 0; i < Constants.FaceImagesPerUser; i++)
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

                //change imageBox variables to array
                switch (i)
                {
                    case 0:
                        imageBox1.Image = grayPictures[i];
                        break;
                    case 1:
                        imageBox2.Image = grayPictures[i];
                        break;
                    case 2:
                        imageBox3.Image = grayPictures[i];
                        break;
                    case 3:
                        imageBox4.Image = grayPictures[i];
                        break;
                    case 4:
                        imageBox5.Image = grayPictures[i];
                        break;
                }
                
                    
            }

            capture.Dispose();
            
        }

        


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Constants.FaceImagesPerUser; i++)
            {
                pictures[i] = grayPictures[i].Bytes;
            }

            Close();
        }

        private void LiveCamera_Load(object sender, EventArgs e)
        {

        }
    }
}
