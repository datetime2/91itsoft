using _91itsoft.Application.Managers;
using _91itsoft.Application.Services;
using _91itsoft.Domain.Aggregates.UserAgg;
using _91itsoft.Infrastructure.Authorize;
using _91itsoft.Repository.Repositories;
using _91itsoft.Repository.UnitOfWork;
using Autofac;
namespace _91itsoft.ModuleIOC
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
