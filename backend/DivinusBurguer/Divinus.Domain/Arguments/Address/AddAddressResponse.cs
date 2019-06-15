using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Address
{
    public class AddAddressResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public static explicit operator AddAddressResponse(Entities.Address entidade)
        {
            return new AddAddressResponse()
            {
                Id = entidade.Id,
                Message = "Operação realizada com sucesso"
            };
        }
    }
}
