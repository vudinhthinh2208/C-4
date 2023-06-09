using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_thinhvdph26886.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Sản Phẩm");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Name).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.Price).HasColumnType("int").IsRequired();
            builder.Property(p => p.AvailableQuantity).HasColumnType("int").IsRequired();
            builder.Property(p => p.Status).HasColumnType("int").IsRequired();
            builder.Property(p => p.Supplier).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(p => p.Color).HasColumnType("nvarchar(1000)").IsRequired();
        }
    }
}
