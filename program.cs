s--structure--------
P01_StudentSystem
├── Data
│ └── StudentSystemContext.cs
├── Models
│ ├── Student.cs
│ ├── Course.cs
│ ├── Resource.cs
│ ├── HomeworkSubmission.cs
│ ├── StudentCourse.cs
│ └── Enums.cs
└── Program.cs
-------------------models/enums
namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }

    public enum ContentType
    {
        Application,
        Pdf,
        Zip
    }
}
---------------student/model
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(10, MinimumLength = 10)]
        [Column(TypeName = "char(10)")]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
        public virtual ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }
    }
}
-----------------corsmodel-----------
    using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }
    }
}
----------------------resors/model-------
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
---------------homework/model-----------
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Models
{
    public class HomeworkSubmission
    {
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
----------------studentcours/model
namespace P01_StudentSystem.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public virtual Student { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
-----------studentsystem-------------
    using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentSystemDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
              .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
---------------------
------------------------studentsystem-----
Add-Migration InitialCreate
Update-Database
