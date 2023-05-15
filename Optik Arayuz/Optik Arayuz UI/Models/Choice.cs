using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        public int ChoiceCount { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
        public string? Label { get; set; }
        public string? Choices { get; set; }
    }
}
