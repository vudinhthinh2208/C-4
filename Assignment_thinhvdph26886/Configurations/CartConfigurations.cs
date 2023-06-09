using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_thinhvdph26886.Configurations
{
    public class CartConfigurations : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Giỏ Hàng");
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.Description).HasColumnType("nvarchar(1000)");
        }
    }
}
