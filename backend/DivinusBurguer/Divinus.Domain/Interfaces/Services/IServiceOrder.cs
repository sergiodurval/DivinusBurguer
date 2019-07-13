using Divinus.Domain.Arguments.Order;
using Divinus.Domain.Services.Base;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceOrder : IServiceBase
    {
        CreateOrderResponse CreateOrder(CreateOrderRequest request);
        HistoryOrderResponse HistoryOrder(HistoryOrderRequest request);
    }
}
