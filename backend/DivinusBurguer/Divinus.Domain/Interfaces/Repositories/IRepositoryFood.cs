using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Entities;
using System.Collections.Generic;

namespace Divinus.Domain.Interfaces.Repositories
{
    public interface IRepositoryFood
    {
        Food AddFood(AddFoodRequest request);

        IEnumerable<Food> GetAllFood();
    }
}
