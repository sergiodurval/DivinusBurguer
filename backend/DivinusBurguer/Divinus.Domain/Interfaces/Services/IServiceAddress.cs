using Divinus.Domain.Arguments.Address;
using Divinus.Domain.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceAddress : IServiceBase
    {
        SearchAddressResponse Search(SearchAddressRequest request);
        AddAddressResponse Add(AddAddressRequest request);
    }
}
