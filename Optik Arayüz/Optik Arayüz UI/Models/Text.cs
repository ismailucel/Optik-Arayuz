using System.ComponentModel.DataAnnotations;

namespace Optik_Arayüz_UI.Models
{
    public class Text
    {
        [Key]
        public int TextId { get; set; }
        public string? TextContent { get; set; }
        public int FontSize { get; set; }
        public string? FontType { get; set; }

    }
}
