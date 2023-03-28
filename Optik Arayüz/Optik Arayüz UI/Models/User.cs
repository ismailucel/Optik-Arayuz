using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayüz_UI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set;}
        public string? PhoneNumber  { get; set; }
        public string? Role { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
    }
}
