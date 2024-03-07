using ContactUsEmail.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactUs.Pages;

public class ContactUsModel : PageModel
{
    private readonly IEmailService _emailService;

    public ContactUsModel(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task<IActionResult> OnGet(string subject, string body)
    {
        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
        { 

        }
        else
        {// Створіть об'єкт EmailDto з потрібними даними
            EmailDto emailDto = new EmailDto
            {
                To = "marjolaine30@ethereal.email",
                Subject = subject,
                Body = body
            };

            _emailService.SendEmail(emailDto);
            TempData["Message"] = "Повідомлення надіслано";
        }
        // Поверніть результат
        return Page();
    }
}
