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
