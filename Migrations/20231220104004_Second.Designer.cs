﻿// <auto-generated />
using System;
using MVC_CRUD_Challange.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_CRUD_Challange.Migrations
{
    [DbContext(typeof(MVC_CRUD_DBContext))]
    [Migration("20231220104004_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVC_CRUD_Challange.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("addressId");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<int?>("PinCode")
                        .HasColumnType("int")
                        .HasColumnName("pinCode");

                    b.HasKey("AddressId");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("MVC_CRUD_Challange.Models.Dept", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("deptId");

                    b.Property<string>("DeptName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("deptName");

                    b.HasKey("DeptId");

                    b.ToTable("dept", (string)null);
                });

            modelBuilder.Entity("MVC_CRUD_Challange.Models.Employee", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("addressId");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int")
                        .HasColumnName("deptId");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.HasKey("StudentId");

                    b.HasIndex("AddressId");

                    b.HasIndex("DeptId");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("MVC_CRUD_Challange.Models.Employee", b =>
                {
                    b.HasOne("MVC_CRUD_Challange.Models.Address", "Address")
                        .WithMany("Employees")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_employee_address");

                    b.HasOne("MVC_CRUD_Challange.Models.Dept", "Dept")
                        .WithMany("Employees")
                        .HasForeignKey("DeptId")
                        .HasConstraintName("FK_employee_dept");

                    b.Navigation("Address");

                    b.Navigation("Dept");
                });

            modelBuilder.Entity("MVC_CRUD_Challange.Models.Address", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("MVC_CRUD_Challange.Models.Dept", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
