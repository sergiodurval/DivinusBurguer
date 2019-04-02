using Divinus.Domain.Arguments.Food;

namespace Divinus.Domain.Interfaces.Repositories
{
    public interface IRepositoryFood
    {
        AddFoodResponse AddFood(AddFoodRequest request);
    }
}
