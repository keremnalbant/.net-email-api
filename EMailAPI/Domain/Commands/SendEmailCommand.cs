using MediatR;

namespace EMailAPI.Domain.Commands;

public class SendEmailCommand : IRequest<ResponseClass>
{
    public string Receivers { get; }

    public string Subject { get; }

    public string Body { get; }

    public SendEmailCommand(string receivers, string subject, string body)
    {
        Receivers = receivers;
        Subject = subject;
        Body = body;
    }
}