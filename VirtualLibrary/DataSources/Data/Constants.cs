namespace VirtualLibrary.DataSources.Data
{
    public static class Constants
    {
        public const string SenderEmail = "nergei87@gmail.com";
        public const string SubjectEmail = "Warning to return book";
        public const string WarningText = "You must return the book listed below:";
        public const string WarningText2 = "until";
        public const string SmtpServer = "smtp.gmail.com";
        public const int SmtpPort = 587;
        public const string BookFile = "BookList.txt";
        public const string EmailCredentialsFile = "email-details.txt";
    }
}