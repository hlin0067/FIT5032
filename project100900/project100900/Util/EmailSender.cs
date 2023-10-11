using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace project100900.Util
{
    public class EmailSender
    {
        private const String API_KEY = "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";

        public async Task SendAsync(String toEmail, String subject, String contents, HttpPostedFileBase postedFile)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("linhaowei0325@gmail.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            if (postedFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    postedFile.InputStream.CopyTo(memoryStream);
                    byte[] bytes = memoryStream.ToArray();
                    Attachment attachment = new Attachment();
                    attachment.Content = Convert.ToBase64String(bytes);
                    attachment.Filename = postedFile.FileName;
                    msg.AddAttachment(attachment.Filename, attachment.Content);
                }
            }
            var response = await client.SendEmailAsync(msg);
        }
    }
}
