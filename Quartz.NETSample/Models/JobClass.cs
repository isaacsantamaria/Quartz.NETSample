using System;
using System.Net;
using System.Net.Mail;

namespace Quartz.NETSample.Models
{
    public class JobClass : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage("from", "to"))
            {
                message.Subject = "Email Test";
                message.Body = "Prueba " + DateTime.Now;
                using (var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("account", "passw0rd"),
                    EnableSsl = true
                })
                {
                    client.Send(message);
                }
            }
        }
    }
}