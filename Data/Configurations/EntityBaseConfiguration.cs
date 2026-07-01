using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markamed_api.Data.Configurations
{
    public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(e => e.DeletedBy)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(e => e.DateCreated)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();
            
            builder.Property(e => e.DateUpdated)
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired(false);
            
            builder.Property(e => e.DateDeleted)
                .IsRequired(false);
        }
    }
}