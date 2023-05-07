using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Optik_Arayuz_UI.Models;

namespace Optik_Arayuz_UI.Data
{
    public class OptikArayuzDbContext: IdentityDbContext
    {
        public OptikArayuzDbContext(DbContextOptions<OptikArayuzDbContext> options) : base(options)
        {

        }

        public DbSet<ExamPaperElement> ExamPaperElements { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ExamPaper> ExamPapers { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Test> Tests { get; set; }


    }
}
