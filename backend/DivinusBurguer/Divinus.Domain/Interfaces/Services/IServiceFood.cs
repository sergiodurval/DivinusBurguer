using Divinus.Domain.Arguments.Base;
using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Services.Base;
using System;
using System.Collections.Generic;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceFood : IServiceBase
    {
        AddFoodResponse AddFood(AddFoodRequest request);

        IEnumerable<FoodResponse> GetAllFood();

        IEnumerable<FoodResponse> GetAllFoodOrdered();

        FoodResponse GetFoodById(Guid id);

        FoodResponse UpdateFood(UpdateFoodRequest request);

        ResponseBase DeleteFood(Guid id);
    }
}
