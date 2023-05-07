using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        public string? FacultyName { get; set; }
        public string? FacultyAddress { get; set; }
        public string? FacultyMail { get; set; }
        public string? FacultyPhoneNumber { get; set; }

    }
}
