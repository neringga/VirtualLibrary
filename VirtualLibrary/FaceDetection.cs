using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace VirtualLibrary
{
    public class FaceDetection
    {
        public static Image<Bgr, byte> Detect(Image<Bgr, byte> nextFrame, CascadeClassifier cascade)
        {
            var grayFrame = nextFrame.Convert<Gray, byte>();
            var faces = cascade.DetectMultiScale(grayFrame, 1.2, 3);

            foreach (var face in faces) nextFrame.Draw(face, new Bgr(Color.Cyan), 3);
            return nextFrame;
        }
    }
}