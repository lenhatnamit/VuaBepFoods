using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace VuaBepFoodsWeb.Lib
{
    public static class SendMailSMTP
    {
        public static void SendMail()
        {
            SmtpClient smtpClient = new SmtpClient("sv48d44.emailserver.vn");

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("info@h2aits.com", "h2aitS@123");
            //smtpClient.Credentials = new System.Net.NetworkCredential("lenhatnamit07@gmail.com", "bzlrxhtcqumqtwef");
            // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Port = 587;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("info@h2ait.com", "H2A IT SOLUTION");
            mail.To.Add(new MailAddress("pronam13@gmail.com"));
            //mail.CC.Add(new MailAddress("nhanit2012.vn@gmail.com"));
            mail.IsBodyHtml = true;
            mail.Subject = "Email Sent";
            mail.Body = "<h1>Test mail</h1>";

            smtpClient.Send(mail);
        }
    }
}
