using System.Net;
using System.Net.Mail;

namespace MusicApi.Email;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration config;
    public EmailSender(IConfiguration config)
    {
        this.config = config;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        var emailpasswod = config["mailpassword"];
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("codebras2023@gmail.com", emailpasswod)
        };

        return client.SendMailAsync(
            new MailMessage(from: "codebras2023@gmail.com",
                to: email,
                subject,
                message));
    }
}
