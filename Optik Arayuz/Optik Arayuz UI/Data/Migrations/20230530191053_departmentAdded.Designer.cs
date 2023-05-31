﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Optik_Arayuz_UI.Data;

#nullable disable

namespace Optik_Arayüz_UI.Data.Migrations
{
    [DbContext(typeof(OptikArayuzDbContext))]
    [Migration("20230530191053_departmentAdded")]
    partial class departmentAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Choice", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChoiceId"));

                    b.Property<int>("ChoiceCount")
                        .HasColumnType("int");

                    b.Property<string>("Choices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("XLength")
                        .HasColumnType("float");

                    b.Property<double>("YLength")
                        .HasColumnType("float");

                    b.HasKey("ChoiceId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<int>("ClassicCount")
                        .HasColumnType("int");

                    b.Property<string>("ExamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamPaperId")
                        .HasColumnType("int");

                    b.Property<int>("TestCount")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ExamId");

                    b.HasIndex("ExamPaperId");

                    b.HasIndex("UserId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.ExamPaper", b =>
                {
                    b.Property<int>("ExamPaperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamPaperId"));

                    b.Property<string>("ExamPaperName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExamPaperTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamPaperId");

                    b.ToTable("ExamPapers");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.ExamPaperElement", b =>
                {
                    b.Property<int>("ExamPaperElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamPaperElementId"));

                    b.Property<int>("ComponentId")
                        .HasColumnType("int");

                    b.Property<int>("ExamPaperId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("ExamPaperElementId");

                    b.HasIndex("ExamPaperId");

                    b.ToTable("ExamPaperElements");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultyId"));

                    b.Property<string>("FacultyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<int>("QuestionCount")
                        .HasColumnType("int");

                    b.Property<double>("XLength")
                        .HasColumnType("float");

                    b.Property<double>("YLength")
                        .HasColumnType("float");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Logo", b =>
                {
                    b.Property<int>("LogoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogoId"));

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("XLength")
                        .HasColumnType("float");

                    b.Property<double>("YLength")
                        .HasColumnType("float");

                    b.HasKey("LogoId");

                    b.ToTable("Logos");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Number", b =>
                {
                    b.Property<int>("NumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumberId"));

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<double>("XLength")
                        .HasColumnType("float");

                    b.Property<double>("YLength")
                        .HasColumnType("float");

                    b.HasKey("NumberId");

                    b.ToTable("Numbers");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("XLength")
                        .HasColumnType("float");

                    b.Property<double>("YLength")
                        .HasColumnType("float");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"));

                    b.Property<int>("BreakPoint")
                        .HasColumnType("int");

                    b.Property<int>("QuestionCount")
                        .HasColumnType("int");

                    b.Property<double>("XLength")
                        .HasColumnType("float");

                    b.Property<double>("YLength")
                        .HasColumnType("float");

                    b.HasKey("TestId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Text", b =>
                {
                    b.Property<int>("TextId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TextId"));

                    b.Property<int>("FontSize")
                        .HasColumnType("int");

                    b.Property<string>("FontType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TextId");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("Optik_Arayüz_UI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FacultyId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.Exam", b =>
                {
                    b.HasOne("Optik_Arayuz_UI.Models.ExamPaper", "ExamPaper")
                        .WithMany()
                        .HasForeignKey("ExamPaperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Optik_Arayuz_UI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamPaper");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.ExamPaperElement", b =>
                {
                    b.HasOne("Optik_Arayuz_UI.Models.ExamPaper", "ExamPaper")
                        .WithMany()
                        .HasForeignKey("ExamPaperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExamPaper");
                });

            modelBuilder.Entity("Optik_Arayüz_UI.Models.Department", b =>
                {
                    b.HasOne("Optik_Arayuz_UI.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Optik_Arayuz_UI.Models.User", b =>
                {
                    b.HasOne("Optik_Arayüz_UI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Optik_Arayuz_UI.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId");

                    b.Navigation("Department");

                    b.Navigation("Faculty");
                });
#pragma warning restore 612, 618
        }
    }
}