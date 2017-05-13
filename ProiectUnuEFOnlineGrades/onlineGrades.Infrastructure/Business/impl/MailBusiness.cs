using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using onlineGrades.Core.Entity;
using MimeKit;
using MailKit.Net.Smtp;

namespace onlineGrades.Infrastructure.Business.impl
{
    public class MailBusiness : IMailBusiness
    {
        public void sendRegisterMail(User user)
        {
            var message = new MimeMessage(); 
            message.From.Add(new MailboxAddress("no-reply@onlineGrades", "register@onlinegrades.com"));
            message.To.Add(new MailboxAddress(user.Nume, user.Email));
            message.Subject = "Register - onlineGrades";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = @"<h3>Buna, "+user.Prenume+@" ! </h3>
                                     <p> Multumim ca te-ai inregistrat, singurul pas ramas este acela de a-ti confirma contul. Tot ce trebuie sa faci este sa apesi pe link-ul de mai jos.</p>
                                     <p>http://localhost:31620/confirm-register/"+user.RegisterUUID+@"</p>
                                     <p>Multumim,</p>
                                     <p>Echipa onlineGrades</p>";
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("mail.smtp2go.com", 2525, false);
                client.Authenticate("register@onlinegrades.com", "eXBiOXUwcjMxeWdr");
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void sendResetMail(User user)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("no-reply@onlineGrades", "register@onlinegrades.com"));
            message.To.Add(new MailboxAddress(user.Nume, user.Email));
            message.Subject = "Reset - onlineGrades";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = @"<h3>Buna, " + user.Prenume + @" ! </h3>
                                     <p>Parola poate fi resetata folosind link-ul de mai jos: </p>
                                     <p>http://localhost:31620/reset-password/" + user.ResetUUID + @"</p>
                                     <p>Multumim,</p>
                                     <p>Echipa onlineGrades</p>";
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("mail.smtp2go.com", 2525, false);
                client.Authenticate("register@onlinegrades.com", "eXBiOXUwcjMxeWdr");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
