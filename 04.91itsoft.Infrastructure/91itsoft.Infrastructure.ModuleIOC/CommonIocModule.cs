using _91itsoft.Repository.UnitOfWork;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
