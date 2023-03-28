using System.ComponentModel.DataAnnotations;

namespace Optik_Arayüz_UI.Models
{
    public class Student
    {
        [Key] 
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? CourseName { get; set; }
        public double XLength { get; set; }
        public double YLength { get; set; }
    }
}
