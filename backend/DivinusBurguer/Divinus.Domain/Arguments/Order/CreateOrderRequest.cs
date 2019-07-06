using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;


namespace Divinus.Domain.Arguments.Order
{
    public class CreateOrderRequest : IRequest
    {
        public Guid IdUser { get; set; }
        public Address Address { get; set; }
        public List<Food> PurchaseOrder { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }

    }
}
