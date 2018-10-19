using System;
using System.Net;
using System.Net.Mail;
using VILIB.DataSources.Data;

namespace VILIB
{
    internal class BookReturnEmail
    {
        private readonly string _author;
        private readonly EmailCredentials _emailCredentials = new EmailCredentials();
        private readonly DateTime _returnTime;
        private readonly string _title;
        private readonly string _userEmail;

        public BookReturnEmail(string userEmail, DateTime returnTime, string title, string author)
        {
            _userEmail = userEmail;
            _title = title;
            _returnTime = returnTime;
            _author = author;
        }

        private MailMessage Mail()
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_emailCredentials.GetUsername()),
                Body = StaticStrings.WarningText +
                       Environment.NewLine + _author + " " + _title + " " + StaticStrings.WarningText2 + " " +
                       _returnTime,
                Subject = StaticStrings.SubjectEmail
            };
            mail.To.Add(_userEmail);
            return mail;
        }

        public void SendWarningEmail()
        {
            var smtpServer = new SmtpClient(_emailCredentials.GetServer())
            {
                Port = _emailCredentials.GetPort(),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    _emailCredentials.GetUsername(), _emailCredentials.GetPassword()),
                EnableSsl = true
            };
            smtpServer.Send(Mail());
        }
    }
}