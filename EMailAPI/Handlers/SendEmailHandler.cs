using EMailAPI.Domain;
using EMailAPI.Domain.Commands;
using EMailAPI.Helper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace EMailAPI.Handlers;

public class SendEmailHandler : IRequestHandler<SendEmailCommand, ResponseClass>
{
    public async Task<ResponseClass> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        EmailHelper emailHelper = new();
        var responseClass = new ResponseClass();

        try
        {
            var result = emailHelper.SendEmailAsync(request.Receivers, request.Subject, request.Body);
            return responseClass.Successfull("E-posta gönderimi baþarýlý.", result);
        }

        catch (Exception exc)
        {
            return responseClass.Failure("E-posta gönderimi baþarýsýz." + " " + exc);
        }

    }
}