using System.Data.Entity.ModelConfiguration;
using DirectoryFileCount.DBModels;

namespace DirectoryFileCount.EntityFrameworkDBProvider.ModelConfiguration
{
    class RequestConfiguration : EntityTypeConfiguration<Request>
    {
        public RequestConfiguration()
        {
            ToTable("Request");
            HasKey(d => d.Guid);
            Property(d => d.Guid).HasColumnName("Id").IsRequired();
            Property(d => d.PathToFolder).HasColumnName("PathToFolder").IsRequired();
            Property(d => d.QuantityOfFiles).HasColumnName("QuantityOfFiles").IsRequired();
            Property(d => d.QuantityOfFiles).HasColumnName("QuantityOfSubFolders").IsRequired();
            Property(d => d.DateOfRequest).HasColumnName("DateOfRequest").HasColumnType("datetime2").IsRequired();
        }
    }
}