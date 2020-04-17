using Autofac;

namespace Site.Dependencies
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<Data.Dependencies.DependencyModule>();
        }
    }
}