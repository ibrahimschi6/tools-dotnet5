using DotNet5.Tools.Domain.Model;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DotNet5.Tools.Services.Email
{
    public interface IEmailSender
    {
        void SendEmail(EmailTemplate template, List<MailAddress> toList);
    }
}
