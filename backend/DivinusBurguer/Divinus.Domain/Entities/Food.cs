using Divinus.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;

namespace Divinus.Domain.Entities
{
    public class Food : EntityBase
    {
        public Food(string name, string description, decimal price, string imageName , string category)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageName = imageName;
            Category = category;

            new AddNotifications<Food>(this)
               .IfNullOrInvalidLength(x => x.Name, 5, 60, "O nome do lanche deve conter no mínimo 6 caracteres e no máximo 60 caracteres")
               .IfNullOrEmpty(x => x.Description, "A descrição do item é obrigatória")
               .IfLowerOrEqualsThan(x => x.Price,0, "O preço do item é obrigatório")
               .IfNullOrEmpty(x => x.ImageName, "A imagem do item é obrigatória")
               .IfNullOrEmpty(x => x.Category, "A categoria do item é obrigatória");
        }

        public void Update(string name , string description , decimal price , string imageName , string category)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageName = imageName;
            Category = category;

            new AddNotifications<Food>(this)
               .IfNullOrInvalidLength(x => x.Name, 5, 60, "O nome do lanche deve conter no mínimo 6 caracteres e no máximo 60 caracteres")
               .IfNullOrEmpty(x => x.Description, "A descrição do item é obrigatória")
               .IfEqualsZero(x => (int)x.Price, "Preço obrigatório")
               .IfNullOrEmpty(x => x.ImageName, "A imagem do item é obrigatória")
               .IfNullOrEmpty(x => x.Category, "A categoria do item é obrigatória");
        }

        public Food(string name, string description, decimal price, string imageName, string category , int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageName = imageName;
            Category = category;
            Quantity = quantity;

            new AddNotifications<Food>(this)
               .IfNullOrInvalidLength(x => x.Name, 5, 60, "O nome do lanche deve conter no mínimo 6 caracteres e no máximo 60 caracteres")
               .IfNullOrEmpty(x => x.Description, "A descrição do item é obrigatória")
               .IfLowerOrEqualsThan(x => x.Price, 0, "O preço do item é obrigatório")
               .IfNullOrEmpty(x => x.ImageName, "A imagem do item é obrigatória")
               .IfNullOrEmpty(x => x.Category, "A categoria do item é obrigatória");
        }

        protected Food()
        {

        }

        

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string ImageName { get; private set; }

        public string Category { get; private set; }

        public int? Quantity { get; private set; }

    }
}
