using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EMailSender.Model
{
    public static class MSGSender
    {

        public static bool SendMail(string from, string to, string cc, string bcc, string subject, string body, out string resultMessage)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(from);
            List<string> l = to.Split(' ').ToList();
            foreach (var i in l)
                msg.To.Add(new MailAddress(i));
            msg.Subject = subject;
            msg.Body = body;

            List<string> ccl = cc.Split(' ').ToList();
            List<string> bccl = bcc.Split(' ').ToList();
            foreach (var i in ccl)
                msg.CC.Add(new MailAddress(i));
            foreach (var i in bccl)
                msg.Bcc.Add(new MailAddress(i));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("gersen.e.a@gmail.com", "1rJ,kfcnm3");

            try
            {
                smtp.Send(msg);
                resultMessage = "Mail send";
                return true;
            }
            catch (Exception ex)
            {
                resultMessage = ex.Message;
                if (ex.InnerException != null)
                    resultMessage += ex.InnerException.Message;
                return false;
            }
        }
    }
}
