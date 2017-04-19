namespace _91itsoft.Repository.Migrations
{
    using System.Data.Entity.Migrations;
    internal sealed class Configuration : DbMigrationsConfiguration<UnitOfWork.TSoftUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            //AutomaticMigrationsEnabled = false;
            //ContextKey = "_91itsoft.Repository.UnitOfWork.TSoftUnitOfWork";
        }
        protected override void Seed(UnitOfWork.TSoftUnitOfWork context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
