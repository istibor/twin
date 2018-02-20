using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using twin.Models;

namespace twin.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<UserData> UserDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("AspNetUsers")
                .HasOne(u => u.UserData)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserData>(ud => ud.UserForeignKey);

            modelBuilder.Entity<UserData>().ToTable("UserDatas");

            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("AspNetUserLogins")
                .HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("AspNetUserRoles")
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("AspNetUserTokens")
                .HasKey(ut => new { ut.UserId, ut.LoginProvider });

            modelBuilder.Entity<User>().ToTable("AspNetUsers")
                .HasOne(u => u.UserData)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserData>(ud => ud.UserForeignKey);

            modelBuilder.Entity<Bet>()
                .HasKey(b => new { b.UserId, b.EventId });

            modelBuilder.Entity<Bet>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Bet>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bets)
                .HasForeignKey(b => b.EventId);
        }
    }
}
