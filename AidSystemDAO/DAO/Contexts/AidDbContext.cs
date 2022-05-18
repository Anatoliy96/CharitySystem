using AidSystemDAL.Models;
using AidSystemDAL.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidSystemDAL.Contexts
{
    public class AidDbContext : IdentityDbContext<ApplicationUser>
    {
        public AidDbContext(DbContextOptions<AidDbContext> options)
            : base(options)
        {

        }

        public AidDbContext()
            : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7TAP9Q7\\SQLEXPRESS; Database=AidSystemDb;Trusted_Connection=True;",
                b => b.MigrationsAssembly("AidSystem"));
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MemberActivity> memberActivities { get; set; }
    }
}
