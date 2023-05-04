using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Number
    {
        [Key]
        public int NumberId { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
        public double Length { get; set; }
        public double Label { get; set; }
    }
}
