using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        public string? ExamName { get; set; }
        public int TestCount { get; set; }
        public int ClassicCount { get; set; }
        [ForeignKey("ExamPaper")]
        public int ExamPaperId { get; set; }
        public ExamPaper? ExamPaper { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
