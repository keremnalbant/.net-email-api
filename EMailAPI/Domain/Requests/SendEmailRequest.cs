namespace EMailAPI.Domain.Requests;

public class SendEmailRequest
{
    public string Receivers { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
}