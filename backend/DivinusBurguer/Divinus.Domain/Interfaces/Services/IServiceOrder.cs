using Divinus.Domain.Arguments.Order;
using Divinus.Domain.Services.Base;
using System.Collections.Generic;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceOrder : IServiceBase
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        List<HistoryOrderResponse> HistoryOrder(HistoryOrderRequest request);
    }
}
