using System;
using System.Net.Mail;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary
{
    class BookReturnWarning
    {
        EmailCredentials emailCredentials = new EmailCredentials();
        private string _userEmail;
        private string _title;
        private string _author;
        private DateTime _returnTime;

        public BookReturnWarning(string userEmail, DateTime returnTime, string title, string author)
        {
            _userEmail = userEmail;
            _title = title;
            _returnTime = returnTime;
            _author = author;
        }

        private MailMessage Mail()
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress(Constants.senderEmail),
                Body = Constants.warningText +
                       Environment.NewLine + _author + " " + _title + " " + Constants.warningText2 + " " +
                       _returnTime.ToString(),
                Subject = emailCredentials.GetUsername()
            };
            mail.To.Add(_userEmail);
            return mail;
        }

        public bool SendWarningEmail()
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient(Constants.smtpServer);
                SmtpServer.Port = emailCredentials.GetPort();
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(
                    emailCredentials.GetUsername(), emailCredentials.GetPassword());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Mail());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
