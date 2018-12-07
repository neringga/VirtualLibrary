using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;

namespace VILIB.FaceRecognision
{
    public static class ReadingLocalImages
    {
        public static List<FaceImage> getFaceImages()
        {
            List<FaceImage> imageList = new List<FaceImage>();
            List<Bitmap> bitmapList = new List<Bitmap>();

            string[] files = Directory.GetFiles(new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UserInformation/")).ToString(), "*.png");

            foreach (string file in files)
            {
                string[] pathElements = file.Split('\\');
                string[] fileNameElements = pathElements[pathElements.Length - 1].Split('_');

                MemoryStream stream = new MemoryStream();
                File.OpenRead(file).CopyTo(stream);

                imageList.Add(new FaceImage { Nickname = fileNameElements[0], Bytes = stream.ToArray() });
            }

            return imageList;
        }
    }
}