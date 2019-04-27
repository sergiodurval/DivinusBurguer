using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Infra.Persistence.Repositories.Base;

namespace Divinus.Infra.Persistence.Repositories
{
    public class RepositoryFood : RepositoryBase<Food,Guid> , IRepositoryFood
    {
        protected readonly DivinusContext _context;

        //public RepositoryFood(DivinusContext context) : base(context)
        //{
        //    _context = context;
        //}

        public RepositoryFood(DbContext context) : base(context)
        {

        }
    }
}
