using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Localization;

namespace VirtualLibrary
{
    public partial class LiveCamera : Form
    {
        public byte[][] Pictures;

        public LiveCamera()
        {
            Pictures = new byte[StaticStrings.FaceImagesPerUser][];

            InitializeComponent();
        }

        private void StartTakingPictures(object sender, EventArgs e)
        {
            FacePictureTaker taker = new FacePictureTaker(StaticStrings.FaceImagesPerUser);
            Pictures = taker.TakePictures();
            continueButton.Enabled = true;
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}