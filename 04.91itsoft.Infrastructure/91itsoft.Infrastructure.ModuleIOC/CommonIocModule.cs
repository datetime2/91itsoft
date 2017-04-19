using _91itsoft.Repository.UnitOfWork;
using Autofac;

namespace _91itsoft.ModuleIOC
{
    public class CommonIocModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TSoftUnitOfWork>().As<ITSoftUnitOfWork>().InstancePerRequest();
        }
    }
}
