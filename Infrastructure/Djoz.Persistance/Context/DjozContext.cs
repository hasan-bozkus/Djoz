using Djoz.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djoz.Persistance.Context
{
    public class DjozContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3JI56T6\\SQLEXPRESS; initial catalog=DjozJWTMusicDb; integrated security=true; TrustServerCertificate=true;Connection Timeout=30;");
        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<CountDown> CountDowns { get; set; }
        public DbSet<DjInfo> DjInfos { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
