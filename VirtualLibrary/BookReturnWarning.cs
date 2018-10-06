using System;
using System.Net;
using System.Net.Mail;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary
{
    internal class BookReturnWarning
    {
        private readonly string _author;
        private readonly DateTime _returnTime;
        private readonly string _title;
        private readonly string _userEmail;
        private readonly EmailCredentials _emailCredentials = new EmailCredentials();

        public BookReturnWarning(string userEmail, DateTime returnTime, string title, string author)
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
                Body = Constants.WarningText +
                       Environment.NewLine + _author + " " + _title + " " + Constants.WarningText2 + " " +
                       _returnTime,
                Subject = Constants.SubjectEmail
            };
            mail.To.Add(_userEmail);
            return mail;
        }

        public void SendWarningEmail()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}