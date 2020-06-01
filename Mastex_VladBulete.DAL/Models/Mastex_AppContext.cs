using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mastex_BuleteVlad.DAL.Models
{
    public partial class Mastex_AppContext : DbContext
    {
        public Mastex_AppContext()
        {
        }

        public Mastex_AppContext(DbContextOptions<Mastex_AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ProjectUsers> ProjectUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<ProjectUsers>(entity =>
            {
                entity.Property(e => e.ProjectId).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
            });
            modelBuilder.Entity<ProjectUsers>().HasKey(table => new
            {
                table.UserId,
                table.ProjectId
            });

        }
    }
}
