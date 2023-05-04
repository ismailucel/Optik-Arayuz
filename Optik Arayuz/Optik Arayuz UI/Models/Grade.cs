using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
        public int QuestionCount { get; set; }
    }
}
