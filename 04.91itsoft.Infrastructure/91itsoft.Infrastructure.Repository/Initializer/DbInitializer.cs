using System.Data.Entity;
using _91itsoft.Repository.Migrations;
using _91itsoft.Repository.UnitOfWork;

namespace _91itsoft.Repository.Initializer
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