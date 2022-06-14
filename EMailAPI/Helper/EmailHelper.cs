using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Authentication;
using System.Text;
using EMailAPI.Domain.Interfaces;
using EMailAPI.Settings;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace EMailAPI.Helper;

public class EmailHelper : IEmailSender
{
    private EmailSettings _options;
    private System.Net.Mail.SmtpClient _smtpClient;

    public EmailHelper()
    {
        _smtpClient = new System.Net.Mail.SmtpClient();
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        return Execute(email, subject, message);
    }

    private Task Execute(string to, string subject, string message)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("kavon.rowe19@ethereal.email"));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = "Frontend Challenge";
        email.Body = new TextPart(TextFormat.Html) { Text = message };
        
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("kavon.rowe19@ethereal.email", "Tz33HxE1mZmRuE1T8r");
        smtp.Send(email);
        smtp.Disconnect(true);

        return Task.FromResult(true);
    }
}