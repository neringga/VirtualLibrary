using System.Collections.Generic;
using VirtualLibrary.Presenters;
namespace VirtualLibrary.Localization
{
    public static class Translations
    {
        static List<Translation> translations = new List<Translation>()
        {
            new Translation()
            {
            id = "",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = ""
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = ""
                    }
                }
            }

            
        };
        public static string GetTranslatedString(string id)
        {
            string lang = UserPresenter.GetUserLanguage();

            return null;
        }

    }
}
