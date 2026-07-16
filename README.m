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
