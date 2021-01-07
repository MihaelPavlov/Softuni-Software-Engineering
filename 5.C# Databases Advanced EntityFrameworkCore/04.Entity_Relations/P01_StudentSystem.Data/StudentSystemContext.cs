using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
   public class StudentSystemContext :DbContext
    {

        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            :base(options)
        {

        }

        // tables

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=StudentSystem;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //student
            builder
                .Entity<Student>(entity =>
                {
                    entity
                    .HasKey(s => s.StudentId);

                    entity
                    .Property(s => s.PhoneNumber)
                    .HasColumnName("char")
                    .HasMaxLength(10)
                    .IsUnicode(false);


                 
                });

            //StudentCourses
            builder
                .Entity<StudentCourse>(entity =>
                {
                    entity
                    .HasKey(sc => new { sc.CourseId, sc.StudentId });

                    entity
                    .HasOne(s => s.Student)
                    .WithMany(c => c.CourseEnrollments)
                    .HasForeignKey(sc=>sc.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                    entity
                    .HasOne(c => c.Course)
                    .WithMany(s => s.StudentsEnrolled)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            //Homework
            builder
                .Entity<Homework>(entity =>
                {
                    entity
                    .HasKey(h => h.HomeworkId);

                    entity
                    .Property(h => h.Content).IsUnicode(false);

                    entity
                    .HasOne(h => h.Course)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(h => h.CourseId);

                    entity
                    .HasOne(s => s.Student)
                    .WithMany(h => h.HomeworkSubmissions)
                    .HasForeignKey(f => f.StudentId);
                });

            //course 
            builder
                .Entity<Course>(entity =>
                {
                    entity
                    .HasKey(c => c.CourseId);

                });




            //Resource
            builder
                .Entity<Resource>(entity =>
                {
                    entity
                    .HasKey(r => r.ResourceId);

                    entity
                    .Property(r => r.Url).IsUnicode(false);

                    entity
                     .HasOne(r => r.Course)
                     .WithMany(r => r.Resources)
                     .HasForeignKey(r => r.CourseId);
                });
                
                
        }
    }
}
