using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Logo
    {
        [Key]
        public int LogoId { get; set; }
        public string? ImagePath { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
    }
}
