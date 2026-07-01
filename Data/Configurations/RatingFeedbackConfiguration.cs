using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace markamed_api.Data.Configurations
{
    public class RatingFeedbackConfiguration : EntityBaseConfiguration<RatingFeedback>
    {
        public override void Configure(EntityTypeBuilder<RatingFeedback> builder)
        {
            base.Configure(builder);

            builder.Property(rf => rf.IsHelpful)
                .IsRequired();
            
            builder.HasOne(rf => rf.Rating)
                .WithMany(r => r.RatingFeedbacks)
                .HasForeignKey(rf => rf.RatingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}