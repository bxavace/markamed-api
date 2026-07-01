using markamed_api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using markamed_api.Data.Configurations;

namespace markamed_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RatingDepartment> RatingDepartments { get; set; }
        public DbSet<RatingAttribute> RatingAttributes { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            string currentUser = "System"; // TODO: Get current user
            DateTimeOffset now = DateTimeOffset.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is EntityBase entityBase)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entityBase.DateCreated = now;
                            entityBase.CreatedBy = currentUser;
                            break;
                        case EntityState.Modified:
                            entityBase.DateUpdated = now;
                            entityBase.UpdatedBy = currentUser;
                            break;
                        case EntityState.Deleted:
                            entityBase.IsDeleted = true;
                            entityBase.DateDeleted = now;
                            entityBase.DeletedBy = currentUser;
                            entry.State = EntityState.Modified; // Mark as modified instead of deleted
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FacilityConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new RatingDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new RatingAttributeConfiguration());
            modelBuilder.ApplyConfiguration(new RatingFeedbackConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rating>()
                .HasQueryFilter(r => !r.IsDeleted);

            modelBuilder.Entity<Facility>()
                .HasQueryFilter(f => !f.IsDeleted);
        }
    }
}