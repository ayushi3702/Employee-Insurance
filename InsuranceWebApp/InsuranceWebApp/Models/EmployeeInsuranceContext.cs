using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InsuranceWebApp.Models;

public partial class EmployeeInsuranceContext : DbContext
{
    public EmployeeInsuranceContext()
    {
    }

    public EmployeeInsuranceContext(DbContextOptions<EmployeeInsuranceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PolicyDetail> PolicyDetails { get; set; }

    public virtual DbSet<UserLoginDetail> UserLoginDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-A40FOBK\\SQLEXPRESS;Database=employee_insurance;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__employee__2623598B4CBAD734");

            entity.ToTable("employee_details");

            entity.Property(e => e.EmpId)
                .ValueGeneratedNever()
                .HasColumnName("Emp_ID");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Company_Name");
            entity.Property(e => e.EmpName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Emp_Name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payment___DA6C7FE119E3D5AB");

            entity.ToTable("payment_details");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Bank_Name");
            entity.Property(e => e.CardExpiryDate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Card_Expiry_Date");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Card_Holder_Name");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Card_Number");
            entity.Property(e => e.Cvv).HasColumnName("CVV");
            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

            entity.HasOne(d => d.Emp).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__payment_d__Emp_I__40058253");
        });

        modelBuilder.Entity<PolicyDetail>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__policy_d__4564AB412EFB3D99");

            entity.ToTable("policy_details");

            entity.Property(e => e.PolicyId)
                .ValueGeneratedNever()
                .HasColumnName("Policy_ID");
            entity.Property(e => e.BeneficiaryName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Beneficiary_Name");
            entity.Property(e => e.BeneficiaryRelation)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Beneficiary_Relation");
            entity.Property(e => e.CoverageType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Coverage_Type");
            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");
            entity.Property(e => e.EndDate).HasColumnName("End_date");
            entity.Property(e => e.Insurer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PolicyStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Policy_Status");
            entity.Property(e => e.StartDate).HasColumnName("Start_date");
            entity.Property(e => e.Tpa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TPA");

            entity.HasOne(d => d.Emp).WithMany(p => p.PolicyDetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__policy_de__Emp_I__70DDC3D8");
        });

        modelBuilder.Entity<UserLoginDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_login_details");

            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasColumnName("Emp_ID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Emp).WithMany()
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__user_logi__Emp_I__17036CC0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
