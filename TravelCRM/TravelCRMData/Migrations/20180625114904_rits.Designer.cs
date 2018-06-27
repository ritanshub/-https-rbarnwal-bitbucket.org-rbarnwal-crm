﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelCRMData;

namespace TravelCRMData.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180625114904_rits")]
    partial class rits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelCRMEntities.ApplicationUser", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeID");

                    b.Property<int?>("EmployeeID1");

                    b.Property<bool>("IsLoggedIn");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<int>("RoleID");

                    b.Property<string>("SecretCode");

                    b.HasKey("UserName");

                    b.HasIndex("EmployeeID1");

                    b.HasIndex("RoleID");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("TravelCRMEntities.Customer", b =>
                {
                    b.Property<string>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("EmailID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("MobileNUmber");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TravelCRMEntities.CustomerEnquiryDetails", b =>
                {
                    b.Property<int>("EnquiryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccomdationCategory");

                    b.Property<double>("Budget");

                    b.Property<int>("CustomerID");

                    b.Property<string>("CustomerID1");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("LeadID");

                    b.Property<string>("Loaction");

                    b.Property<int>("Status");

                    b.Property<string>("TourCategory");

                    b.Property<string>("TraveCategory");

                    b.Property<string>("TravelDestination");

                    b.Property<DateTime?>("TravelExpectedDate");

                    b.Property<string>("TravelSource");

                    b.HasKey("EnquiryID");

                    b.HasIndex("CustomerID1");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("LeadID");

                    b.ToTable("CustomerEnquiryDetails");
                });

            modelBuilder.Entity("TravelCRMEntities.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("EmailID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("MobileNUmber");

                    b.Property<int>("RoleID");

                    b.HasKey("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TravelCRMEntities.Lead", b =>
                {
                    b.Property<int>("LeadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Budget");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("CurrentStatus");

                    b.Property<string>("JourneyDestination");

                    b.Property<string>("JourneySource");

                    b.Property<string>("LeadSource");

                    b.Property<int>("ModeOfTravel");

                    b.Property<DateTime?>("ModifiedTime");

                    b.Property<string>("StayPeriod");

                    b.Property<int>("TeamId");

                    b.HasKey("LeadID");

                    b.HasIndex("TeamId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("TravelCRMEntities.LeadEmployeeMapper", b =>
                {
                    b.Property<int>("LeadEmployeeMapperID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("EmployeeID");

                    b.Property<int>("LeadID");

                    b.Property<int>("Level");

                    b.HasKey("LeadEmployeeMapperID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("LeadID");

                    b.ToTable("LeadEmployeeMapper");
                });

            modelBuilder.Entity("TravelCRMEntities.PermissionDetails", b =>
                {
                    b.Property<int>("RoleID");

                    b.Property<string>("ControllerName");

                    b.Property<string>("ActionName");

                    b.Property<string>("PermissionSet");

                    b.HasKey("RoleID", "ControllerName", "ActionName");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("TravelCRMEntities.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Active");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("RoleName");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TravelCRMEntities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("ManagerID");

                    b.Property<string>("ManagerName");

                    b.Property<string>("TeamName");

                    b.HasKey("TeamId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("TravelCRMEntities.ApplicationUser", b =>
                {
                    b.HasOne("TravelCRMEntities.Employee", "emp")
                        .WithMany()
                        .HasForeignKey("EmployeeID1");

                    b.HasOne("TravelCRMEntities.Role", "role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelCRMEntities.CustomerEnquiryDetails", b =>
                {
                    b.HasOne("TravelCRMEntities.Customer", "Customer")
                        .WithMany("CustomerEnquiryDetails")
                        .HasForeignKey("CustomerID1");

                    b.HasOne("TravelCRMEntities.Employee", "employee")
                        .WithMany("CustomerEnquiryDetails")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelCRMEntities.Lead", "lead")
                        .WithMany()
                        .HasForeignKey("LeadID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelCRMEntities.Employee", b =>
                {
                    b.HasOne("TravelCRMEntities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelCRMEntities.Lead", b =>
                {
                    b.HasOne("TravelCRMEntities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelCRMEntities.LeadEmployeeMapper", b =>
                {
                    b.HasOne("TravelCRMEntities.Employee", "employee")
                        .WithMany("LeadEmployeeMapper")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelCRMEntities.Lead", "lead")
                        .WithMany("LeadEmployeeMapper")
                        .HasForeignKey("LeadID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelCRMEntities.PermissionDetails", b =>
                {
                    b.HasOne("TravelCRMEntities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
