using System.ComponentModel.DataAnnotations;

namespace Optik_Arayüz_UI.Models
{
    public class Logo
    {
        [Key]
        public int LogoId { get; set; }
        public int ImagePath { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
    }
}
