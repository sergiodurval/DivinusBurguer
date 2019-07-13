using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Order
{
    public class HistoryOrderResponse : IResponse
    {
        public List<Food> Foods { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime OrderDate { get;  set; }
        public int OrderNumber { get;  set; }
    }
}
