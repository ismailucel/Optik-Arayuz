using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [Display(Name = "Sınav Adı")]
        public string? ExamName { get; set; }
        [Display(Name = "Test Sayısı")]
        public int TestCount { get; set; }
        [Display(Name = "Klasik Sayısı")]
        public int ClassicCount { get; set; }
        [Display(Name = "Sınav Kağıdı")]
        [ForeignKey("ExamPaper")]
        public int ExamPaperId { get; set; }
        public ExamPaper? ExamPaper { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
