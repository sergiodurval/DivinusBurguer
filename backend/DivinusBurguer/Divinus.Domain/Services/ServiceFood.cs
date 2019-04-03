using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Services
{
    public class ServiceFood : Notifiable, IServiceFood
    {
        private readonly IRepositoryFood _repositoryFood;

        public ServiceFood(IRepositoryFood repositoryFood)
        {
            _repositoryFood = repositoryFood;
        }

        public AddFoodResponse AddFood(AddFoodRequest request)
        {
            var food = new Food(request.Name, request.Description, request.Price, request.ImageName);

            if(this.IsInvalid())
            {
                return null;
            }

            return (AddFoodResponse)food;
        }

        public IEnumerable<FoodResponse> GetAllFood()
        {
            return _repositoryFood.GetAllFood().ToList().Select(food => (FoodResponse)food).ToList();
        }
    }
}
