using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.Models;
using ManagementSystem.Teacher;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementSystem.AdminWindowFolder
{
    public partial class AdminWindowVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Academic> teachers;

        public int id = 0;

        public Academic SelectedTeacher { get; set; }

        [RelayCommand]
        public void AddTeacher()
        {
            var vm = new AddTeacherWindowVM();
            AddTeacherWindow window = new AddTeacherWindow(vm);
            window.ShowDialog();

            if (vm.Person != null)
            {
                vm.Person.Id = id++;
                using (var db = new DataBaseContext())
                {
                    db.Teachers.Add(vm.Person);
                    db.SaveChanges();
                    LoadPerson1();
                }
            }
        }

        public void LoadPerson1()
        {
            using (var db = new DataBaseContext())
            {
                var list = db.Teachers.ToList();
                Teachers = new ObservableCollection<Academic>(list);
            }
        }

        public AdminWindowVM()
        {
            LoadPerson1();
        }

        [RelayCommand]
        public void EditTeacher()
        {
            if (SelectedTeacher == null)
            {
                MessageBox.Show("Select a teacher to edit", "Error");
            }
            else
            {
                var vm = new AddTeacherWindowVM(SelectedTeacher, "EDIT TEACHER");
                var window = new AddTeacherWindow(vm);
                window.ShowDialog();

                using (var db = new DataBaseContext())
                {
                    int index = Teachers.IndexOf(SelectedTeacher);
                    Teachers.RemoveAt(index);
                    Teachers.Insert(index,vm.Person);
                    db.SaveChanges();
                }
            }
        }

        [RelayCommand]
        public void DeleteTeacher()
        {
            if (SelectedTeacher == null)
            {
                MessageBox.Show("Select a teacher to delete", "Error");
            }
            else
            {
                using (var db = new DataBaseContext())
                {
                    MessageBox.Show("Delete selected teacher", "Delete");
                    db.Teachers.Remove(SelectedTeacher);
                    db.SaveChanges();
                    LoadPerson1();
                }
            }
        }
    }
}
