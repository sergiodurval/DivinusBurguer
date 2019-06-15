using Divinus.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Divinus.Infra.Persistence.Map
{
    public class MapAddress : EntityTypeConfiguration<Address>
    {
        public MapAddress()
        {
            ToTable("Address");
            Property(p => p.ZipCode).HasMaxLength(250);
            Property(p => p.PublicPlace).HasMaxLength(250);
            Property(p => p.Neighborhood).HasMaxLength(250);
            Property(p => p.State).HasMaxLength(2);
            Property(p => p.Locality).HasMaxLength(250);
            Property(p => p.Complement).HasMaxLength(250);
            Property(p => p.Ibge);
            Property(p => p.Gia);
        }
    }
}
