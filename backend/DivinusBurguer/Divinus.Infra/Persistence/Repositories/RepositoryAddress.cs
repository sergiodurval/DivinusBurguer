using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Infra.Persistence.Repositories
{
    public class RepositoryAddress : RepositoryBase<Address,Guid> , IRepositoryAddress
    {
        protected readonly DivinusContext _context;

        public RepositoryAddress(DbContext context) : base(context)
        {

        }
    }
}
