﻿// <auto-generated />
using System;
using Company.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Company.Domain.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20201125224502_AddingTask")]
    partial class AddingTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Company.Domain.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            Name = "Marketing"
                        },
                        new
                        {
                            DepartmentID = 2,
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("Company.Domain.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            Birthday = new DateTime(1987, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentID = 1,
                            Lastname = "Louis",
                            Name = "Mark"
                        },
                        new
                        {
                            EmployeeID = 2,
                            Birthday = new DateTime(1989, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentID = 2,
                            Lastname = "Jones",
                            Name = "Luna"
                        });
                });

            modelBuilder.Entity("Company.Domain.Responsibility", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID", "TaskID");

                    b.HasIndex("TaskID");

                    b.ToTable("Responsibility");
                });

            modelBuilder.Entity("Company.Domain.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskID");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            Name = "Marketing strategy"
                        },
                        new
                        {
                            TaskID = 2,
                            Name = "App deployment"
                        });
                });

            modelBuilder.Entity("Company.Domain.Employee", b =>
                {
                    b.HasOne("Company.Domain.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Company.Domain.Payment", "Payments", b1 =>
                        {
                            b1.Property<int>("EmployeeID")
                                .HasColumnType("int");

                            b1.Property<int>("PaymentID")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<DateTime>("DateOfPayment")
                                .HasColumnType("datetime2");

                            b1.HasKey("EmployeeID", "PaymentID");

                            b1.ToTable("Payment");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeID");
                        });

                    b.Navigation("Department");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Company.Domain.Responsibility", b =>
                {
                    b.HasOne("Company.Domain.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Domain.Task", "Task")
                        .WithMany("Employees")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("Company.Domain.Employee", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Company.Domain.Task", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
