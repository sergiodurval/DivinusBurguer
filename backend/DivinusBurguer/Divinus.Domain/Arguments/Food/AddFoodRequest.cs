using Divinus.Domain.Interfaces.Arguments;

namespace Divinus.Domain.Arguments.Food
{
    public class AddFoodRequest : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }
    }
}
