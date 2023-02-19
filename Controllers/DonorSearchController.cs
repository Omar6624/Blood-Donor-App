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
                find = find.Where(b => b.Address.ToLower().Contains(SearchString.ToLower()) && b.BloodType.Contains(SearchType));
            }
            else
            {
                return View(await _context.DonorOtherInfo.ToListAsync());
            }
            return View(find);




            /*return View(await _context.DonorOtherInfo.ToListAsync();*/
        }
        public async Task<IActionResult> Mail(string DonorEmail,string UserLoc , string UserBlood , string UserNumber,string DonorBlood)
        {
            string[] em = DonorEmail.Split(',');
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Donor", "postmaster@sandboxc5335b4c1a54456689371a1a45ffca19.mailgun.org"));

            foreach (string EmailAddress in em)
            {
                mailMessage.Cc.Add(new MailboxAddress("SenderEmail", EmailAddress));
            }



            /*mailMessage.To.Add(new MailboxAddress("Omar", "naimulislam19149@gmail.com"));*/
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "Hello I am using Donors website to reach you " +
                "Right now im am badly in need of  " +DonorBlood+" type blood by the time  "+UserBlood +"  The location of the hospital is  "+ UserLoc+ " it would be very generouos of you if you can " +
                "come here as soon as possible and donate blood.Thank you.You can reach me at " +
                " "+UserNumber 
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
