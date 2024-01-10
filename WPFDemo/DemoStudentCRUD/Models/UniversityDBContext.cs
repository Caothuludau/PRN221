using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DemoStudentCRUD.Models
{
    public partial class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
        {
        }

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorId).HasColumnName("MajorID");

                entity.Property(e => e.MajorName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.MajorId).HasColumnName("MajorID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.StudentName).HasMaxLength(100);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Student__MajorID__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
