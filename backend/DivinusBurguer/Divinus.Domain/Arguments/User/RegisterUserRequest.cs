using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.User
{
    public class RegisterUserRequest : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
