using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        [Display(Name = "Duyuru Başlığı")]
        public string? AnnouncementName { get; set; }
        [Display(Name = "İçerik")]
        public string? AnnouncementContent { get; set; }
        [Display(Name = "Oluşturma Tarihi")]
        public string? AnnouncementDate { get; set; }
        [ForeignKey("User")]
        [Display(Name = "Oluşturan Kişi")]
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
