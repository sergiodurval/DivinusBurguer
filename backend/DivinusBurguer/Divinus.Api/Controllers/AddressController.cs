using Divinus.Api.Controllers.Base;
using Divinus.Domain.Arguments.Address;
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
    [RoutePrefix("api/address")]
    public class AddressController : BaseController
    {
        private readonly IServiceAddress _serviceAddress;

        public AddressController(IUnitOfWork unitOfWork , IServiceAddress serviceAddress) : base(unitOfWork)
        {
            _serviceAddress = serviceAddress;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddAddressRequest request)
        {
            try
            {
                var response = _serviceAddress.Add(request);
                return await ResponseAsync(response, _serviceAddress);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Search")]
        [HttpGet]
        public async Task<HttpResponseMessage> Search(string zipcode)
        {
            try
            {
                var request = new SearchAddressRequest() { ZipCode = zipcode };
                var response = _serviceAddress.Search(request);
                return await ResponseAsync(response, _serviceAddress);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}