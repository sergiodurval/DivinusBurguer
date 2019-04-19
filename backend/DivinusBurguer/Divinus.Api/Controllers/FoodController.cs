using Divinus.Api.Controllers.Base;
using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Interfaces.Services;
using Divinus.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Divinus.Api.Controllers
{
    [RoutePrefix("api/food")]
    public class FoodController : BaseController
    {
        private readonly IServiceFood _serviceFood;

        public FoodController(IUnitOfWork unitOfWork, IServiceFood serviceFood) : base(unitOfWork)
        {
            _serviceFood = serviceFood;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddFoodRequest request)
        {
            try
            {
                var response = _serviceFood.AddFood(request);
                return await ResponseAsync(response, _serviceFood);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Update")]
        [HttpPost]
        public async Task<HttpResponseMessage> Update(UpdateFoodRequest request)
        {
            try
            {
                var response = _serviceFood.UpdateFood(request);
                return await ResponseAsync(response, _serviceFood);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(Guid id)
        {
            try
            {
                var response = _serviceFood.GetFoodById(id);
                return await ResponseAsync(response, _serviceFood);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            try
            {
                var response = _serviceFood.GetAllFood();
                return await ResponseAsync(response, _serviceFood);

            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = _serviceFood.DeleteFood(id);
                return await ResponseAsync(response, _serviceFood);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}