using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.User
{
    public class AuthenticateUserResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public static explicit operator AuthenticateUserResponse(Entities.User entidade)
        {
            return new AuthenticateUserResponse()
            {
                Email = entidade.Email,
                Id = entidade.Id
            };
        }
    }
}
