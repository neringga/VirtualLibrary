using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

public class FaceDetection
{
	public FaceDetection()
	{

    }

    public static Image<Bgr, byte> Detect(Image<Bgr, Byte> nextFrame, CascadeClassifier cascade)
    {
        Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
        var faces = cascade.DetectMultiScale(grayframe, 1.2, 3);

        foreach (var face in faces)
        {
            nextFrame.Draw(face, new Bgr(Color.Cyan), 3);
        }
        return nextFrame;
    }
}
