using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Localization;
using VirtualLibrary.View;

namespace VirtualLibrary.Forms
{
    public partial class FaceRecognitionLogin : Form
    {
        private VideoCapture _capture;
        private readonly Library _libraryForm;
        private IEmguCvFaceRecognition _faceRecognition;

        public FaceRecognitionLogin(IEmguCvFaceRecognition faceRecognition, Library libraryForm)
        {
            _libraryForm = libraryForm;
            _faceRecognition = faceRecognition;
        }

        public void Init()
        {
            InitializeComponent();
        }


        public void GetImages()
        {
            List<string> nicknames = new List<string>();
            List<Image<Gray, byte>> trainingSet = new List<Image<Gray, byte>>();
            int[] labels;

            try
            {
                var xml = new UserInformationInXmlFiles(
                    new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\UserInformation\\", 5);
                xml.GetTrainingSet(out trainingSet, out labels, out nicknames);
            }
            catch (Exception)
            {
                MessageBox.Show(Translations.GetTranslatedString("loginWithPassword"));
                Close();
            }

            _faceRecognition.Train(trainingSet, nicknames);
        }

        private void StartRecognitionTimer_Tick(object sender, EventArgs e)
        {
            var display = _capture.QueryFrame().ToImage<Bgr, byte>();
            var currentNickname = _faceRecognition.Recognize(display);

            if (currentNickname != null)
            {
                loginButton.Text = Translations.GetTranslatedString("logInButton") + currentNickname;
                nameLabel.Text = currentNickname;
                StaticDataSource.CurrUser = currentNickname;
            }
            else
            {
                nameLabel.Text = Translations.GetTranslatedString("unknown");
            }

            cameraBox.Image = display;
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            _libraryForm.Show();
            _capture.Dispose();
            Dispose();
            Close();
        }

        private void FaceRecognitionLogin_Shown(object sender, EventArgs e)
        {
            GetImages();
            _capture = new VideoCapture();
            startRecognitionTimer.Start();
        }
    }
}