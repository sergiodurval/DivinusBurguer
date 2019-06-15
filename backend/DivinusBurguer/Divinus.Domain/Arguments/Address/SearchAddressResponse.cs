using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Address
{
    public class SearchAddressResponse : IResponse
    {
        public string ZipCode { get; private set; }
        public string PublicPlace { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
        public string Locality { get; private set; }
        public long Gia { get; private set; }
        public long Ibge { get; private set; }
        public string Complement { get; private set; }

        public static explicit operator SearchAddressResponse(Entities.Address entidade)
        {
            return new SearchAddressResponse()
            {
                Complement = entidade.Complement,
                Gia = entidade.Gia,
                Ibge = entidade.Ibge,
                Locality = entidade.Locality,
                Neighborhood = entidade.Neighborhood,
                PublicPlace = entidade.PublicPlace,
                State = entidade.State,
                ZipCode = entidade.ZipCode
            };
        }
    }
}
