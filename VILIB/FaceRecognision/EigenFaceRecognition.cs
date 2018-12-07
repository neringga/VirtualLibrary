using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using VILIB.FaceRecognision;
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

        private readonly FaceRecognizer _recognizer;
        private List<string> _namesList;
        private List<Image<Gray, byte>> _trainingSet;

        public EigenFaceRecognition(string faceDetectionTrainingFilePath, int faceImagesPerUser)
        {
            _faceImagesPerUser = faceImagesPerUser;

            _recognizer = new EigenFaceRecognizer(ComponentsNumber, Threshold);

            _cascade = new CascadeClassifier(faceDetectionTrainingFilePath);
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
            //File.AppendAllText("D:\\Distance.txt", result.Distance + Environment.NewLine);

            if (result.Distance <= Distance)
                return _namesList.ElementAt(result.Label);
            return null;
        }


        public void Train(FaceImage[] faceImages)
        {
            _trainingSet = new List<Image<Gray, byte>>();
            _namesList = new List<string>();

            AddUser(faceImages);
        }


        public void AddUser(FaceImage[] faceImages)
        {
            foreach (FaceImage image in faceImages)
            {
                _trainingSet.Add(FaceRecognision.ImageConverter.PhotoToGrayFaceImage(image.Bytes));
                _namesList.Add(image.Nickname);
            }

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
    }
}