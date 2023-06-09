using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_thinhvdph26886.Configurations
{
    public class BillConfigurations : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Hóa Đơn");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.User).WithMany(y => y.Bills).HasForeignKey(x => x.UserID);
        }
    }
}
