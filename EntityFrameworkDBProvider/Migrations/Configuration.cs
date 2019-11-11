using System.Data.Entity.Migrations;

namespace DirectoryFileCount.EntityFrameworkDBProvider.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DirectoryFileCountDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DirectoryFileCountDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}