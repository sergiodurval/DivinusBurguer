using Divinus.Api.Controllers.Base;
using Divinus.Domain.Arguments.User;
using Divinus.Domain.Interfaces.Services;
using Divinus.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Divinus.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : BaseController
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IUnitOfWork unitOfWork,IServiceUser serviceUser) : base(unitOfWork)
        {
            _serviceUser = serviceUser;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<HttpResponseMessage>Register(RegisterUserRequest request)
        {
            try
            {
                var response = _serviceUser.RegisterUser(request);
                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Authenticate")]
        [HttpPost]
        public async Task<HttpResponseMessage> Authenticate(AuthenticateUserRequest request)
        {
            try
            {
                var response = _serviceUser.AuthenticateUser(request);
                return await ResponseAsync(response, _serviceUser);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}