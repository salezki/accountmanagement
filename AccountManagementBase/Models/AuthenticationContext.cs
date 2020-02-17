using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagementBase.Models
{
    public class AuthenticationContext : IdentityDbContext<User, Role, int>
    {
        public AuthenticationContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Customize the default Identity tables
            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User", schema: "Security");
                entity.Property(e => e.Id).HasColumnName("UserID");

            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role", schema: "Security");
                entity.Property(e => e.Id).HasColumnName("RoleID");

            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UserClaim", "Security");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.Id).HasColumnName("UserClaimID");

            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UserLogin", "Security");
                entity.Property(e => e.UserId).HasColumnName("UserID");

            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RoleClaim", "Security");
                entity.Property(e => e.Id).HasColumnName("RoleClaimID");
                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UserRole", "Security");
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

            });

            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UserToken", "Security");
                entity.Property(e => e.UserId).HasColumnName("UserID");

            });
        }

    }
}
