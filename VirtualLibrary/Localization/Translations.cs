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
            id = "pictureUploadButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Upload"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Įkelti"
                    }
                }
            },
            new Translation()
            {
            id = "label1",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Upload picture of barcode"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Įkelti barkodo nuotrauką"
                    }
                }
            },
            new Translation()
            {
            id = "scannedBookInfo",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Scanned Book Info"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Nuskanuotos knygos informacija"
                    }
                }
            },
            new Translation()
            {
            id = "takeBookButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Take this book"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Paimti šią knygą"
                    }
                }
            },
            new Translation()
            {
            id = "returnBookButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Return this book"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Grąžinti šią knygą"
                    }
                }
            },
            new Translation()
            {
            id = "infoText",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Scanned book:"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Nuskanuota knyga:"
                    }
                }
            },
            new Translation()
            {
            id = "button1Text",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Back"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Atgal"
                    }
                }
            },
            new Translation()
            {
            id = "barcodeScanner",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Barcode scanner"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Barkodo skanuotojas"
                    }
                }
            },
            new Translation()
            {
            id = "signIn",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Sign in"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Prisiregistruoti"
                    }
                }
            },
            new Translation()
            {
            id = "nameBox",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Name: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Vardas: "
                    }
                }
            },
            new Translation()
            {
            id = "loading",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Loading..."
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Kraunasi..."
                    }
                }
            },
            new Translation()
            {
            id = "logInButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Login as: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Prisijungti kaip: "
                    }
                }
            },
            new Translation()
            {
            id = "faceRecognisionLogin",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Face recognision login"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Prisijungimas su veido atpažinimu"
                    }
                }
            },
            new Translation()
            {
            id = "scannerOpenButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Scan book"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Nuskanuoti knygą"
                    }
                }
            },
            new Translation()
            {
            id = "listOfBooks",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Books that have to be returned: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Knygas, kurias reikia grąžinti: "
                    }
                }
            },
            new Translation()
            {
            id = "forBooks",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "For taking or returning book: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Knygos paėmimui arba grąžinimui: "
                    }
                }
            },
            new Translation()
            {
            id = "library",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Library"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Bilioteka"
                    }
                }
            },
            new Translation()
            {
            id = "continueButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Continue"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Tęsti"
                    }
                }
            },
            new Translation()
            {
            id = "login",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Login"
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
            id = "username",
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
                         value = "Prisijungimo vardas"
                    }
                }
            },
            new Translation()
            {
            id = "password",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Password"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Slaptažodis"
                    }
                }
            },
            new Translation()
            {
            id = "noAccount",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Don\'t have an account?"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Neturite paskyros?"
                    }
                }
            },
            new Translation()
            {
            id = "welcome",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Welcome to the Virtual Library"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Jus sveikina Virtualioji Biblioteka"
                    }
                }
            },
            new Translation()
            {
            id = "registerButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Register"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Prisiregistruoti"
                    }
                }
            },
            new Translation()
            {
            id = "projectName",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Virtual Library"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Virtualioji Biblioteka"
                    }
                }
            },
            new Translation()
            {
            id = "nameLabel",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Name: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Vardas: "
                    }
                }
            },
            new Translation()
            {
            id = "surnameLabel",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Surname: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Pavardė: "
                    }
                }
            },
            new Translation()
            {
            id = "emailLabel",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Email: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Elektroninis paštas: "
                    }
                }
            },
            new Translation()
            {
            id = "birthLabel",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Date of birth: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Gimimo data: "
                    }
                }
            },
            new Translation()
            {
            id = "takePhoto",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Take a picture"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Nusifotografuoti"
                    }
                }
            },
            new Translation()
            {
            id = "newUser",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "New user registration"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Naujo naudotojo registracija"
                    }
                }
            },
            new Translation()
            {
            id = "repeatPassword",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Repeat password: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Pakartoti slaptažodį: "
                    }
                }
            },
            new Translation()
            {
            id = "chooseLanguage",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Choose a language: "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Pasirinkite kalbą: "
                    }
                }
            },
            new Translation()
            {
            id = "registrationButton",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Registration"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Registracija"
                    }
                }
            },
            new Translation()
            {
            id = "userNotFound",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "User not found. Please register before trying to log in."
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Vartotojas nerastas. Prašome prisiregistruoti prieš bandant prisijungti."
                    }
                }
            },
            new Translation()
            {
            id = "empty",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Can't be empty."
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Negali būti tuščias."
                    }
                }
            },
            new Translation()
            {
            id = "lookAtCamera",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Look to the camera for 3 seconds"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Pažiūrėkite į kamerą 3 sekundes"
                    }
                }
            },
            new Translation()
            {
            id = "attention",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Attention"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Dėmesio"
                    }
                }
            },
            new Translation()
            {
            id = "shortPassword",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Password needs to be longer than 6 letters"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Slaptažodis turi būti ilgesnis nei 6 raidės"
                    }
                }
            },
            new Translation()
            {
            id = "doNotMatch",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Passwords do not match"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Slaptažodžiai nesutampa"
                    }
                }
            },
            new Translation()
            {
            id = "usernameExists",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "This username already exist"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Šis prisijungimo vardas jau egzistuoja."
                    }
                }
            },
            new Translation()
            {
            id = "incorrectFormat",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Incorrect format"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Netinkamas formatas"
                    }
                }
            },
            new Translation()
            {
            id = "default",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Default"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Numatytasis"
                    }
                }
            },
            new Translation()
            {
            id = "unknown",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Unknown"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Nežinoma"
                    }
                }
            },
            new Translation()
            {
            id = "form2",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Form 2"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Antra forma"
                    }
                }
            },
            new Translation()
            {
            id = "warning",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Warning to return book"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Įspėjimas grąžinti knygą"
                    }
                }
            },
            new Translation()
            {
            id = "returnThisBook",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "You must return the book listed below:"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Jūs turite grąžinti šią knygą:"
                    }
                }
            },
            new Translation()
            {
            id = "until",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "until"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "iki"
                    }
                }
            },
            new Translation()
            {
            id = "tryAgain",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Try again"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Bandykite dar kartą"
                    }
                }
            },
            new Translation()
            {
            id = "error",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Error"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Įvyko klaida"
                    }
                }
            },
            new Translation()
            {
            id = "returnUntil",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "You have to return this book on "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Turite grąžinti šią knygą iki "
                    }
                }
            },
            new Translation()
            {
            id = "cannotTake",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "You can not take this book"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Negalite paimti šios knygos"
                    }
                }
            },
            new Translation()
            {
            id = "addPicture",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Please add picture of the barcode"
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Prašome pridėti barkodo nuotrauką"
                    }
                }
            },
            new Translation()
            {
            id = "returnSucessfully",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Book returned successfully."
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Knyga grąžinta sėkmingai."
                    }
                }
            },
            new Translation()
            {
            id = "cannotReturn",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "You can not return this book."
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Negalite grąžinti šios knygos"
                    }
                }
            },
            new Translation()
            {
            id = "returnOn",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = " return on "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = " grąžinti "
                    }
                }
            },
            new Translation()
            {
            id = "notDetected",
            translatedStrings = new List<LanguageValuePair>()
                {
                    new LanguageValuePair()
                    {
                        language = "EN",
                        value = "Face was not detected. Please try again. "
                    },
                    new LanguageValuePair()
                    {
                         language = "LT",
                         value = "Veidas neaptiktas. Prašome mėginti dar kartą"
                    }
                }
            },
        };

        public static string GetTranslatedString (string id)
        {
            string lang = Registration.GetUserLanguageSetting();
            if (lang == null)
                lang = "EN";
            string translatedString;
            Translation foundTranslation = translations.Find(Translation => Translation.id == id);
            LanguageValuePair pair = foundTranslation.translatedStrings.Find(LanguageValuePair => LanguageValuePair.language == lang);
            translatedString = pair.value;
            return translatedString;
        }  
    }
}
