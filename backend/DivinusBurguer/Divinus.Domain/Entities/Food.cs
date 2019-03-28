using System;

namespace Divinus.Domain.Entities
{
    public class Food
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }
    }
}
