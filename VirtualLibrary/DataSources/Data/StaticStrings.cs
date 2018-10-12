using VirtualLibrary.Localization;

namespace VirtualLibrary.DataSources.Data
{
    public static class StaticStrings
    {
        public const string ExceptionsLogFile = "RuntimeExceptions.txt";
        public const string BookFile = "BookList.txt";
        public const string UserFile = "faceImages.xml";
        public const string EmailCredentialsFile = "email-details.txt";
        public const string PictureFilter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png";
        public const int FaceImagesPerUser = 5;
        public static string SubjectEmail = Translations.GetTranslatedString("warning");
        public static string WarningText = Translations.GetTranslatedString("returnThisBook");
        public static string WarningText2 = Translations.GetTranslatedString("until");
    }
}