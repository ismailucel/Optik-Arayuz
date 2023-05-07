using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public int QuestionCount { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; } 
    }
}
