using _91itsoft.Application.Services;
using _91itsoft.Domain.Aggregates.MenuAgg;
using _91itsoft.Domain.Aggregates.RoleAgg;
using _91itsoft.Domain.Aggregates.RoleGroupAgg;
using _91itsoft.Domain.Aggregates.UserAgg;
using _91itsoft.Repository.Repositories;
using Autofac;
namespace _91itsoft.ModuleIOC
{
    public class SystemModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MenuRepository>().As<IMenuRepository>().InstancePerRequest();
            builder.RegisterType<PermissionRepository>().As<IPermissionRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
            builder.RegisterType<RoleGroupRepository>().As<IRoleGroupRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<RoleGroupService>().As<IRoleGroupService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}