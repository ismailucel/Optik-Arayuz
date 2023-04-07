using Microsoft.EntityFrameworkCore;
using Optik_Arayüz_UI.Models;

namespace Optik_Arayüz_UI.Data
{
    public class OptikArayuzDbContext: DbContext
    {
        public OptikArayuzDbContext(DbContextOptions<OptikArayuzDbContext> options) : base(options)
        {

        }

        public DbSet<ExamPaperElement> ExamPaperElements { get; set; }
        public DbSet<User> Users { get; set; }
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
