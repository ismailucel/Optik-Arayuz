using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class ExamPaper
    {
        [Key]
        public int ExamPaperId { get; set; }

        [Display(Name = "Sınav Kağıdı Adı")]
        public string? ExamPaperName { get; set; }
        [Display(Name = "Sınav Kağıdı Başlık")]
        public string? ExamPaperTitle { get; set; }
    }
}
