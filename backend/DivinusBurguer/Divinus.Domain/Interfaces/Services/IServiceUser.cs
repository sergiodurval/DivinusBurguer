using Divinus.Domain.Arguments.Base;
using Divinus.Domain.Arguments.User;
using Divinus.Domain.Services.Base;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceUser : IServiceBase
    {
        ResponseBase RegisterUser(RegisterUserRequest request);
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request);
    }
}
