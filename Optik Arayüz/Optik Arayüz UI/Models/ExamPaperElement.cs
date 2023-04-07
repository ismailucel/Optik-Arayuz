using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayüz_UI.Models
{
    public class ExamPaperElement
    {
        [Key]
        public int ExamPaperElementId { get; set; }
        public string? Type { get; set; }
        public double X { get; set; }   
        public double Y { get; set; }
        [ForeignKey("ExamPaper")]
        public int ExamPaperId { get; set; }
        public virtual ExamPaper? ExamPaper { get; set; }
    }
}
