using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using VILIB.Helpers;
using VILIB.View;

namespace VILIB
{
    internal class EigenFaceRecognition : IEmguCvFaceRecognition
    {
        private const int Threshold = 3000;
        private const int Distance = 3000;
        private const int ComponentsNumber = 80;

        private readonly CascadeClassifier _cascade;
        private readonly int _faceImagesPerUser;
        private List<string> _namesList;
        private List<Image<Gray, byte>> _trainingSet;

        private readonly FaceRecognizer _recognizer;

        public EigenFaceRecognition(string faceDetectionTrainingFilePath, int faceImagesPerUser)
        {
            _faceImagesPerUser = faceImagesPerUser;

            _recognizer = new EigenFaceRecognizer(ComponentsNumber, Threshold);
        }


        public string Recognize(Image<Bgr, byte> display)
        {
            var faces = _cascade.DetectMultiScale(display.Convert<Gray, byte>(), 1.2, 0);
            Image<Gray, byte> faceImage;

            try
            {
                faceImage = display.Convert<Gray, byte>().Copy(faces[0]).Resize(100, 100, Inter.Cubic);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
                return null;
            }

            var result = _recognizer.Predict(faceImage);

            if (result.Distance <= Distance)
                return _namesList.ElementAt(result.Label / 5);
            return null;
        }


        public void AddUser(List<Image<Gray, byte>> faceImages, string name)
        {
            _namesList.Add(name);
            for (var i = 0; i < _faceImagesPerUser; i++) _trainingSet.Add(faceImages.ElementAt(i));

            Train();
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
    }
}