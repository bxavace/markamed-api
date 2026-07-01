using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markamed_api.Data.Configurations
{
    public class RatingDepartmentConfiguration : EntityBaseConfiguration<RatingDepartment>
    {
        public override void Configure(EntityTypeBuilder<RatingDepartment> builder)
        {
            base.Configure(builder);

            builder.Property(rd => rd.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(rd => rd.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(rd => rd.Description)
                .HasMaxLength(1000)
                .IsRequired(false);
        }
    }
}