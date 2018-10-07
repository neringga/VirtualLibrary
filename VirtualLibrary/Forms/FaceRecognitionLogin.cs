using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
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

            Image<Bgr, Byte> display = capture.QueryFrame().ToImage<Bgr, Byte>();
            string currentNickname = faceRecognition.Recognize(display);

            if (currentNickname != null)
            {
                loginButton.Text = "Log in as " + currentNickname;
                nameLabel.Text = currentNickname;
                StaticDataSource.currUser = currentNickname;

            }
            else
            {
                nameLabel.Text = "Unknown";
            }
            
            cameraBox.Image = display;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            var library = new Library();
            library.Show();
            capture.Dispose();
            Dispose();
            Close();
        }
    }
}