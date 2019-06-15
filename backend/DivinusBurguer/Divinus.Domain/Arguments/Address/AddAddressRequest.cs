using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Address
{
    public class AddAddressRequest
    {
        public string ZipCode { get; private set; }
        public string PublicPlace { get; private set; }
        public string Neighborhood { get; private set; }
        public string State { get; private set; }
        public string Locality { get; private set; }
        public long Gia { get; private set; }
        public long Ibge { get; private set; }
        public string Complement { get; private set; }
    }
}
