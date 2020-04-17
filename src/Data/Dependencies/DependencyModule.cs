using Autofac;
using Data.Repo;

namespace Data.Dependencies
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SiteContext>().As<SiteContext>();
            builder.RegisterType<UserRepo>().As<IUserRepo>().InstancePerLifetimeScope();
            builder.RegisterType<ContactRepo>().As<IContactRepo>().InstancePerLifetimeScope();
        }
    }
}