using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace VirtualLibrary.View
{
    interface IEmguCvFaceRecognition
    {
        string Recognize(Image<Bgr, byte> cameraDisplay);

        void AddUser(List<Image<Gray, byte>> trainingSet, string name);
    }
}