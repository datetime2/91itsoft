using _91itsoft.ModuleIOC;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Mvc;
namespace _91itsoft.PlatSystem
{
    public class AutofacConfig
    {
        public static IContainer Container { get; private set; }
        public static void Config()
        {
            var builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterApiControllers(executingAssembly).InstancePerRequest();//注册api容器的实现
            builder.RegisterControllers(executingAssembly).InstancePerRequest();//注册mvc容器的实现
            builder.RegisterModelBinderProvider();
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            // 系统定义的模块
            builder.RegisterModule<CommonIocModule>();
            builder.RegisterModule<SystemModule>();
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));//注册mvc容器
        }
    }
}