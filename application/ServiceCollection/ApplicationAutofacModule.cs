using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;
using Module = Autofac.Module;
using application.Behaviours;

namespace application
{
    public class ApplicationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = MediatRConfigurationBuilder
                .Create(Assembly.GetExecutingAssembly())
                .WithAllOpenGenericHandlerTypesRegistered()
                .WithRegistrationScope(RegistrationScope.Scoped)
                .WithCustomPipelineBehaviors(new[]
                {
              typeof(UnhandledExceptionBehaviour<,>),
              typeof(ValidationBehaviour<,>)
                }).Build();
            builder.RegisterMediatR(configuration);
        }
    }

}
