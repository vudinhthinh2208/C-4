using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment_thinhvdph26886.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("NguoiDung");
            builder.HasKey(p => p.UserID);
            builder.Property(x => x.Username).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Role).HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int");

            builder.HasOne(x => x.Roles).WithMany(x => x.Users).HasForeignKey(x => x.Role);
        }
    }
}
