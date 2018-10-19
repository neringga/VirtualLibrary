using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary.View
{
    public interface IEmguCvFaceRecognition
    {
        void Train(UserInformationInXmlFiles xml);

        void Train(List<Image<Gray, byte>> trainingSet, List<string> name);

        string Recognize(Image<Bgr, byte> cameraDisplay);

    }
}