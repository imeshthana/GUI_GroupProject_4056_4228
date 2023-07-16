using CommunityToolkit.Mvvm.ComponentModel;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Academic> Teachers { get; set; }
        public DbSet<StudentModule> Module_Student { get; set; }

        public string path = @"D:\ManagementSystem\System.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source = {path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentModule>()
            .HasKey(ms => ms.StudentModuleId);

            modelBuilder.Entity<StudentModule>()
            .HasOne(ms => ms.Student)
            .WithMany(s => s.StudentModules)
            .HasForeignKey(ms => ms.StudentId);

            modelBuilder.Entity<StudentModule>()
            .HasOne(ms => ms.Teacher)
            .WithMany(m => m.ModuleStudents)
            .HasForeignKey(ms => ms.ModuleId);
        }
    }
}

