using Divinus.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Divinus.Infra.Persistence.Map
{
    public class MapFood : EntityTypeConfiguration<Food>
    {
        public MapFood()
        {
            ToTable("Food");
            Property(p => p.Name).HasMaxLength(250).IsRequired();
            Property(p => p.Description).HasMaxLength(250).IsRequired();
            Property(p => p.Price).IsRequired();
            Property(p => p.ImageName).HasMaxLength(250).IsRequired();
        }
    }
}
