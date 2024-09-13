using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _NET_Core.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Model.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Stocks> Stock { get; set; }

        public DbSet<Comment> comments{get; set;}

        public DbSet<Portfolio> Portfolios {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new{p.AppUserId, p.stockId}));

            builder.Entity<Portfolio>()
            .HasOne(u => u.appUser)
            .WithMany(u=>u.Portfolios)
            .HasForeignKey(u=>u.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(u => u.stocks)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.stockId);

            List<IdentityRole> identityRoles = new List<IdentityRole>{
               new IdentityRole{
                 Name = "Admin",
                 NormalizedName = "Admin"
               },

               new IdentityRole{
                Name = "User",
                NormalizedName = "User"
               }
            };

            builder.Entity<IdentityRole>().HasData(identityRoles);
        }
    }
}