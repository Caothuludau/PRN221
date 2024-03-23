using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HospitalQMS.Models
{
    public partial class HospitalQMSContext : DbContext
    {
        public HospitalQMSContext()
        {
        }

        public HospitalQMSContext(DbContextOptions<HospitalQMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public virtual DbSet<MedicalStaff> MedicalStaffs { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<PriorityType> PriorityTypes { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Specialty> Specialties { get; set; } = null!;
        public virtual DbSet<StaffType> StaffTypes { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server = CAOTHULUDAU; database = HospitalQMS; uid=sa;pwd=123456;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Dname)
                    .HasMaxLength(50)
                    .HasColumnName("DName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecord");

                entity.Property(e => e.MedicalRecordId)
                    .HasColumnName("MedicalRecordID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [MedicalRecordID_Sequence])");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Company)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.DateAdmitted).HasColumnType("date");

                entity.Property(e => e.DateDischarged).HasColumnType("date");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Ethnicity)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.File)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FullName)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Occupation)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.SocialInsuranceCode)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.TreatmentForm)
                    .HasMaxLength(200)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MedicalStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.ToTable("MedicalStaff");

                entity.Property(e => e.StaffId)
                    .ValueGeneratedNever()
                    .HasColumnName("StaffID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Msname)
                    .HasMaxLength(40)
                    .HasColumnName("MSName")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.StaffTypeId).HasColumnName("StaffTypeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.MedicalStaffs)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_MedicalStaff_Room");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.MedicalStaffs)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_MedicalStaff_Specialty");

                entity.HasOne(d => d.StaffType)
                    .WithMany(p => p.MedicalStaffs)
                    .HasForeignKey(d => d.StaffTypeId)
                    .HasConstraintName("FK_MedicalStaff_StaffType");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId)
                    .ValueGeneratedNever()
                    .HasColumnName("MessageID");

                entity.Property(e => e.Content)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Language)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [PatientID_Sequence])");

                entity.Property(e => e.Ccnumber)
                    .HasMaxLength(12)
                    .HasColumnName("CCNumber")
                    .IsFixedLength();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecordID");

                entity.Property(e => e.Pname)
                    .HasMaxLength(40)
                    .HasColumnName("PName")
                    .IsFixedLength();

                entity.Property(e => e.PriorityTypeId).HasColumnName("PriorityTypeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.MedicalRecord)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.MedicalRecordId)
                    .HasConstraintName("FK_Patient_MedicalRecord");

                entity.HasOne(d => d.PriorityType)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.PriorityTypeId)
                    .HasConstraintName("FK_Patient_PriorityType");
            });

            modelBuilder.Entity<PriorityType>(entity =>
            {
                entity.ToTable("PriorityType");

                entity.Property(e => e.PriorityTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PriorityTypeID");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Ptname)
                    .HasMaxLength(100)
                    .HasColumnName("PTName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [RoomID_Sequence])");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Rname)
                    .HasMaxLength(40)
                    .HasColumnName("RName")
                    .IsFixedLength();

                entity.Property(e => e.RoomCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SpecialtyId).HasColumnName("SpecialtyID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Room_Department");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.SpecialtyId)
                    .HasConstraintName("FK_Room_Specialty");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("Specialty");

                entity.Property(e => e.SpecialtyId)
                    .ValueGeneratedNever()
                    .HasColumnName("SpecialtyID");

                entity.Property(e => e.Sname)
                    .HasMaxLength(100)
                    .HasColumnName("SName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<StaffType>(entity =>
            {
                entity.ToTable("StaffType");

                entity.Property(e => e.StaffTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("StaffTypeID");

                entity.Property(e => e.Stname)
                    .HasMaxLength(40)
                    .HasColumnName("STName")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");

                entity.Property(e => e.TicketId)
                    .HasColumnName("TicketID")
                    .HasDefaultValueSql("(NEXT VALUE FOR [TicketID_Sequence])");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.RegisterTime).HasColumnType("datetime");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ticket_Patient");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Ticket_RoomID");
            });

            modelBuilder.HasSequence("MedicalRecordID_Sequence").IncrementsBy(3);

            modelBuilder.HasSequence("MedicalReportID_Sequence").IncrementsBy(3);

            modelBuilder.HasSequence("PatientID_Sequence");

            modelBuilder.HasSequence("RoomID_Sequence").IncrementsBy(2);

            modelBuilder.HasSequence("TicketID_Sequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
