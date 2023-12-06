using Microsoft.AspNetCore.Mvc;
using MusicApi.Email;

namespace MusicApi.Controllers;

[Route("[controller]")]
[ApiController]
public class EmailController : Controller
{
    private readonly IEmailSender emailSender;

    public EmailController(IEmailSender emailSender)
    {
        this.emailSender = emailSender;
    }

    [HttpPost]
    public async Task<IActionResult> Index(string email, string subject, string message)
    {
        await emailSender.SendEmailAsync(email, subject, message);
        return View();
    }
}
