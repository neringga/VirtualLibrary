using System;
using System.Collections.Generic;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Forms;

namespace VirtualLibrary.Localization
{
    public static class Translations
    {
        private static readonly Dictionary<string, Dictionary<string, string>> newTranslations = new Dictionary<string, Dictionary<string, string>>()
        {
            { "LT", new Dictionary<string, string>(){
                {"pictureUploadButton", "Įkelti"},
                { "label1","Įkelti barkodo nuotrauką" },
                { "empty", "Negali būti tuščias"},
                { "scannedBookInfo", "Nuskanuotos knygos informacija"},
                { "takeBookButton", "Paimti šią knygą"},
                { "returnBookButton", "Grąžinti šią knygą"},
                { "infoText", "Nuskanuota knyga:"},
                { "button1Text", "Atgal" },
                { "barcodeScanner", "Barkodo skanuotojas"},
                { "signIn", "Prisijungti"},
                { "nameBox", "Vardas: "},
                { "loading", "Kraunasi..."},
                { "logInButton", "Prisijungti kaip:"},
                { "faceRecognisionLogin", "Prisijungti naudojant veido atpažinimą"},
                { "scannerOpenButton", "Nuskanuoti knygą"},
                { "listOfBooks", "Knygos, kurias reikia grąžinti: "},
                { "forBooks", "Knygos paėmimui arba grąžinimui: "},
                { "library", "Biblioteka"},
                { "continueButton", "Tęsti"},
                { "login", "Prisijungti"},
                {  "username", "Prisijungimo vardas"},
                { "password", "Slaptažodis"},
                { "noAccount", "Neturite paskyros?"},
                { "welcome", "Jus sveikina Virtualioji Biblioteka"},
                { "registerButton", "Užsiregistruoti"},
                { "nameLabel", "Vardas: "},
                { "projectName", "Virtualioji biblioteka"},
                { "surnameLabel", "Pavardė: "},
                { "emailLabel", "Elektroninis paštas: "},
                { "birthLabel", "Gimimo data: "},
                { "takePhoto", "Padaryti nuotrauką"},
                { "newUser", "Naujo vartotojo registracija"},
                { "repeatPassword", "Pakartokite slaptažodį"},
                { "chooseLanguage", "Pasirinkite kalbą:"},
                { "registrationButton", "Registracija"},
                { "userNotFound", "Vartotojas nerastas. Prašome prisiregistruoti prieš bandant prisijungti."},
                { "lookAtCamera", "Žiūrėkite į kamerą 3 sekundes"},
                { "attention", "Dėmesio"},
                { "shortPassword", "Slaptažodis turi būti ilgesnis nei 6 raidės"},
                { "doNotMatch", "Slaptažodžiai nesutampa"},
                { "usernameExists", "Toks prisijungimo vardas jau egzistuoja"},
                { "incorrectFormat", "Neteisingas formatas"},
                { "default", "Numatytasis"},
                { "unknown", "Nežinomas"},
                { "warning", "Įspėjimas grąžinti knygą"},
                { "returnThisBook","Turite grąžinti šią knygą:"},
                { "until", "Iki "},
                { "tryAgain", "Bandykite dar kartą"},
                { "error", "Įvyko klaida"},
                { "returnUntil", "Turite grąžinti šią knygą iki "},
                { "cannotTake", "Jūs negalite paimti šios knygos"},
                { "addPicture", "Prašome pridėti barkodo nuotrauką"},
                { "returnSucessfully", "Knyga grąžinta sėkmingai"},
                { "cannotReturn", "Negalite grąžinti šios knygos"},
                { "returnOn", " grąžinti iki "},
                { "notDetected", "Veidas neaptiktas. Prašome bandyti dar kartą"},
                { "loginWithPassword", "PRašome prisijungti su prisijungimo vardu ir slaptažodžiu"},
                { "signInWithCamera", "Prisijungti su kamera"},
            }
            },
            {"EN", new Dictionary<string, string>()
            {
                { "pictureUploadButton", "Upload" },
                { "label1", "Upload picture of barcode" },
                { "empty", "Can't be empty" },
                { "scannedBookInfo", "Scanned book info"},
                { "takeBookButton", "Take this book"},
                { "returnBookButton", "Return this book"},
                { "infoText", "Scanned book: "},
                { "button1Text", "Back"},
                { "barcodeScanner", "Barcode scanner"},
                { "signIn", "Sign in" },
                { "nameBox", "Name: "},
                { "loading", "Loading..."},
                { "logInButton", "Login as: "},
                { "faceRecognisionLogin", "Login with face recognision"},
                { "scannerOpenButton", "Scan book"},
                { "listOfBooks",  "Books that have to be returned: "},
                { "forBooks", "For taking or returning book: "},
                { "library", "Library"},
                { "continueButton", "Continue"},
                { "login", "Login"},
                { "username", "Username"},
                { "password", "Password"},
                { "noAccount", "Don't have an account?"},
                { "welcome", "Welcome to the Virtual Library"},
                { "registerButton", "Register"},
                { "nameLabel", "Name: "},
                { "projectName", "Virtual Library"},
                { "surnameLabel", "Surname: "},
                { "emailLabel", "Email: "},
                { "birthLabel", "Date of birth: "},
                { "takePhoto", "Take a picture"},
                { "newUser", "New user registration"},
                { "repeatPassword", "Repeat password"},
                { "chooseLanguage", "Choose a language"},
                { "registrationButton", "Registration"},
                { "userNotFound", "User not found. Please register before trying to log in."},
                { "lookAtCamera", "Look at camera for 3 seconds"},
                { "attention", "Attention"},
                { "shortPassword", "Password must be longer than 6 letters"},
                { "doNotMatch", "Passwords do not match"},
                { "usernameExists", "This username already exists"},
                { "incorrectFormat", "Incorrect format"},
                { "default", "Default"},
                { "unknown", "Unknown"},
                { "warning", "Warning to return book"},
                { "returnThisBook","You must return the book listed below:"},
                { "until", "Until "},
                { "tryAgain", "Try again"},
                { "error", "Error"},
                { "returnUntil", "You have to return this book on " },
                { "cannotTake", "You can not take this book"},
                { "addPicture", "Please add picture of the barcode"},
                { "returnSucessfully", "Book returned sucessfully"},
                { "cannotReturn", "You can not return this book"},
                { "returnOn", " return on "},
                { "notDetected", "Face was not detected. Please try again"},
                { "loginWithPassword", "Please login with your username and password"},
                { "signInWithCamera", "Login with camera"},
            }
            }
        };

        public static string GetTranslatedString(string id)
        {
           // var lang = StaticDataSource.CurrLanguage;
            if (StaticDataSource.CurrLanguage == null)
                StaticDataSource.CurrLanguage = "EN";

            Dictionary<string, string> tempDictionary = newTranslations[StaticDataSource.CurrLanguage];
            if (tempDictionary.ContainsKey(id) == true)
            {
                return tempDictionary[id];
            }
            return "Bad string";
        }
    }
}