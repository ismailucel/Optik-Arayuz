using System.ComponentModel.DataAnnotations;

namespace Optik_Arayuz_UI.Models
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
