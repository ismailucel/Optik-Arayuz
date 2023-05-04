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
        public double Label { get; set; }
        public List<Choice>? Choices { get; set; }
    }
}
