using System;
using System.Net;
using System.Net.Mail;

namespace Quartz.NETSample.Models
{
    public class JobClass : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var message = new MailMessage("luis.tupiac@gmail.com", "luis.tupiac@gmail.com"))
            {
                message.Subject = "Email Test";
                message.Body = "Prueba " + DateTime.Now;
                using (var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("luis.tupiac@gmail.com", "yordan.91"),
                    EnableSsl = true
                })
                {
                    client.Send(message);
                }
            }
        }
    }
}