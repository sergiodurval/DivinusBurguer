using Divinus.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace Divinus.Domain.Entities
{
    public class Order : EntityBase
    {
        public Guid IdUser { get; private set; }
        public DateTime OrderDate { get; private set; }
        public int OrderNumber { get; private set; }
        public Address Address { get; private set; }
        public List<Food> PurchaseOrder { get; private set; }
        public string PaymentMethod { get; private set; }
        public decimal TotalValue { get; private set; }

        public Order(Guid idUser,Address address , List<Food> purchaseOrder , string paymentMethod , decimal totalValue)
        {
            IdUser = idUser;
            Address = address;
            PurchaseOrder = purchaseOrder;
            PaymentMethod = paymentMethod;
            TotalValue = totalValue;
            OrderDate = DateTime.Now;

            new AddNotifications<Address>(this.Address)
               .IfNullOrEmpty(x => x.ZipCode, "Cep obrigatório")
               .IfNullOrEmpty(x => x.PublicPlace, "Logradouro obrigatório")
               .IfNullOrEmpty(x => x.Neighborhood, "Bairro obrigatório")
               .IfNullOrEmpty(x => x.State, "Estado obrigatório");

            new AddNotifications<Order>(this)
                .IfNullOrEmpty(x => x.PaymentMethod, "forma de pagamento obrigatório");

            if(PurchaseOrder.Count == 0)
            {
                AddNotification("carrinho", "carrinho não pode estar vazio");
            }
                
        }

        protected Order() { }
    }
}
