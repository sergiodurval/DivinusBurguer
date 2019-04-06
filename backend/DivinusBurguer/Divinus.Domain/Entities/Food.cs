using prmToolkit.NotificationPattern;
using System;

namespace Divinus.Domain.Entities
{
    public class Food : Notifiable
    {
        public Food(string name, string description, decimal price, string imageName)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageName = imageName;

            new AddNotifications<Food>(this)
               .IfNullOrInvalidLength(x => x.Name, 5, 60, "O nome do lanche deve conter no mínimo 6 caracteres e no máximo 60 caracteres")
               .IfNullOrEmpty(x => x.Description, "A descrição do item é obrigatória")
               .IfEqualsZero(x => (int)x.Price, "Preço obrigatório")
               .IfNullOrEmpty(x => x.ImageName, "A imagem do item é obrigatória");
        }

        public void Update(string name , string description , decimal price , string imageName)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageName = imageName;

            new AddNotifications<Food>(this)
               .IfNullOrInvalidLength(x => x.Name, 5, 60, "O nome do lanche deve conter no mínimo 6 caracteres e no máximo 60 caracteres")
               .IfNullOrEmpty(x => x.Description, "A descrição do item é obrigatória")
               .IfEqualsZero(x => (int)x.Price, "Preço obrigatório")
               .IfNullOrEmpty(x => x.ImageName, "A imagem do item é obrigatória");
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public string ImageName { get; private set; }

        
    }
}
