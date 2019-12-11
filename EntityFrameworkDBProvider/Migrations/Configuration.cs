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
     
        }
    }
}