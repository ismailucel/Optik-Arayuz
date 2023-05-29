﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(OptikArayuzDbContext db,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
        }
        public void Initialize()
        {

             _db.Database.EnsureCreated();

            // Look for any students.
            if (!_db.Faculties.Any())
            {
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
            }

  
            if (_db.Roles.Any(r => r.Name == "Admin")) return;
            _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();



        }

    }
}
