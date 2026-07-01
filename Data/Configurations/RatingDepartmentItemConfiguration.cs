using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace markamed_api.Data.Configurations
{
    public class RatingDepartmentItemConfiguration : EntityBaseConfiguration<RatingDepartmentItem>
    {
        public override void Configure(EntityTypeBuilder<RatingDepartmentItem> builder)
        {
            base.Configure(builder);

            builder.Property(rai => rai.RatingId)
                .IsRequired();

            builder.Property(rai => rai.RatingDepartmentId)
                .IsRequired();

            builder.Property(rai => rai.Score)
                .IsRequired();

            builder.HasOne(rai => rai.Rating)
                .WithMany(r => r.RatingDepartmentItems)
                .HasForeignKey(rai => rai.RatingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}