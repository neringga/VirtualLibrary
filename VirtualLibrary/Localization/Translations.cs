using System;
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
            id = "Sign In",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Sign In"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Prisijungti"
                    }
                }
            },
            new Translation()
            {
            id = "Username",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Username"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Vartotojo vardas"
                    }
                }
            }


        };
        public static string GetTranslatedString(string id)
        {
            Console.Out.WriteLine("GET TRANS STRING METODAS");
            string lang = Registration.GetUserLanguageSetting();
            Console.Out.WriteLine("KALBA PO SET : " +lang);
            if (lang == null) lang= "EN";
            string translatedString;
            Translation foundTranslation = translations.Find(Translation => Translation.id == id);
            LanguageValuePair pair = foundTranslation.translatedStrings.Find(LanguageValuePair => LanguageValuePair.language == lang);
            translatedString = pair.value;
            return translatedString;
        }

    }
}
