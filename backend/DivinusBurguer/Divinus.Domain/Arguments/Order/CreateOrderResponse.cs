using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Order
{
    public class CreateOrderResponse : IResponse
    {
        public long OrderNumber { get; set; }
    }
}
