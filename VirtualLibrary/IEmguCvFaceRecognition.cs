using System.Collections.Generic;

using Emgu.CV;
using Emgu.CV.Structure;

using VirtualLibrary.DataSources;
using VirtualLibrary.Model;

namespace VirtualLibrary.View
{
    public interface IEmguCvFaceRecognition
    {
        void Train(IExternalDataSource<User> dataSource);

        void Train(List<Image<Gray, byte>> trainingSet, List<string> name);

        string Recognize(Image<Bgr, byte> cameraDisplay);

    }
}