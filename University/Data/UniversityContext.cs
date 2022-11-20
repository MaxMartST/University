using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using University.Models;

namespace University.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");
                entity.HasKey(e => e.Id).HasName("PK_Course_Course_Id");
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasColumnName("Course_Id");
                entity.Property(e => e.Credits).IsRequired().HasColumnName("Credits");
                entity.HasMany<Enrollment>(e => e.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");
                entity.HasKey(e => e.Id).HasName("PK_Enrollment_Enrollment_Id");
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasColumnName("Enrollment_Id");
                entity.Property(e => e.CourseId).IsRequired().HasColumnName("Course_Id");
                entity.Property(e => e.StudentId).IsRequired().HasColumnName("Student_Id");
                entity.Property(e => e.Grade).HasColumnName("Grade");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e => e.Id).HasName("PK_Student_Student_Id");
                entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd().HasColumnName("Student_Id");
                entity.Property(e => e.LastName).IsRequired().HasColumnName("Last_Name");
                entity.Property(e => e.FirstMidName).IsRequired().HasColumnName("First_Mid_Name");
                entity.Property(e => e.EnrollmentDate).IsRequired().HasColumnName("Enrollment_Date");
            });
        }
    }
}
