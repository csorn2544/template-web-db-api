using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace WebAPI
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register all implementations within the current assembly
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            // Register application module
            builder.RegisterModule<InfraAutofacModule>();
        }
    }
}
