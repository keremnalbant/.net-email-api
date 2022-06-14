using MediatR;

namespace EMailAPI.Domain.Commands
{
    public class LoginCommand : Users, IRequest<ResponseClass>
    {
        public LoginCommand(string username, string password) : base(username, password)
        {
        }
    }
}
