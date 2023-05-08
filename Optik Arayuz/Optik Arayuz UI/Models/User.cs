﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Optik_Arayuz_UI.Models
{
    public class User: IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Address { get; set;}

        public string? Role { get; set; }

        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public virtual Faculty? Faculty { get; set; }
    }
}