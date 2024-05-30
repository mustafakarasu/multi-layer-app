using Autofac;
using System.Reflection;
using MultiLayer.Core.Repositories;
using MultiLayer.Core.Services;
using MultiLayer.Core.UnitOfWorks;
using MultiLayer.Repository;
using MultiLayer.Repository.Repositories;
using MultiLayer.Repository.UnitOfWorks;
using MultiLayer.Service.Mapping;
using MultiLayer.Service.Services;
using Module = Autofac.Module;

namespace MultiLayer.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            
            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
           // builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
        }
    }
}
