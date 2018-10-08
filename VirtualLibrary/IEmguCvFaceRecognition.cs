using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.View
{
    interface IEmguCvFaceRecognition
    {
        string Recognize(Image<Bgr, Byte> cameraDisplay);

        void AddUser(List<Image<Gray, byte>> trainingSet, string name);
    }
}
