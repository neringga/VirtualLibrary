using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.VideoStab;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace VirtualLibrary
{
    public partial class LiveCamera : Form
    {
        private VideoCapture capture;
        private CascadeClassifier cascade;

        public LiveCamera()
        {
            capture = new VideoCapture();
            cascade = new CascadeClassifier("haarcascade_frontalface_alt2.xml");


            InitializeComponent();
        }



        private void StopCamera(object sender, EventArgs e)
        {
            Mat img1 = capture.QueryFrame();
            Image<Bgr, Byte> nextFrame = img1.ToImage<Bgr, Byte>();
            {
                if (nextFrame != null)
                {
                    imageBox1.Image = FaceDetection.Detect(nextFrame, cascade);
                }
            }
            timer1.Stop();
        }

        private void StartCamera(object sender, EventArgs e)
        {
            Mat img1 = capture.QueryFrame();
            Image<Bgr, Byte> nextFrame = img1.ToImage<Bgr, Byte>();
            {
                if (nextFrame != null)
                {
                    imageBox1.Image = FaceDetection.Detect(nextFrame, cascade);
                    MessageBox.Show(imageBox1.Image.ToString());
                }
            }
        }
    }
}
