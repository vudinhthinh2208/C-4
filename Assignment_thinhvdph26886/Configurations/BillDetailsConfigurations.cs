using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_thinhvdph26886.Configurations
{
    public class BillDetailsConfigurations : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.ToTable("Hóa Đơn Chi Tiết");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Price).HasColumnType("int").IsRequired();
            builder.Property(p => p.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.IdSP).HasColumnType("UNIQUEIDENTIFIER");
            builder.Property(x => x.IdHD).HasColumnType("UNIQUEIDENTIFIER");

            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).HasForeignKey(x => x.IdHD);
            builder.HasOne(x => x.Product).WithMany(y => y.BillDetails).HasForeignKey(x => x.IdSP);
        }
    }
}
