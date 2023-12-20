using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_CRUD_Challange.Models
{
    public partial class MVC_CRUD_DBContext : DbContext
    {
        public MVC_CRUD_DBContext()
        {
        }

        public MVC_CRUD_DBContext(DbContextOptions<MVC_CRUD_DBContext> options)  : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.AddressId)
                    .ValueGeneratedNever()
                    .HasColumnName("addressId");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.PinCode).HasColumnName("pinCode");
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("dept");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("deptId");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("deptName");
            });
            //This is configuring the Employee entity using the modelBuilder object. It specifies the properties, keys, and relationships for the Employee entity.
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                //Specifies that the StudentId property is the primary key for the Employee entity.

                entity.ToTable("employee");
                //Specifies the table name for the Employee entity. In this case, the table name is set to "employee".

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("studentId");

                entity.Property(e => e.AddressId).HasColumnName("addressId");

                entity.Property(e => e.DeptId).HasColumnName("deptId");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_employee_address");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_employee_dept");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
