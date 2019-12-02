using System.Data.Entity;
using DirectoryFileCount.EntityFrameworkDBProvider.Migrations;
using DirectoryFileCount.EntityFrameworkDBProvider.ModelConfiguration;
using User = DirectoryFileCount.DBModels.User;

namespace DirectoryFileCount.EntityFrameworkDBProvider
{
    public class DirectoryFileCountDBContext : DbContext
    {
        public DirectoryFileCountDBContext() : base("DB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DirectoryFileCountDBContext, Configuration>());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RequestConfiguration());
        }
    }
}