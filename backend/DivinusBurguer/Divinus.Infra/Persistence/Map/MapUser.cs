using Divinus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Infra.Persistence.Map
{
    public class MapUser : EntityTypeConfiguration<User>
    {
        public MapUser()
        {
            ToTable("User");
            Property(p => p.Email).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.CreatedAt).IsRequired();
        }
    }
}
