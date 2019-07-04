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

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            if(request == null)
            {
                AddNotification("AuthenticateUserRequest", "Requisição inválida");
                return null;
            }

            var user = new User(request.Email, request.Password);

            AddNotifications(user);

            if(user.IsInvalid())
            {
                return null;
            }

            if(!_repositoryUser.Existe(x => x.Email == user.Email && x.Password == user.Password))
            {
                AddNotification("User", "Usuário ou senha inválidos");
                return null;
            }
            else
            {
                user = _repositoryUser.ObterPor(x => x.Email == user.Email && x.Password == user.Password);
            }

            return (AuthenticateUserResponse)user;
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

            AddNotifications(user);

            if(user.IsInvalid())
            {
                return null;
            }

          _repositoryUser.Adicionar(user);

            return new ResponseBase();
        }
    }
}
