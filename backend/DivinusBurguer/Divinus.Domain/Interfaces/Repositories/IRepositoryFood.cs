using Divinus.Domain.Arguments.Food;
using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;

namespace Divinus.Domain.Interfaces.Repositories
{
    public interface IRepositoryFood : IRepositoryBase<Food,Guid>
    {
    }
}
