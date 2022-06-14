using EMailAPI.Domain;
using EMailAPI.Domain.Commands;
using MediatR;

namespace EMailAPI.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, ResponseClass>
{
    public async Task<ResponseClass> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var responseClass = new ResponseClass();

        try
        {
            if(request.password == "123456" && request.username == "keremnalbant")
            return responseClass.Successfull("Başarılı", 0);
            else
                return responseClass.Failure("Kullanıcı adı veya şifre hatalı.");

        }

        catch (Exception exc)
        {
            return responseClass.Failure("E-posta gönderimi başarısız." + " " + exc);
        }

    }
}
