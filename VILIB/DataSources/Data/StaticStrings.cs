using VILIB.Localization;

namespace VILIB.DataSources.Data
{
    public static class StaticStrings
    {

        public static string SubjectEmail = Translations.translate("warning");
        public static string WarningText = Translations.translate("returnThisBook");
        public static string WarningText2 = Translations.translate("until");
        public static string RegisteredEmailErr = "This email is already registered";
        public static string RegisteredUsernameErr = "This username is already registered";
        public static string RegisteredSuccessfully = "Registered successfully";
        public static string LoggedIn = "You are logged in";
    }
}