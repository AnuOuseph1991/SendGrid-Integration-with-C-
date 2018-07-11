using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace sendGridEmailPOC.Controllers
{
    public class MailEngineController : ApiController
    {
        /// <summary>
        /// SendMail using API for this you need to install sendgrid package.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<bool> SendMailUsingAPI()
        {
            var apiKey = Environment.GetEnvironmentVariable("MailEngine");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("abcd@outlook.com", "MailEngine");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("abcd@socxo.com", "Anu test");
            var plainTextContent = "test 12345" + "https://stackoverflow.com/questions/23000224/design-considerations-for-an-rss-client?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa"; 
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return true;
        }

        /// <summary>
        /// Send mail using Smtp server
        /// </summary>
        /// <returns></returns>

        public bool SendMailUsingSmtpServer()
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("abcd@outlook.com");
                mailMessage.To.Add(new MailAddress("abcd@suyati.com"));
                mailMessage.To.Add(new MailAddress("abcd@socxo.com"));
                mailMessage.Subject = "TestMail";
                mailMessage.Body = "test 12345" + "https://stackoverflow.com/questions/23000224/design-considerations-for-an-rss-client?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa";
                // AddCopies(mailMessage);
                smtpClient.Send(mailMessage);
            }

            return true;
        }

        /// <summary>
        /// Send bulk campaign using api
        /// </summary>
        [HttpGet]
        public async Task<bool> SendEmaiBulkThroughAPI()
        {
            var apiKey = Environment.GetEnvironmentVariable("MailEngine");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("abcd@outlook.com", "MailEngine");
            var subject = "Sending with SendGrid is Fun";
            var toList = new List<EmailAddress>();
            var to = new EmailAddress("abcd@suyati.com", "Anu test");
            var to1 = new EmailAddress("abcd@socxo.com", "Ann");
            toList.Add(to1);
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, toList, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return true;
        }
    }
}
