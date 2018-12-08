using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using VILIB.FaceRecognision;

namespace VILIB.View
{
    public interface IEmguCvFaceRecognition
    {
        void Train(FaceImage[] faceImages);

        string Recognize(Image<Bgr, byte> cameraDisplay);
    }
}