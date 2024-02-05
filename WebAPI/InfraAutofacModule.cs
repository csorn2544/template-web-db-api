using Autofac;
using System.Reflection;
using WebAPI.Models.IRepositories;
using WebAPI.Repositories.Base;
using Module = Autofac.Module;

namespace WebAPI
{
    public class InfraAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register infrastructure module
            builder.RegisterModule<ApplicationAutofacModule>();

            // Register all implementations within the current assembly
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                //.Except<IHealthCheck>(e => e.InstancePerLifetimeScope().AsImplementedInterfaces())
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(BaseRepository<,>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(QueryRepository<,>)).As(typeof(IQueryRepository<>)).InstancePerLifetimeScope();
        }
    }

}
