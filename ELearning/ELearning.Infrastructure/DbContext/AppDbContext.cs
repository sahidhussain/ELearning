using ELearning.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Infrastructure.DbContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Addresses> UserDetails { get; set; }
        public DbSet<AddressType> InstituteDetails { get; set; }
        public DbSet<AssignParent> AssignParent { get; set; }
        public DbSet<AssignStudent> AssignStudent { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<EmergencyContact> EmergencyContact { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<InstructorProfile> InstructorProfile { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Relationship> Relationship { get; set; }
        public DbSet<StaffType> StaffType { get; set; }
        public DbSet<StudentProfile> StudentProfile { get; set; }
        public DbSet<Titles> Titles { get; set; }
        public DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            builder.Entity<IdentityUserRole<long>>().ToTable("UserRole");
            builder.Entity<IdentityUserLogin<long>>().ToTable("UserLogin");
            builder.Entity<IdentityUserClaim<long>>().ToTable("UserClaim");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserToken<long>>().ToTable("UserToken");
            builder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaim");

            builder.Entity<AssignParent>().HasKey(k => new { k.AssigneeID, k.ParentID });
            builder.Entity<AssignStudent>().HasKey(k => new { k.StudentID, k.ParentID });

            builder.Entity<AddressType>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<Category>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<DocumentType>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<Gender>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<MaritalStatus>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<Relationship>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<StaffType>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<Titles>().HasIndex(i => i.Name).IsUnique();
            builder.Entity<UserType>().HasIndex(i => i.Name).IsUnique();

        }
    }
}
