﻿// <auto-generated />
using ManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementSystem.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230530170141_eightth")]
    partial class eightth
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ManagementSystem.Models.Academic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModuleCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModuleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ManagementSystem.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<double>("GPA")
                        .HasColumnType("REAL");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ManagementSystem.Models.StudentModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModuleCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentModules");
                });

            modelBuilder.Entity("ManagementSystem.Models.StudentModule", b =>
                {
                    b.HasOne("ManagementSystem.Models.Student", null)
                        .WithMany("Modulestudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ManagementSystem.Models.Student", b =>
                {
                    b.Navigation("Modulestudents");
                });
#pragma warning restore 612, 618
        }
    }
}
