using Divinus.Infra.Persistence;
using System.Data.Entity;

namespace Divinus.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Commit()
        {

            _context.SaveChanges();
        }
    }
}
