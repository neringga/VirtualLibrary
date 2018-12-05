using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace VILIB.FaceRecognision
{
    public static class ImageConverter
    {
        public static Image<Bgr, byte> PhotoToBgrImage(byte[] photo)
        {
            Image systemImage;

            using (var stream = new MemoryStream(photo))
            {
                systemImage = Image.FromStream(stream);
            }

            var bitmap = new Bitmap(systemImage);
            return new Image<Bgr, byte>(bitmap);
        }
        

        public static Image<Gray, byte> PhotoToGrayFaceImage(byte[] photo)
        {
            Image systemImage;

            using (var stream = new MemoryStream(photo))
            {
                systemImage = Image.FromStream(stream);
            }

            var bitmap = new Bitmap(systemImage);
            var grayFaceImage = new Image<Gray, byte>(bitmap);

            return grayFaceImage;
        }


        public static List<Image<Gray, byte>> PhotoToGrayFaceImage(byte[][] photos)
        {
            List<Image<Gray, byte>> grayFaceImages = new List<Image<Gray, byte>>();
            for (var i = 0; i < photos.Length; i++)
                grayFaceImages.Add(PhotoToGrayFaceImage(photos[i]));
            return grayFaceImages;
        }
    }
}