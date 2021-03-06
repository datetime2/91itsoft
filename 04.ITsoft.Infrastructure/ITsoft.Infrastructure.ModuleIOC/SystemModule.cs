﻿using ITsoft.Application.Services;
using ITsoft.Domain.IRepository;
using ITsoft.Repository.Repositories;
using Autofac;
namespace ITsoft.ModuleIOC
{
    public class SystemModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Repository
            builder.RegisterType<MenuRepository>().As<IMenuRepository>().InstancePerRequest();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            //Services
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
        }
    }
}