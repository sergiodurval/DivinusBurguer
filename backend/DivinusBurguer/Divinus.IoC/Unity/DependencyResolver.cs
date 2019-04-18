using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Divinus.Infra.Persistence;
using prmToolkit.NotificationPattern;
using Divinus.Domain.Interfaces.Services;
using Divinus.Domain.Services;
using Divinus.Domain.Interfaces.Repositories.Base;
using Divinus.Infra.Persistence.Repositories.Base;
using Divinus.Domain.Interfaces.Repositories;
using Divinus.Infra.Persistence.Repositories;
using Divinus.Infra.Transactions;

namespace Divinus.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext,DivinusContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServiceFood, ServiceFood>(new HierarchicalLifetimeManager());
            


            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositoryFood, RepositoryFood>(new HierarchicalLifetimeManager());
            



        }
    }
}
