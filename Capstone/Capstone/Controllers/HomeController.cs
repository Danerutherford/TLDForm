using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Capstone.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderHistory()
        {


            return View();
        }

        public ActionResult Authorize()
        {
            return View();
        }

        public ActionResult PastVersions()
        {


            return View();
        }

        public ActionResult Sent() //action reult for sending the email from authorize user
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Authorize(EmailFormModel model) //handles authorize user email and form filling
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Here is your link to register!</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.FromEmail));  // replace with valid value 
                message.From = new MailAddress("testcapstonetest@gmail.com");  // replace with valid value
                message.Subject = "TLDR Order Form Registration";
                message.Body = string.Format(body, "TLD Admin", "testcapstonetest@gmail.com", "Registration Link: http://localhost:65222/Account/Register");
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "testcapstonetest@gmail.com",  // replace with valid value
                        Password = "qeadzc1!"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

    }
}