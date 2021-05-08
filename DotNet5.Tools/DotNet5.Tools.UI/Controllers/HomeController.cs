using DotNet5.Tools.Domain.Model;
using DotNet5.Tools.Services.Email;
using DotNet5.Tools.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DotNet5.Tools.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender, ILogger<HomeController> logger)
        {
            _emailSender = emailSender;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult SendEmail()
        {
            try
            {
                var template = new EmailTemplate {
                    Id = 1,
                    Name = "Weekly Reminder Template",
                    Subject = "Weekly Reminder",
                    Body = string.Format($"Dear Customer, <br/> Reminder Text")
                };            

                var toList = new List<MailAddress>();
                toList.Add(new MailAddress("<customerEmail_1>"));
                toList.Add(new MailAddress("<customerEmail_2>"));

                _emailSender.SendEmail(template,toList);

                TempData["success_message"] = "Your email has been successfully saved";

            }
            catch (Exception e)
            {
                TempData["danger_message"] = "There was an error sending the email. Error:" + e.Message;

            }
            return View();
        }

    }
}
