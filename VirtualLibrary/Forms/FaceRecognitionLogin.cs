using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary.Forms
{
    public partial class FaceRecognitionLogin : Form
    {
        VideoCapture capture;
        CascadeClassifier cascade;

        FaceRecognizer recognizer;
        FaceRecognizer.PredictionResult result;

        List<string> nicknames;
        string currentNickname;

        public FaceRecognitionLogin()
        {
            capture = new VideoCapture();
            cascade = new CascadeClassifier(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\UserInformation\\haarcascade_frontalface_alt2.xml");

            recognizer = new EigenFaceRecognizer(80, 3000);
            TrainRecognizer();

            InitializeComponent();
        }

        private void StartRecognitionTimer_Tick(object sender, EventArgs e)
        {
            Image<Bgr, Byte> display = capture.QueryFrame().ToImage<Bgr, Byte>();
            Rectangle[] faces = cascade.DetectMultiScale(display.Convert<Gray, Byte>(), 1.2, 3);

            foreach (Rectangle face in faces)
            {
                Image<Gray, Byte> faceImage = display.Convert<Gray, Byte>().Copy(faces[0]).Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);

                try
                {
                    result = recognizer.Predict(faceImage);

                    if (result.Distance <= 3000)
                    {
                        display.Draw(face, new Bgr(Color.Green), 3);
                        nameLabel.Text = nicknames.ElementAt(result.Label/5);
                        currentNickname = nicknames.ElementAt(result.Label / 5);
                        loginButton.Text = "Log in as "+ currentNickname;
                        StaticDataSource.currUser = currentNickname;
                    }
                    else
                    {
                        display.Draw(face, new Bgr(Color.Red), 3);
                        nameLabel.Text = "Unknown";
                    }

                    Console.WriteLine(result.Distance);
                }
                catch (Exception)
                {

                }


            }

            cameraBox.Image = display;
        }


        private void TrainRecognizer()
        {
            UserInformationInXMLFiles xml = new UserInformationInXMLFiles(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName  + "\\UserInformation\\", 5);

            List<Image<Gray, byte>> images;
            int[] labels;

            xml.GetTrainingSet(out images, out labels, out nicknames);

            recognizer.Train(images.ToArray(), labels);
        }

        private void FaceRecognitionLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            capture.Dispose();
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            Library library = new Library();
            library.Show();
            Dispose();
        }
    }
}
