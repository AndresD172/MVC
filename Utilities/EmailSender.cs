using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Utilities
{
    public class EmailSender : IEmailSender
    {
        private string ApiKey { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            ApiKey = configuration.GetValue<String>("SendGrid:Secretkey");
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            SendGridClient client = new SendGridClient(ApiKey);
            EmailAddress from = new EmailAddress("andres.chacon.mora@covao.ed.cr");
            EmailAddress to = new EmailAddress(email);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);

            return client.SendEmailAsync(msg);
        }
    }
}
