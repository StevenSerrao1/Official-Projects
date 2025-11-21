using Microsoft.EntityFrameworkCore;

namespace MyPortfolioSolution.Entities1
{
    // Represents the application's database context
    public class ApplicationDbContext : DbContext
    {
        // DbSets represent the tables in the database.
        public DbSet<Project>? Projects { get; set; }   // Represents the Projects table
        public DbSet<Images>? Images { get; set; }     // Represents the Images table

        // Constructor that accepts DbContextOptions for configuration
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Configures the model relationships and seeds the database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship between Project and Images
            modelBuilder.Entity<Images>()
                .HasOne(img => img.Project)    // Each Image is associated with one Project
                .WithMany(proj => proj.Images) // Each Project can have many Images
                .HasForeignKey(img => img.ProjectId);  // The foreign key is ProjectId in Images table

            // Seed data for the Projects table (uncomment to enable)
            modelBuilder.Entity<Project>()
                .HasData(
                // Example seed data (uncomment to enable)
                //new Project
                //{
                //    ProjectId = 1,
                //    Title = "Full-Stack Development Portfolio",
                //    Description = "My professional portfolio, showcasing my projects with entries ranging from personal projects to commercial projects. All projects use a variety of tech stacks, with a primary focus throughout on ASP.NET Core, which is my specialty.",
                //    ProjectURL = "localhost:3000",
                //    DateCreated = new DateTimeOffset(DateTime.Parse("2024/12/20"), TimeSpan.Zero),
                //    GitHubRepoName = "Official-Projects"
                //}
                );

            // Seed data for the Images table (uncomment to enable)
            modelBuilder.Entity<Images>()
                .HasData(
                // Example seed data for images (uncomment to enable)
                //new Images
                //{
                //    ImageId = 1,
                //    ImageUrl = "https://content.swncdn.com/godvine/pics/GV-Article/dogsmiles-1.jpg",
                //    Caption = "a very, very good boy.",
                //    AltText = "smiling dog",
                //    ProjectId = 1
                //}
                );

            // Call the base method to ensure any further model configuration is applied
            base.OnModelCreating(modelBuilder);
        }
    }
}
