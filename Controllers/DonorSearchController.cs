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
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Hello"
            };

            using (var smtpClient = new SmtpClient())
            {
                /*client.ServerCertificateValidationCallback = (s, c, h, e) => true;*/
                smtpClient.Connect("smtp.mailgun.org", 587, true);
                smtpClient.Authenticate("190204084@aust.edu", "boxohxtgacjnnlip");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
            return (IActionResult)Task.CompletedTask;
        }



    }
}
