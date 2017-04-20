using ITsoft.Application.Managers;
using ITsoft.Infrastructure.Authorize;
using ITsoft.Repository.UnitOfWork;
using Autofac;
namespace ITsoft.ModuleIOC
{
    public class CommonIocModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TSoftUnitOfWork>().As<ITSoftUnitOfWork>().InstancePerRequest();
            builder.RegisterType<AuthorizeManager>().As<IAuthorizeManager>().InstancePerRequest();
            //builder.RegisterType<AuthorizeFilter>().PropertiesAutowired();
        }
    }
}
