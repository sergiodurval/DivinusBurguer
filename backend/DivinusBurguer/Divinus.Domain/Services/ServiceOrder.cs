using Divinus.Domain.Arguments.Order;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Domain.Interfaces.Services;
using Divinus.Domain.Mappers;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace Divinus.Domain.Services
{
    public class ServiceOrder : Notifiable, IServiceOrder
    {
        private readonly IRepositoryOrder _repositoryOrder;
        

        public ServiceOrder(IRepositoryOrder repositoryOrder)
        {
            _repositoryOrder = repositoryOrder;
            AutoMapperConfig.RegisterMappings();    
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest request)
        {
            if(request == null)
            {
                AddNotification("CreateOrderRequest", "CreateOrderRequest inválido");
                return null;
            }
            
            
            var order = new Order(
                request.IdUser, 
                Mapper.Map<Divinus.Domain.Arguments.Order.Address, Divinus.Domain.Entities.Address>(request.Address), 
                Mapper.Map<List<Divinus.Domain.Arguments.Order.Food>,List<Divinus.Domain.Entities.Food>>(request.PurchaseOrder), 
                request.PaymentMethod, 
                request.TotalValue);

            if(order.IsInvalid())
            {
                AddNotifications(order);
                return null;
            }

            long orderNumber = _repositoryOrder.InsertOrder(order);
            CreateOrderResponse response = new CreateOrderResponse();
            response.OrderNumber = orderNumber;
            return response;

        }

        public List<HistoryOrderResponse> HistoryOrder(HistoryOrderRequest request)
        {
            if(request == null)
            {
                AddNotification("HistoryOrderRequest", "HistoryOrderRequest inválido");
                return null;
            }

            List<Order> listOrder = _repositoryOrder.ObterTodosPedidos(request.Id);
            List<HistoryOrderResponse> Listresponse = new List<HistoryOrderResponse>();
            foreach (Order order in listOrder)
            {
                var response = new HistoryOrderResponse();
                response.Foods = Mapper.Map<List<Divinus.Domain.Entities.Food>,List<Divinus.Domain.Arguments.Order.Food>>(order.PurchaseOrder);
                response.OrderDate = order.OrderDate;
                response.OrderNumber = order.OrderNumber;
                response.PaymentMethod = order.PaymentMethod;
                response.TotalValue = order.TotalValue;
                Listresponse.Add(response);
            }
            return Listresponse;
        }
    }
}
