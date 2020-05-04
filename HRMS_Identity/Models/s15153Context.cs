using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMS_Identity.Models
{
    public partial class s15153Context : IdentityDbContext<User>
    {
        public s15153Context()
        {
        }

        public s15153Context(DbContextOptions<s15153Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AbsenceType> AbsenceType { get; set; }
        public virtual DbSet<AvailableAbsence> AvailableAbsence { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractBenefit> ContractBenefit { get; set; }
        public virtual DbSet<ContractStatus> ContractStatus { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Overtime> Overtime { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestStatus> RequestStatus { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15153;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AbsenceType>(entity =>
            {
                entity.HasKey(e => e.IdAbsenceType)
                    .HasName("AbsenceType_pk");

                entity.Property(e => e.IdAbsenceType).ValueGeneratedNever();

                entity.Property(e => e.AbsenceType1)
                    .IsRequired()
                    .HasColumnName("AbsenceType")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AvailableAbsence>(entity =>
            {
                entity.HasKey(e => e.IdAvailableAbsence)
                    .HasName("AvailableAbsence_pk");

                entity.Property(e => e.IdAvailableAbsence).ValueGeneratedNever();

                entity.Property(e => e.AvailableDays).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.UsedAbsence).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdAbsenceTypeNavigation)
                    .WithMany(p => p.AvailableAbsence)
                    .HasForeignKey(d => d.IdAbsenceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AvailableAbsence_AbsenceType");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.AvailableAbsence)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AvailableAbsence_Employee");
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.HasKey(e => e.IdBenefit)
                    .HasName("Benefit_pk");

                entity.Property(e => e.IdBenefit).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("Contract_pk");

                entity.Property(e => e.IdContract).ValueGeneratedNever();

                entity.Property(e => e.ContractEnd).HasColumnType("date");

                entity.Property(e => e.ContractStart).HasColumnType("date");

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdContractStatusNavigation)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.IdContractStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contract_ContractStatus");

                entity.HasOne(d => d.IdContractTypeNavigation)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.IdContractType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contract_ContractType");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contract_Employee");
            });

            modelBuilder.Entity<ContractBenefit>(entity =>
            {
                entity.HasKey(e => new { e.IdBenefitContract, e.IdBenefit, e.IdContract })
                    .HasName("ContractBenefit_pk");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdBenefitNavigation)
                    .WithMany(p => p.ContractBenefit)
                    .HasForeignKey(d => d.IdBenefit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContractBenefit_Benefit");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany(p => p.ContractBenefit)
                    .HasForeignKey(d => d.IdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContractBenefit_Contract");
            });

            modelBuilder.Entity<ContractStatus>(entity =>
            {
                entity.HasKey(e => e.IdContractStatus)
                    .HasName("ContractStatus_pk");

                entity.Property(e => e.IdContractStatus).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.IdContractType)
                    .HasName("ContractType_pk");

                entity.Property(e => e.IdContractType).ValueGeneratedNever();

                entity.Property(e => e.ContractType1)
                    .IsRequired()
                    .HasColumnName("ContractType")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("Employee_pk");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdCardNumber).HasMaxLength(6);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Pesel)
                    .IsRequired()
                    .HasColumnName("PESEL")
                    .HasMaxLength(11);

                entity.Property(e => e.SecondName).HasMaxLength(50);

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Job");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.InverseIdManagerNavigation)
                    .HasForeignKey(d => d.IdManager)
                    .HasConstraintName("Employee_Manager");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Role");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob)
                    .HasName("Job_pk");

                entity.Property(e => e.IdJob).ValueGeneratedNever();

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.HasKey(e => e.IdOvertime)
                    .HasName("Overtime_pk");

                entity.Property(e => e.IdOvertime).ValueGeneratedNever();

                entity.Property(e => e.Hours).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ToBeSettledBefore).HasColumnType("date");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Overtime)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Overtime_Employee");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.IdRequest)
                    .HasName("Request_pk");

                entity.Property(e => e.IdRequest).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.QuantityRequested).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_Employee");

                entity.HasOne(d => d.IdRequestStatusNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.IdRequestStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_Status");

                entity.HasOne(d => d.IdRequestTypeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.IdRequestType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_RequestType");
            });

            modelBuilder.Entity<RequestStatus>(entity =>
            {
                entity.HasKey(e => e.IdRequestStatus)
                    .HasName("RequestStatus_pk");

                entity.Property(e => e.IdRequestStatus).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.HasKey(e => e.IdRequestType)
                    .HasName("RequestType_pk");

                entity.Property(e => e.IdRequestType).ValueGeneratedNever();

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("Role_pk");

                entity.Property(e => e.IdRole).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
