using Optik_Arayüz_UI.Data;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;
using System;
using System.Linq;

namespace Optik_Arayuz_UI.Data
{
    public class DbInitializer: IDbInitializer
    {
        public void Initialize(OptikArayuzDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Faculties.Any())
            {
                return;   // DB has been seeded
            }

            var faculties = new Faculty[]
            {
            new Faculty{
                FacultyName = "Bilgisayar ve Bilişim Bilimleri Fakültesi",
                FacultyAddress = "Sakarya Üniversitesi Bilgisayar ve Bilişim Bilimleri Fakültesi, 54187 Sakarya",
                FacultyMail = "bf@sakarya.edu.tr",
                FacultyPhoneNumber = "+90 (264) 295 69 79"
            },
            new Faculty{
                FacultyName = "Mühendislik Fakültesi",
                FacultyAddress = "Sakarya Üniversitesi Mühendislik Fakültesi, Esentepe Kampüsü Serdivan/Adapazarı/Sakarya",
                FacultyMail = "mf@sakarya.edu.tr",
                FacultyPhoneNumber = " 0 (264) 295 56 01"
            },

            };
            foreach (Faculty f in faculties)
            {
                context.Faculties.Add(f);
            }
            context.SaveChanges();

            var exampapers = new ExamPaper[]
            {
            new ExamPaper{ExamPaperName="Veri İletişimi",ExamPaperTitle="Vize"},
            new ExamPaper{ExamPaperName="Veri İletişimi",ExamPaperTitle="Final"},
            new ExamPaper{ExamPaperName="Bilgisayar Ağları",ExamPaperTitle="Vize"}
            
            };
            foreach (ExamPaper e in exampapers)
            {
                context.ExamPapers.Add(e);
            }
            context.SaveChanges();

           
        }

    }
}
