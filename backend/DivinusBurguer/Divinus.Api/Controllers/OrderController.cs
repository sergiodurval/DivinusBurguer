using Divinus.Api.Controllers.Base;
using Divinus.Domain.Arguments.Order;
using Divinus.Domain.Interfaces.Services;
using Divinus.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Divinus.Api.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : BaseController
    {
        private readonly IServiceOrder _serviceOrder;

        public OrderController(IUnitOfWork unitOfWork, IServiceOrder serviceOrder) : base(unitOfWork)
        {
            _serviceOrder = serviceOrder;
        }

        [Route("CreateOrder")]
        [HttpPost]
        [Authorize]
        public async Task<HttpResponseMessage> CreateOrder(CreateOrderRequest request)
        {
            try
            {
                var response = _serviceOrder.CreateOrder(request);
                return await ResponseAsync(response, _serviceOrder);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}