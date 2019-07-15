using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Help_desk
{
    public class ApplicationContext
   : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasKey(t => new { t.UserId, t.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.UserGroups)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserGroup>()
                .HasOne(sc => sc.Group)
                .WithMany(c => c.UserGroups)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<GroupPermission>()
           .HasKey(t => new { t.GroupId, t.PermissionId });

            modelBuilder.Entity<GroupPermission>()
                .HasOne(sc => sc.Group)
                .WithMany(s => s.GroupPermissions)
                .HasForeignKey(sc => sc.GroupId);

            modelBuilder.Entity<GroupPermission>()
                .HasOne(sc => sc.Permission)
                .WithMany(c => c.GroupPermissions)
                .HasForeignKey(sc => sc.PermissionId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Help_desk_db;Username=postgres;Password=1234");
        }
       
    }
}