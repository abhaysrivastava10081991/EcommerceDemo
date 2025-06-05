using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;    

namespace Ecommerce.DataUtility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Here you would implement the logic to send an email.
            // For example, using SMTP or a third-party service like SendGrid.
            //Console.WriteLine($"Sending email to {email} with subject '{subject}' and message '{htmlMessage}'");
            return Task.CompletedTask;
        }
    }
}
