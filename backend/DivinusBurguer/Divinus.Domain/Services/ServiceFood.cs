using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Services
{
    public class ServiceFood : IServiceFood
    {
        private readonly IRepositoryFood _repositoryFood;

        public ServiceFood(IRepositoryFood repositoryFood)
        {
            _repositoryFood = repositoryFood;
        }

        public AddFoodResponse AddFood(AddFoodRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
