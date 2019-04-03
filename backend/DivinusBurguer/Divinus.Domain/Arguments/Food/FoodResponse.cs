using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Food
{
    public class FoodResponse : IResponse
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string ImageName { get; private set; }

        public static explicit operator FoodResponse(Entities.Food entidade)
        {
            return new FoodResponse()
            {
                Id = entidade.Id,
                Description = entidade.Description,
                ImageName = entidade.ImageName,
                Name = entidade.Name,
                Price = entidade.Price
            };
        }
    }
}
