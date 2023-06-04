using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        [Display(Name = "Fakülte Adı")]
        public string? FacultyName { get; set; }
        [Display(Name = "Fakülte Adresi")]
        public string? FacultyAddress { get; set; }
        [Display(Name = "Fakülte Maili")]
        public string? FacultyMail { get; set; }
        [Display(Name = "Fakülte Numarası")]
        public string? FacultyPhoneNumber { get; set; }

    }
}
