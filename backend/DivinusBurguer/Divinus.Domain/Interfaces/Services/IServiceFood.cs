using Divinus.Domain.Arguments.Food;
using System;

namespace Divinus.Domain.Interfaces.Services
{
    public interface IServiceFood
    {
        AddFoodResponse AddFood(AddFoodRequest request);
    }
}
