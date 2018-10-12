using VirtualLibrary.Localization;

namespace VirtualLibrary.DataSources.Data
{
    public static class StaticStrings
    {
        public const string ExceptionsLogFile = "RuntimeExceptions.txt";
        public static string SubjectEmail = Translations.GetTranslatedString("warning");
        public static string WarningText = Translations.GetTranslatedString("returnThisBook");
        public static string WarningText2 = Translations.GetTranslatedString("until");
        public static string BookFile = "BookList.txt";
        public static string UserFile = "faceImages.xml";
        public static string EmailCredentialsFile = "email-details.txt";
        public static string PictureFilter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png";
        public static int FaceImagesPerUser = 5;
    }
}