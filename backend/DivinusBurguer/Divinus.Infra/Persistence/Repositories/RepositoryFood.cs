using System;
using System.Collections.Generic;
using System.Linq;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories;

namespace Divinus.Infra.Persistence.Repositories
{
    public class RepositoryFood : IRepositoryFood
    {
        protected readonly DivinusContext _context;

        public RepositoryFood(DivinusContext context)
        {
            _context = context;
        }

        public Food AddFood(Food food)
        {
            throw new NotImplementedException();
        }

        public void DeleteFood(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Food> GetAllFood()
        {
            return _context.Foods.ToList();
        }

        public Food GetFoodById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Food UpdateFood(Food food)
        {
            throw new NotImplementedException();
        }
    }
}
