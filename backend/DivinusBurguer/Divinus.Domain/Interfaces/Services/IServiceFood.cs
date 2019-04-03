using Divinus.Domain.Arguments.Food;
using System;
using System.Collections.Generic;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceFood
    {
        AddFoodResponse AddFood(AddFoodRequest request);

        IEnumerable<FoodResponse> GetAllFood();
    }
}
