using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentAPI.Model;

namespace FluentAPI.Data
{
    public class FluentAPIContext : DbContext
    {
        public FluentAPIContext (DbContextOptions<FluentAPIContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Email).IsRequired();
                entity.HasIndex(s => s.Email).IsUnique();
                entity.Property(s => s.Age).IsRequired();
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Courses");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Title).IsRequired().HasMaxLength(200);
                entity.Property(c => c.Credits).IsRequired();
            });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourses",
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId")
                );
        }

        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
    }
}
