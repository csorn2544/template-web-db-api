using application;
using Autofac;
using domain.IRepositories;
using infra.Repositories.Base;
using System.Reflection;

using Module = Autofac.Module;

namespace infra.ServiceCollection
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
