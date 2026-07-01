using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace markamed_api.Data.Configurations
{
    public class RatingAttributeConfiguration : EntityBaseConfiguration<RatingAttribute>
    {
        public override void Configure(EntityTypeBuilder<RatingAttribute> builder)
        {
            base.Configure(builder);

            builder.Property(ra => ra.Name)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(ra => ra.Category)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(ra => ra.IsActive)
                .HasDefaultValue(true)
                .IsRequired();
            
            builder.Property(ra => ra.SortOrder)
                .HasDefaultValue(0)
                .IsRequired();
        }
    }
}