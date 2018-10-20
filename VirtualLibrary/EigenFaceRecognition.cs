using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources;
using VirtualLibrary.Helpers;
using VirtualLibrary.Model;
using VirtualLibrary.View;

namespace VirtualLibrary
{
    internal class EigenFaceRecognition : IEmguCvFaceRecognition
    {
        private const int ImageWidth = 100;
        private const int ImageHeight = 100;
        private const int Threshold = 3000;
        private const int Distance = 3000;
        private const int ComponentsNumber = 80;

        private readonly CascadeClassifier _detector;
        private readonly FaceRecognizer _recognizer;

        private readonly int _faceImagesPerUser;
        private List<string> _namesList;
        private List<Image<Gray, byte>> _trainingSet;

        private IExceptionLogger _exceptionLogger;


        public EigenFaceRecognition(string faceDetectionTrainingFilePath, int faceImagesPerUser, IExceptionLogger exceptionLogger)
        {
            _exceptionLogger = exceptionLogger;
            _faceImagesPerUser = faceImagesPerUser;

            _recognizer = new EigenFaceRecognizer(ComponentsNumber, Threshold);
            _detector = new CascadeClassifier(new DirectoryInfo(Application.StartupPath).Parent.Parent.FullName + faceDetectionTrainingFilePath);
        }


        public string Recognize(Image<Bgr, byte> display)
        {
            var faces = _detector.DetectMultiScale(display.Convert<Gray, byte>(), 1.2, 0);
            Image<Gray, byte> faceImage;

            try
            {
                faceImage = display.Convert<Gray, byte>().Copy(faces[0]).Resize(100, 100, Inter.Cubic);
            }
            catch (IndexOutOfRangeException ex)
            {
                _exceptionLogger.Log(ex);
                return null;
            }

            var result = _recognizer.Predict(faceImage);

            if (result.Distance <= Distance)
                return _namesList.ElementAt(result.Label / 5);
            return null;
        }


        private void Train()
        {
            var labelsList = new List<int>();
            var label = 0;

            foreach (var grayFaceImage in _trainingSet)
            {
                labelsList.Add(label);
                label++;
            }

            _recognizer.Train(_trainingSet.ToArray(), labelsList.ToArray());
        }


        public void Train(List<Image<Gray, byte>> trainingSet, List<string> nameList)
        {
            _trainingSet = trainingSet;
            _namesList = nameList;
            Train();
        }


        public void Train(IExternalDataSource<User> dataSource)
        {
            _namesList = new List<string>();
            _trainingSet = new List<Image<Gray, byte>>();
            List<User> userList = (List<User>) dataSource.GetList();

            foreach(User user in userList)
            {
                _namesList.Add(user.Nickname);
                for (int i = 0; i < _faceImagesPerUser; i++)
                {
                    Image<Gray, byte> image = new Image<Gray, byte>(ImageWidth, ImageHeight);
                    image.Bytes = user.Pictures[i];
                    _trainingSet.Add(image);
                }
            }

            Train();
        }
    }
}