using Optik_Arayuz_UI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentAddress { get; set; }
        public string? DepartmentMail { get; set; }
        public string? DepartmentPhoneNumber { get; set; }

        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public virtual Faculty? Faculty { get; set; }
    }
}
