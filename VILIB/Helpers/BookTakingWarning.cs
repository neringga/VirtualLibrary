using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Shared.View;
using VILIB.DataSources.Data;
using VILIB.Model;

namespace VILIB.Helpers
{
    public class BookTakingWarning
    {

        private readonly string _author;
        private readonly EmailCredentials _emailCredentials = new EmailCredentials();
        private readonly DateTime _returnTime;
        private readonly string _title;
        private readonly string _userEmail;

        public BookTakingWarning()
        {
 
        }

        private MailMessage Mail(string user, IBook book)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_emailCredentials.GetUsername()),
                Body = StaticStrings.WarningText +
                       Environment.NewLine + book.Author + " " + book.Title + " " + StaticStrings.WarningText2 + " " +
                       book.HasToBeReturned,
                Subject = StaticStrings.SubjectEmail
            };
            mail.To.Add(user);
            return mail;
        }

        public bool SendWarningEmail(string user, IBook book)
        {
                var smtpServer = new SmtpClient(_emailCredentials.GetServer())
                {
                    Port = 587,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                        _emailCredentials.GetUsername(), _emailCredentials.GetPassword()),
                    EnableSsl = true,
                };
                var mail = Mail(user, book);
                smtpServer.Send(mail);
                return true;
        }

    }
}