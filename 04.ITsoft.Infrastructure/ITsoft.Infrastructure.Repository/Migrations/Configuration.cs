namespace ITsoft.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Utility;
    using Utility.Helper;

    internal sealed class Configuration : DbMigrationsConfiguration<ITsoft.Repository.UnitOfWork.TSoftUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ITsoft.Repository.UnitOfWork.TSoftUnitOfWork context)
        {
            string salt = Guid.NewGuid().ToString();
            context.Users.Add(new Domain.Aggregates.User
            {
                Id = Entity.IdentityGenerator.NewSequentialGuid(),
                Name = "π‹¿Ì‘±",
                LoginName = "admin",
                LoginPwd = SecurityHelper.Md5(SecurityHelper.Md5("123456")+ salt),
                Created = DateTime.UtcNow,
                LastLogin = Const.SqlServerNullDateTime,
                PwdSalt= salt
            });
        }
    }
}
