using Microsoft.AspNetCore.Identity;
using Optik_Arayüz_UI.Data;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;
using System;
using System.Drawing.Text;
using System.Linq;

namespace Optik_Arayuz_UI.Data
{
    public class DbInitializer: IDbInitializer
    {
        private readonly OptikArayuzDbContext _db;

        public DbInitializer(OptikArayuzDbContext db)
        {
            _db = db;
        }
        public void Initialize()
        {
            

             _db.Database.EnsureCreated();

            // Look for any students.
            if (_db.Faculties.Any())
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
                _db.Faculties.Add(f);
            }
            _db.SaveChanges();

            var exampapers = new ExamPaper[]
            {
            new ExamPaper{ExamPaperName="Veri İletişimi",ExamPaperTitle="Vize"},
            new ExamPaper{ExamPaperName="Veri İletişimi",ExamPaperTitle="Final"},
            new ExamPaper{ExamPaperName="Bilgisayar Ağları",ExamPaperTitle="Vize"}
            
            };
            foreach (ExamPaper e in exampapers)
            {
                _db.ExamPapers.Add(e);
            }
            _db.SaveChanges();

           
        }

    }
}
