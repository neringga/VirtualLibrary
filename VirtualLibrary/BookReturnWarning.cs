using System;
using System.Net.Mail;

namespace VirtualLibrary
{
    class BookReturnWarning
    {
        public bool SendWarningEmail(string userEmail, DateTime returnTime, string title, string author)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(DataSources.Data.Constants.smtpGmail);

                mail.From = new MailAddress(DataSources.Data.Constants.senderEmail);
                mail.To.Add(userEmail);
                mail.Subject = DataSources.Data.Constants.subjectEmail;
                mail.Body = DataSources.Data.Constants.warningText +
                    Environment.NewLine + author + " " + title + " " + returnTime.ToString();

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(
                    DataSources.Data.Constants.username, DataSources.Data.Constants.password);
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
