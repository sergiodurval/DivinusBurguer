using Divinus.Infra.Persistence;

namespace Divinus.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DivinusContext _context;

        public UnitOfWork(DivinusContext context)
        {
            _context = context;
        }

        public void Commit()
        {

            _context.SaveChanges();
        }
    }
}
