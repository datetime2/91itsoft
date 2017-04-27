using ITsoft.Domain.Aggregates;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ITsoft.Repository.UnitOfWork
{
    public class TSoftUnitOfWork : DbContext, ITSoftUnitOfWork
    {
        public TSoftUnitOfWork()
            : base("91ITSoft")
        {
            Initializer.DbInitializer.Initialize();
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Menu>().HasMany(x => x.Permissions).WithRequired(x => x.Menu);
            mb.Entity<User>().HasMany(x => x.Roles).WithMany(x => x.Users).Map(x => x.MapLeftKey("UserId").MapRightKey("RoleId").ToTable("UserRole"));
            mb.Entity<Role>().Property(s => s.Name).HasMaxLength(50);
            mb.Entity<Role>().HasMany(x => x.Permissions).WithMany(x => x.Roles).Map(x => x.MapLeftKey("RoleId").MapRightKey("PermissionId").ToTable("RolePermission"));
        }

        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            //if not is attached, attach original and set current values
            base.Entry<TEntity>(original).CurrentValues.SetValues(current);
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        public IDbSet<TEntity> CreateSet<TEntity>()
           where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                        .ForEach(entry => entry.OriginalValues.SetValues(entry.GetDatabaseValues()));

                }
            } while (saveFailed);
        }

        public void RollbackChanges()
        {
            base.ChangeTracker.Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}
