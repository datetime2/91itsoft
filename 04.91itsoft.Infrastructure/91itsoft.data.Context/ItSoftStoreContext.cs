using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using _91itsoft.Data.Context.Config;
//using _91itsoft.Data.Context.Mapping;
//using _91itsoft.Domain.Entities;

namespace _91itsoft.Data.Context
{
    public class ItSoftStoreContext : BaseDbContext
    {
        static ItSoftStoreContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public ItSoftStoreContext()
            : base("ITSoftStoreEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new GenreMap());
        }
  
        #region DbSet

        #endregion
    }
}