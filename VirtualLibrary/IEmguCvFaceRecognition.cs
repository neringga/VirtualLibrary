using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace VirtualLibrary.View
{
    public interface IEmguCvFaceRecognition
    {
        void Train(List<Image<Gray, byte>> trainingSet, List<string> name);

        string Recognize(Image<Bgr, byte> cameraDisplay);

        void AddUser(List<Image<Gray, byte>> trainingSet, string name);
    }
}