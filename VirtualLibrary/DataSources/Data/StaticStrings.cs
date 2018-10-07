using VirtualLibrary.Localization;

namespace VirtualLibrary.DataSources.Data
{
    public static class StaticStrings
    {
        public static string SubjectEmail = Translations.GetTranslatedString("warning");
        public static string WarningText = Translations.GetTranslatedString("returnThisBook");
        public static string WarningText2 = Translations.GetTranslatedString("until");    
        public static string BookFile = "BookList.txt";
        public static string EmailCredentialsFile = "email-details.txt";
        public static string PictureFilter = "jpg files(*.jpg)|*.jpg| png files(*.png)|*.png";
    }
}