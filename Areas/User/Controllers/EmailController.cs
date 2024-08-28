using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace FptJobMatch.Areas.User.Controllers
{
	[Area("User")]
	public class EmailController : Controller
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult SendEmail(string name, string from, string to, string phone, string content)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = "Email From " + name;
            mail.Body = content + " Contact: " + phone;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(from, "jayng1512"),
                EnableSsl = true
            };

            try
            {
                smtpClient.Send(mail);
                return RedirectToAction("Profile", "Profile", new { area = "Candidate" });
            }
            catch (Exception ex)
            {
                return Content("Error sending email: " + ex.Message);
            }
        }
    }

}
