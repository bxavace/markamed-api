using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace markamed_api.Data.Configurations
{
    public class RatingAttributeItemConfiguration : EntityBaseConfiguration<RatingAttributeItem>
    {
        public override void Configure(EntityTypeBuilder<RatingAttributeItem> builder)
        {
            base.Configure(builder);

            builder.Property(rai => rai.RatingId)
                .IsRequired();

            builder.Property(rai => rai.RatingAttributeId)
                .IsRequired();

            builder.Property(rai => rai.Score)
                .IsRequired();

            builder.HasOne(rai => rai.Rating)
                .WithMany(r => r.RatingAttributeItems)
                .HasForeignKey(rai => rai.RatingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}