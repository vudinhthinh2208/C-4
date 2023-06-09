using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace Assignment_thinhvdph26886.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Vai Trò");
            builder.HasKey(x => x.RoleID);
            builder.Property(x => x.RoleName).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(1000)").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
        }
    }
}
