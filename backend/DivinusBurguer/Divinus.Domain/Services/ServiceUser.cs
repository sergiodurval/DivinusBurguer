using Divinus.Domain.Arguments.Base;
using Divinus.Domain.Arguments.User;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Services
{
    public class ServiceUser : Notifiable, IServiceUser
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public ResponseBase RegisterUser(RegisterUserRequest request)
        {
            if(request == null)
            {
                AddNotification("RegisterUserRequest", "Requisição inválida");
                return null;
            }

            var user = new User(request.Email, request.Password);

            if(_repositoryUser.Existe(x => x.Email == request.Email))
            {
                AddNotification("e-mail", "este email já está sendo utilizado");
            }

            if(this.IsInvalid())
            {
                return null;
            }

          user = _repositoryUser.Adicionar(user);

            return new ResponseBase();
        }
    }
}
