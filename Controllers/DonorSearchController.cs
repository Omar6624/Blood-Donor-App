using Blood_Donor_App_v4.Data;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace Blood_Donor_App_v4.Controllers
{
    public class DonorSearchController : Controller
    {
        private readonly Blood_Donor_App_v4Context _context;

        public DonorSearchController(Blood_Donor_App_v4Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string SearchString, string SearchType)
        {
            //var data = _context.DonorOtherInfo.ToList();

            ViewData["SearchString"] = SearchString;
            ViewData["SearchType"] = SearchType;
            var find = from b in _context.DonorOtherInfo
                       select b;
            if (!String.IsNullOrEmpty(SearchString) &&  !String.IsNullOrEmpty(SearchType))
            {
                find = find.Where(b => b.Address.Contains(SearchString.ToLower()) && b.BloodType.Contains(SearchType));
            }
            else
            {
                return View(await _context.DonorOtherInfo.ToListAsync());
            }
            return View(find);




            /*return View(await _context.DonorOtherInfo.ToListAsync();*/
        }
        public async Task<IActionResult> Mail()
        {
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Donor", "postmaster@sandboxc5335b4c1a54456689371a1a45ffca19.mailgun.org"));
            mailMessage.To.Add(new MailboxAddress("Omar", "omarfaruktasnim555@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("Omar", "naimulislam19149@gmail.com"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Hello"
            };

            using (var client = new SmtpClient())
            {
                /*client.ServerCertificateValidationCallback = (s, c, h, e) => true;*/
                // XXX - Should this be a little different?
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.mailgun.org", 587, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("postmaster@sandboxc5335b4c1a54456689371a1a45ffca19.mailgun.org", "f0f67cbe65c3353c59e527d5f2f855bb-ca9eeb88-467fca7c");

                client.Send(mailMessage);
                client.Disconnect(true);
            }
            return View();
        }



    }
}
