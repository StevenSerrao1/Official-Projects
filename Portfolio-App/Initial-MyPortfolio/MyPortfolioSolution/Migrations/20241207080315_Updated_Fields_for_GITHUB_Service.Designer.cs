﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPortfolioSolution.Entities1;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyPortfolioSolution.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241207080315_Updated_Fields_for_GITHUB_Service")]
    partial class Updated_Fields_for_GITHUB_Service
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyPortfolioSolution.Entities1.Images", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ImageId"));

                    b.Property<string>("AltText")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("character varying(600)");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.HasKey("ImageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageId = 1,
                            AltText = "smiling dog",
                            Caption = "a very, very good boy.",
                            ImageUrl = "https://content.swncdn.com/godvine/pics/GV-Article/dogsmiles-1.jpg",
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("MyPortfolioSolution.Entities1.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProjectId"));

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<string>("GitHubRepoName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GitHubViews")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProjectURL")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            DateCreated = new DateTimeOffset(new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "My professional portfolio, showcasing my projects with entries ranging from personal projects to commercial projects. All projects use a variety of tech stacks, with a primary focus throughout on ASP.NET Core, which is my specialty.",
                            GitHubRepoName = "",
                            GitHubViews = "0",
                            ProjectURL = "localhost:3000",
                            Title = "Full-Stack Development Portfolio"
                        });
                });

            modelBuilder.Entity("MyPortfolioSolution.Entities1.Images", b =>
                {
                    b.HasOne("MyPortfolioSolution.Entities1.Project", "Project")
                        .WithMany("Images")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("MyPortfolioSolution.Entities1.Project", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
