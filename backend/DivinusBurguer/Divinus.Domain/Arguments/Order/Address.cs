using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Order
{
    public class Address
    {
        public string ZipCode { get;  set; }
        public string PublicPlace { get;  set; }
        public string Neighborhood { get;  set; }
        public string State { get;  set; }
        public string Locality { get;  set; }
        public long Gia { get;  set; }
        public long Ibge { get;  set; }
        public string Complement { get;  set; }
        public long? Number { get;  set; }
        public string Reference { get;  set; }
    }
}
