using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace markamed_api.Data.Configurations
{
    public class RatingConfiguration : EntityBaseConfiguration<Rating>
    {
        public override void Configure(EntityTypeBuilder<Rating> builder)
        {
            base.Configure(builder);

            builder.Property(r => r.Review)
                .HasMaxLength(1000)
                .IsRequired(false);
            
            builder.HasOne(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(r => r.Facility)
                .WithMany(f => f.Ratings)
                .HasForeignKey(r => r.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.RatingAttribute)
                .WithMany(ra => ra.Ratings)
                .HasForeignKey(r => r.RatingAttributeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}