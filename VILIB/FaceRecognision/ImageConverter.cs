using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace VILIB.FaceRecognision
{
    public static class ImageConverter
    {
        private const int _grayFaceImageSize = 100;
        private const double _cascadePrecision = 1.1;


        public static Image<Bgr, byte> PhotoToBgrImage(byte[] photo)
        {
            Image systemImage;

            using (MemoryStream stream = new MemoryStream(photo))
            {
                systemImage = Image.FromStream(stream);
            }

            Bitmap bitmap = new Bitmap(systemImage);
            return new Image<Bgr, byte>(bitmap);
        }

        //---------------------------------------------------------------
        //  All below are not used and will be changed or deleted
        //---------------------------------------------------------------


        public static Image<Gray, byte> PhotoToGrayFaceImage(byte[] photo)
        {
            Image systemImage;
            Rectangle[] faces;

            using (MemoryStream stream = new MemoryStream(photo))
            {
                systemImage = Image.FromStream(stream);
            }

            Bitmap bitmap = new Bitmap(systemImage);
            Image<Bgr, byte> bgrImage = new Image<Bgr, byte>(bitmap);

            using (CascadeClassifier cascade = new CascadeClassifier(System.Configuration.ConfigurationManager.AppSettings["faceDetectionTrainingFile"]))
            {
                faces = cascade.DetectMultiScale(bgrImage, _cascadePrecision, 0);
            }

            //this should be handled better because of Array of images (exeception ? when how to specify which image is incorrect ?)
            if (faces.Length < 1)
            {
                return null;
            }

            Image<Gray, byte> grayFaceImage = bgrImage.Convert<Gray, byte>().Copy(faces[0]).Resize(_grayFaceImageSize, _grayFaceImageSize, Inter.Cubic);

            return grayFaceImage;
        }


        public static Image<Gray, byte>[] PhotoToGrayFaceImage(byte[][] photos)
        {
            Image<Gray, byte>[] grayFaceImages = new Image<Gray, byte>[photos.Length];
            for (int i = 0; i < photos.Length; i++)
            {
                grayFaceImages[i] = PhotoToGrayFaceImage(photos[i]);
            }
            return grayFaceImages;
        }

        public static byte[] PhotoToGrayFaceBytes(byte[] photo)
        {
            return PhotoToGrayFaceImage(photo).Bytes;
        }


        public static byte[][] PhotoToGrayFaceBytes(byte[][] photos)
        {
            List<byte[]> byteList = new List<byte[]>();
            for (int i = 0; i < photos.Length; i++)
            {
                byteList.Add(PhotoToGrayFaceImage(photos[i]).Bytes);
            }
            return byteList.ToArray();
        }
    }
}