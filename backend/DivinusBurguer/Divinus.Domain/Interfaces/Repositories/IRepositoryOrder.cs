using Divinus.Domain.Entities;
using Divinus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Interfaces.Repositories
{
    public interface IRepositoryOrder : IRepositoryBase<Order,Guid>
    {
        Order ObterPedidoById(Guid idOrder);
        List<Order> ObterTodosPedidos(Guid idUser);
        long InsertOrder(Order order);
    }
}
