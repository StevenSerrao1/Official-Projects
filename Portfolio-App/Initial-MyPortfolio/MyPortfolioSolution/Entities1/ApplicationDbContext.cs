﻿using Microsoft.EntityFrameworkCore;

namespace MyPortfolioSolution.Entities1
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Project>? Projects { get; set; }
        public DbSet<Images>? Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Images>()
                .HasOne(img => img.Project)
                .WithMany(proj => proj.Images)
                .HasForeignKey(img => img.ProjectId);

            // ADD SEED DATA FOR PORTFOLIO HERE
            modelBuilder.Entity<Project>()
                .HasData(
                    new Project
                    {
                        ProjectId = 1,
                        Title = "Full-Stack Development Portfolio",
                        Description = "My professional portfolio, showcasing my projects with entries ranging from personal projects to commercial projects. All projects use a variety of tech stacks, with a primary focus throughout on ASP.NET Core, which is my specialty.",
                        ProjectURL = "localhost:3000",
                        DateCreated = new DateTimeOffset(DateTime.Parse("2024/12/20"), TimeSpan.Zero),
                        GitHubViews = 0
                    }
                );

            // Seed Images separately, with ProjectId foreign key
            modelBuilder.Entity<Images>()
                .HasData(
                    new Images
                    {
                        ImageId = 1,
                        ImageUrl = "https://farm4.staticflickr.com/3256/2594247316_85bcbfdeb1_o_d.jpg",
                        Caption = "a very, very good boy.",
                        AltText = "smiling dog",
                        ProjectId = 1
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
