using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Interfaces.Repositories
{
    public interface IRepositoryAddress : IRepositoryBase<Address, Guid>
    {
    }
}
