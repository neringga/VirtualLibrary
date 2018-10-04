using System;
using System.Net.Mail;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary
{
    class BookReturnWarning
    {
        public bool SendWarningEmail(string userEmail, DateTime returnTime, string title, string author)
        {
            try
            {
                EmailCredentials emailCredentials = new EmailCredentials();
                SmtpClient SmtpServer = new SmtpClient(Constants.smtpServer);
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(Constants.senderEmail),
                    Body = Constants.warningText +
                    Environment.NewLine + author + " " + title + " " + Constants.warningText2 + " " +
                    returnTime.ToString(),
                    Subject = Constants.subjectEmail,
                };
                mail.To.Add(userEmail);


                SmtpServer.Port = Constants.smtpPort;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(
                    emailCredentials.GetUsername(), emailCredentials.GetPassword());
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
