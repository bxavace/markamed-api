using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace markamed_api.Data.Configurations
{
    public class FacilityConfiguration : EntityBaseConfiguration<Facility>
    {
        public override void Configure(EntityTypeBuilder<Facility> builder)
        {
            base.Configure(builder);

            builder.Property(f => f.Code)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(f => f.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(f => f.FacilityMajorType)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.FacilityType)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(f => f.OwnershipMajorClassification)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(f => f.OwnershipSubClassification)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(f => f.StreetName)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(f => f.BuildingName)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(f => f.Region)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(f => f.Province)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(f => f.City)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(f => f.Barangay)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(f => f.ZipCode)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(f => f.LandlineNumber)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(f => f.LandlineNumber2)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(f => f.FaxNumber)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(f => f.EmailAddress)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(f => f.AlternateEmailAddress)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(f => f.Website)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(f => f.ServiceCapability)
                .HasMaxLength(255)
                .IsRequired(false);
            
            builder.Property(f => f.BedCapacity)
                .HasMaxLength(50)
                .IsRequired(false);
            
            builder.Property(f => f.LicenseStatus)
                .HasMaxLength(50)
                .IsRequired(false);
            
            builder.Property(f => f.LicenseNumber)
                .HasMaxLength(50)
                .IsRequired(false);
            
            builder.Property(f => f.LicenseDateIssued)
                .HasMaxLength(50)
                .IsRequired(false);
        }
    }
}