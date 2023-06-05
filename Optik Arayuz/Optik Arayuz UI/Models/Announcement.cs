using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string? AnnouncementName { get; set; }
        public string? AnnouncementContent { get; set; }
        public string? AnnouncementDate { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
