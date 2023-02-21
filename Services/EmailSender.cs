using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
//using System.Net.Mail;




namespace Blood_Donor_App_v4.Services;
//namespace WebPWrecover.Services;

public class EmailSender : IEmailSender
{
	private readonly ILogger _logger;

	public EmailSender(/*IOptions<AuthMessageSenderOptions> optionsAccessor,*/
					   ILogger<EmailSender> logger)
	{
		/*Options = optionsAccessor.Value;*/
		_logger = logger;
	}

	//public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

	public async Task SendEmailAsync(string toEmail, string subject, string message)
	{
		await Execute(subject, message, toEmail);
	}

	public async Task Execute(string subject, string message, string toEmail)
	{
		var mailMessage = new MimeMessage();
		mailMessage.From.Add(new MailboxAddress("Blood Donor", "postmaster@blood-donor.site"));

		//foreach (string EmailAddress in em)
		//{
			mailMessage.To.Add(new MailboxAddress("Blood Donor", toEmail));
		//}



		/*mailMessage.To.Add(new MailboxAddress("Omar", "naimulislam19149@gmail.com"));*/
		mailMessage.Subject = subject;
		var bodyBuilder = new BodyBuilder();
		bodyBuilder.HtmlBody = message;
		mailMessage.Body = bodyBuilder.ToMessageBody();

		using (var client = new SmtpClient())
		{
			/*client.ServerCertificateValidationCallback = (s, c, h, e) => true;*/
			// XXX - Should this be a little different?
			client.ServerCertificateValidationCallback = (s, c, h, e) => true;

			client.Connect("smtp.mailgun.org", 587, false);
			client.AuthenticationMechanisms.Remove("XOAUTH2");
			client.Authenticate("postmaster@blood-donor.site", "0e5c9c02a45b685f6b94915d7afff8bc-52d193a0-852595da");

			client.Send(mailMessage);
			client.Disconnect(true);
		}
		_logger.LogInformation($"Email to {toEmail} queued successfully!");
	}
}