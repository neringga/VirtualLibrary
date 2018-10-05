using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary.Forms
{
    public partial class FaceRecognitionLogin : Form
    {
        private readonly VideoCapture _capture;
        private readonly CascadeClassifier _cascade;
        private string _currentNickname;

        private List<string> _nicknames;

        private readonly FaceRecognizer _recognizer;
        private FaceRecognizer.PredictionResult _result;

        public FaceRecognitionLogin()
        {
            _capture = new VideoCapture();
            _cascade = new CascadeClassifier(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName +
                                            "\\UserInformation\\haarcascade_frontalface_alt2.xml");

            _recognizer = new EigenFaceRecognizer(80, 3000);
            TrainRecognizer();

            InitializeComponent();
        }

        private void StartRecognitionTimer_Tick(object sender, EventArgs e)
        {
            var display = _capture.QueryFrame().ToImage<Bgr, byte>();
            var faces = _cascade.DetectMultiScale(display.Convert<Gray, byte>(), 1.2, 3);

            foreach (var face in faces)
            {
                var faceImage = display.Convert<Gray, byte>().Copy(faces[0]).Resize(100, 100, Inter.Cubic);

                try
                {
                    _result = _recognizer.Predict(faceImage);

                    if (_result.Distance <= 3000)
                    {
                        display.Draw(face, new Bgr(Color.Green), 3);
                        nameLabel.Text = _nicknames.ElementAt(_result.Label / 5);
                        _currentNickname = _nicknames.ElementAt(_result.Label / 5);
                        loginButton.Text = "Log in as " + _currentNickname;
                        StaticDataSource.CurrUser = _currentNickname;
                    }
                    else
                    {
                        display.Draw(face, new Bgr(Color.Red), 3);
                        nameLabel.Text = "Unknown";
                    }

                    Console.WriteLine(_result.Distance);
                }
                catch (Exception)
                {
                }
            }

            cameraBox.Image = display;
        }


        private void TrainRecognizer()
        {
            var xml = new UserInformationInXmlFiles(
                new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\UserInformation\\", 5);

            List<Image<Gray, byte>> images;
            int[] labels;

            xml.GetTrainingSet(out images, out labels, out _nicknames);

            _recognizer.Train(images.ToArray(), labels);
        }

        private void FaceRecognitionLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            _capture.Dispose();
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            var library = new Library();
            library.Show();
            Dispose();
        }
    }
}