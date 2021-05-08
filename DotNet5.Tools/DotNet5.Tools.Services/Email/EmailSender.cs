using DotNet5.Tools.Domain.Exceptions;
using DotNet5.Tools.Domain.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DotNet5.Tools.Services.Email
{
    public class EmailSender : IEmailSender
    {
        
        private IOptions<EmailConfiguration> _emailSettings;
        public EmailSender(IOptions<EmailConfiguration> emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public void SendEmail(EmailTemplate template, List<MailAddress> toList)
        {
            try
            {
                
                MailAddress fromAddress = new MailAddress(_emailSettings.Value.AccountName, "Info Email");
                MailAddress toAddress = new MailAddress(toList[0].Address);

                var client = new SmtpClient();
                client.Port = _emailSettings.Value.Port;
                client.Host = _emailSettings.Value.Host;
                client.EnableSsl = true;

                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailSettings.Value.AccountName, _emailSettings.Value.Password);


                MailMessage mm = new MailMessage(fromAddress, toAddress)
                {
                    BodyEncoding = UTF8Encoding.UTF8,
                    IsBodyHtml = true,
                    Body = template.Body,
                    Subject = template.Subject                    
                };
                client.Send(mm);

            }
            catch (Exception e)
            {
                throw new EmailSendErrorException(e.Message);
            }
        }
    }
}
