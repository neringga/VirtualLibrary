using Shared.Views;

namespace VILIB.FaceRecognision
{
    public class FaceImage : IFaceImage
    {
        public string Nickname { get; set; }
        public byte[] Bytes { get; set; }
    }
}