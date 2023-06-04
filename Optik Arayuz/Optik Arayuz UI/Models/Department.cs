using Optik_Arayuz_UI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Display(Name = "Departman Adı")]
        public string? DepartmentName { get; set; }
        [Display(Name = "Departman Adresi")]
        public string? DepartmentAddress { get; set; }
        [Display(Name = "Departman Maili")]
        public string? DepartmentMail { get; set; }
        [Display(Name = "Departman Numarası")]
        public string? DepartmentPhoneNumber { get; set; }

        [ForeignKey("Faculty")]
        [Display(Name = "Fakülte Adı")]

        public int? FacultyId { get; set; }
        public virtual Faculty? Faculty { get; set; }
    }
}
