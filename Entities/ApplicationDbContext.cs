using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }


        public DbSet<Project>? Projects { get; set; }
        public DbSet<Images>? Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Images>()
                .HasOne(img => img.Project)
                .WithMany(proj => proj.Images)
                .HasForeignKey(img => img.ProjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
