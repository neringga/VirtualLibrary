using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Localization;

namespace VirtualLibrary.Forms
{
    public partial class FaceRecognitionLogin : Form
    {
        private readonly VideoCapture _capture;
        private readonly Library _libraryForm;
        private EigenFaceRecognition faceRecognition;

        public FaceRecognitionLogin(Library libraryForm)
        {
            _libraryForm = libraryForm;
            _capture = new VideoCapture();
        }

        public void Init()
        {
            GetImages();
            InitializeComponent();
        }


        public void GetImages()
        {
            List<string> nicknames;
            List<Image<Gray, byte>> trainingSet;
            int[] labels;

            try
            {
                var xml = new UserInformationInXmlFiles(
                    new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + "\\UserInformation\\", 5);
                xml.GetTrainingSet(out trainingSet, out labels, out nicknames);

                faceRecognition = new EigenFaceRecognition(
                    new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName +
                    "\\UserInformation\\haarcascade_frontalface_alt2.xml",
                    trainingSet, nicknames, StaticStrings.FaceImagesPerUser);
            }
            catch (Exception)
            {
                MessageBox.Show(Translations.GetTranslatedString("loginWithPassword"));
                Close();
            }
        }

        private void StartRecognitionTimer_Tick(object sender, EventArgs e)
        {
            var display = _capture.QueryFrame().ToImage<Bgr, byte>();
            var currentNickname = faceRecognition.Recognize(display);

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

        private void FaceRecognitionLogin_Load(object sender, EventArgs e)
        {
        }
    }
}