using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.DataSources.Data
{
    static class Constants
    {
        public const string senderEmail = "nergei87@gmail.com";
        public const string subjectEmail = "Warning to return book";
        public const string warningText = "You must return the book listed below:";
        public const string warningText2 = "until";
        public const string smtpServer = "smtp.gmail.com";
        public const int smtpPort = 587;
        public const string username = "nergei87@gmail.com";
        public const string password = "Vienas111";
        public const string bookFile = "BookList.txt";
        public const string emailCredentialsFile = "email-details.txt";

        public const int FaceImagesPerUser = 5;
    }
}
