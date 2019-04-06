using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Divinus.Domain.Interfaces.Repositories
{
    public interface IRepositoryFood
    {
        Food AddFood(Food food);

        IEnumerable<Food> GetAllFood();

        Food GetFoodById(Guid id);

        Food UpdateFood(Food food);

        void DeleteFood(Guid id);
    }
}
