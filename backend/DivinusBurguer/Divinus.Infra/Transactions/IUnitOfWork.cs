using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
