using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vet_DAL.Models;

public partial class VetClinicContext : DbContext
{
    public VetClinicContext()
    {
    }

    public VetClinicContext(DbContextOptions<VetClinicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptionQuestionnaire> AdoptionQuestionnaires { get; set; }

    public virtual DbSet<AdoptionStatus> AdoptionStatuses { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalType> AnimalTypes { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<DoctorSlot> DoctorSlots { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<PetForAdoption> PetForAdoptions { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffRole> StaffRoles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vaccination> Vaccinations { get; set; }

    public virtual DbSet<XrayImage> XrayImages { get; set; }

    public virtual DbSet<ZlabResult> ZlabResults { get; set; }

    public virtual DbSet<ZtestNormalRange> ZtestNormalRanges { get; set; }

    public virtual DbSet<Zzrating> Zzratings { get; set; }

    public virtual DbSet<ZzvaccineType> ZzvaccineTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CUTHP9P;Database=VetClinic;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptionQuestionnaire>(entity =>
        {
            entity.ToTable("AdoptionQuestionnaire");

            entity.Property(e => e.AdoptionQuestionnaireId).HasColumnName("AdoptionQuestionnaire_ID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.IfSick)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LeftAlone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PetForAdoptionId).HasColumnName("PetForAdoption_ID");
            entity.Property(e => e.QuestionStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReasonForAdoption)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.WhoWillBeReponsible)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.PetForAdoption).WithMany(p => p.AdoptionQuestionnaires)
                .HasForeignKey(d => d.PetForAdoptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdoptionQuestionnaire_PetForAdoption");

            entity.HasOne(d => d.User).WithMany(p => p.AdoptionQuestionnaires)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AdoptionQuestionnaire_User");
        });

        modelBuilder.Entity<AdoptionStatus>(entity =>
        {
            entity.ToTable("AdoptionStatus");

            entity.Property(e => e.AdoptionStatusId).HasColumnName("AdoptionStatus_ID");
            entity.Property(e => e.AdoptionStatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK_Pet");

            entity.ToTable("Animal");

            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.AnimalBirthDate).HasColumnType("datetime");
            entity.Property(e => e.AnimalName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AnimalTypeId).HasColumnName("AnimalType_ID");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.OwnerId).HasColumnName("Owner_ID");
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.AnimalType).WithMany(p => p.Animals)
                .HasForeignKey(d => d.AnimalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_AnimalType");

            entity.HasOne(d => d.Owner).WithMany(p => p.Animals)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Animal_Owner1");
        });

        modelBuilder.Entity<AnimalType>(entity =>
        {
            entity.HasKey(e => e.AnimalTypeId).HasName("PK_Horse");

            entity.ToTable("AnimalType");

            entity.Property(e => e.AnimalTypeId).HasColumnName("AnimalType_ID");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");
            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.AppointmentReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DoctorSlotId).HasColumnName("DoctorSlot_ID");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");

            entity.HasOne(d => d.Animal).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Animal");

            entity.HasOne(d => d.DoctorSlot).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorSlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_DoctorSlot");

            entity.HasOne(d => d.Staff).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctor");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.ToTable("DoctorSchedule");

            entity.Property(e => e.DoctorScheduleId).HasColumnName("DoctorSchedule_ID");
            entity.Property(e => e.EndTimeSchedule).HasPrecision(5);
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.StartTimeSchedule).HasPrecision(5);

            entity.HasOne(d => d.Staff).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorSchedule_Staff");
        });

        modelBuilder.Entity<DoctorSlot>(entity =>
        {
            entity.HasKey(e => e.DoctorSlotId).HasName("PK_AppointmentStatus");

            entity.ToTable("DoctorSlot");

            entity.Property(e => e.DoctorSlotId).HasColumnName("DoctorSlot_ID");
            entity.Property(e => e.SlotEndTime).HasPrecision(5);
            entity.Property(e => e.SlotStartTime).HasPrecision(5);
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");

            entity.HasOne(d => d.Staff).WithMany(p => p.DoctorSlots)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DoctorSlot_Staff");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("Inventory");

            entity.Property(e => e.ItemId).HasColumnName("Item_ID");
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastRestocked).HasColumnType("datetime");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_ID");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OwnerNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.ToTable("MedicalRecord");

            entity.Property(e => e.MedicalRecordId).HasColumnName("MedicalRecord_ID");
            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PrescribedMedication)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.SurgeryDetails)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Treatment)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Animal).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalRecord_Animal");

            entity.HasOne(d => d.Staff).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalRecord_Doctor");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.ToTable("Owner");

            entity.Property(e => e.OwnerId).HasColumnName("Owner_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OwnerBirthDate).HasColumnType("datetime");
            entity.Property(e => e.OwnerEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Owners)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Owner_User");
        });

        modelBuilder.Entity<PetForAdoption>(entity =>
        {
            entity.ToTable("PetForAdoption");

            entity.Property(e => e.PetForAdoptionId).HasColumnName("PetForAdoption_ID");
            entity.Property(e => e.AdoptionStatusId).HasColumnName("AdoptionStatus_ID");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.PetCondition)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PetName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Species)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.AdoptionStatus).WithMany(p => p.PetForAdoptions)
                .HasForeignKey(d => d.AdoptionStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PetForAdoption_AdoptionStatus");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK_Doctor");

            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StaffRoleId).HasColumnName("StaffRole_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.StaffRole).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StaffRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Staff_StaffRole");

            entity.HasOne(d => d.User).WithMany(p => p.Staff)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Staff_User");
        });

        modelBuilder.Entity<StaffRole>(entity =>
        {
            entity.ToTable("StaffRole");

            entity.Property(e => e.StaffRoleId).HasColumnName("StaffRole_ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vaccination>(entity =>
        {
            entity.ToTable("Vaccination");

            entity.Property(e => e.VaccinationId).HasColumnName("Vaccination_ID");
            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.NextDueDate).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("Staff_ID");
            entity.Property(e => e.VaccinationDate).HasColumnType("datetime");
            entity.Property(e => e.VaccineTypeId).HasColumnName("VaccineType_ID");

            entity.HasOne(d => d.Animal).WithMany(p => p.Vaccinations)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccination_Animal");

            entity.HasOne(d => d.Staff).WithMany(p => p.Vaccinations)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vaccination_Doctor");

            entity.HasOne(d => d.VaccineType).WithMany(p => p.Vaccinations)
                .HasForeignKey(d => d.VaccineTypeId)
                .HasConstraintName("FK_Vaccination_ZZVaccineType");
        });

        modelBuilder.Entity<XrayImage>(entity =>
        {
            entity.HasKey(e => e.XrayId);

            entity.ToTable("XRayImages");

            entity.Property(e => e.XrayId).HasColumnName("XRay_ID");
            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);

            entity.HasOne(d => d.Animal).WithMany(p => p.XrayImages)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_XRayImages_Animal");
        });

        modelBuilder.Entity<ZlabResult>(entity =>
        {
            entity.HasKey(e => e.LabResultId);

            entity.ToTable("ZLabResult");

            entity.Property(e => e.LabResultId).HasColumnName("LabResult_ID");
            entity.Property(e => e.AnimalId).HasColumnName("Animal_ID");
            entity.Property(e => e.IsNormal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Result).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.TestDate).HasColumnType("datetime");
            entity.Property(e => e.TestName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TestNormalRangeId).HasColumnName("TestNormalRange_ID");

            entity.HasOne(d => d.Animal).WithMany(p => p.ZlabResults)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZLabResult_Animal");

            entity.HasOne(d => d.TestNormalRange).WithMany(p => p.ZlabResults)
                .HasForeignKey(d => d.TestNormalRangeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZLabResult_ZTestNormalRange");
        });

        modelBuilder.Entity<ZtestNormalRange>(entity =>
        {
            entity.HasKey(e => e.TestNormalRangeId);

            entity.ToTable("ZTestNormalRange");

            entity.Property(e => e.TestNormalRangeId).HasColumnName("TestNormalRange_ID");
            entity.Property(e => e.MaxRange).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.MinRange).HasColumnType("decimal(5, 1)");
            entity.Property(e => e.TestName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UnitOfMeasurement)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Zzrating>(entity =>
        {
            entity.HasKey(e => e.RatingId);

            entity.ToTable("ZZRating");

            entity.Property(e => e.RatingId).HasColumnName("Rating_ID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Review)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReviewTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<ZzvaccineType>(entity =>
        {
            entity.HasKey(e => e.VaccineTypeId);

            entity.ToTable("ZZVaccineType");

            entity.Property(e => e.Dose)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VaccineName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
