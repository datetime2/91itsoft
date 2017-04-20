using System.Data.Entity;
using ITsoft.Infrastructure.Repository.Migrations;
using ITsoft.Repository.UnitOfWork;

namespace ITsoft.Repository.Initializer
{
    public static class DbInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            // 初始化时使用
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TSoftUnitOfWork, Configuration>());
            // 运行时使用
            Database.SetInitializer<TSoftUnitOfWork>(null);
        }
    }
}