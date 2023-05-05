using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Optik_Arayuz_UI.Data;
using Optik_Arayuz_UI.Models;

namespace Optik_Arayüz_UI.Data
{
    public interface IDbInitializer
    {
        void Initialize(OptikArayuzDbContext context);
    }
}
