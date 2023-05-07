using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class ExamPaper
    {
        [Key]
        public int ExamPaperId { get; set; }
        public string? ExamPaperName { get; set; }
        public string? ExamPaperTitle { get; set; }
    }
}
