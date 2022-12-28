using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        { }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        { }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(builder =>
            {
                builder.Property(p => p.Name).IsUnicode(true);
                builder.Property(p => p.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<Course>(builder =>
            {
                builder.Property(p => p.Name).IsUnicode(true);
                builder.Property(p => p.Description).IsUnicode(true);
            });

            modelBuilder.Entity<Resource>(builder =>
            {
                builder.Property(p => p.Name).IsUnicode(true);
                builder.Property(p => p.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(builder =>
            {
                builder.Property(p => p.Content).IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(builder =>
            {
                builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

                builder.HasOne(sc => sc.Student)
                    .WithMany(sc => sc.CourseEnrollments)
                    .HasForeignKey(sc => sc.StudentId);

                builder.HasOne(sc => sc.Course)
                    .WithMany(sc => sc.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
