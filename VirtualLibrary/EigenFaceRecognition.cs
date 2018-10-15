using System;
using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using VirtualLibrary.Helpers;
using VirtualLibrary.View;

namespace VirtualLibrary
{
    internal class EigenFaceRecognition : IEmguCvFaceRecognition
    {
        private const int Threshold = 3000;
        private const int Distance = 3000;
        private const int ComponentsNumber = 80;
        private readonly CascadeClassifier cascade;
        private readonly int faceImagesPerUser;
        private readonly List<string> namesList;

        private readonly FaceRecognizer recognizer;

        private readonly List<Image<Gray, byte>> trainingSet;

        public EigenFaceRecognition(string faceDetectionTrainingFilePath, List<Image<Gray, byte>> trainingSet,
            List<string> namesList, int faceImagesPerUser)
        {
            this.trainingSet = trainingSet;
            this.namesList = namesList;
            this.faceImagesPerUser = faceImagesPerUser;

            recognizer = new EigenFaceRecognizer(ComponentsNumber, Threshold);
            cascade = new CascadeClassifier(faceDetectionTrainingFilePath);

            Train();
        }


        public string Recognize(Image<Bgr, byte> display)
        {
            var faces = cascade.DetectMultiScale(display.Convert<Gray, byte>(), 1.2, 0);
            Image<Gray, byte> faceImage;

            try
            {
                faceImage = display.Convert<Gray, byte>().Copy(faces[0]).Resize(100, 100, Inter.Cubic);
            }
            catch (IndexOutOfRangeException e)
            {
                e.Log();
                return null;
            }

            var result = recognizer.Predict(faceImage);

            if (result.Distance <= Distance)
                return namesList.ElementAt(result.Label / 5);
            return null;
        }


        public void AddUser(List<Image<Gray, byte>> faceImages, string name)
        {
            namesList.Add(name);
            for (var i = 0; i < faceImagesPerUser; i++) trainingSet.Add(faceImages.ElementAt(i));

            Train();
        }


        private void Train()
        {
            var labelsList = new List<int>();
            var label = 0;

            foreach (var grayFaceImage in trainingSet)
            {
                labelsList.Add(label);
                label++;
            }

            recognizer.Train(trainingSet.ToArray(), labelsList.ToArray());
        }
    }
}