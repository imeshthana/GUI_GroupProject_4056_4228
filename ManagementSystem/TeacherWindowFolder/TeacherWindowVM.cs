using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.Models;
using ManagementSystem.Teacher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementSystem;
using System.Reflection;
using System.ComponentModel;
using ManagementSystem.TeacherWindowFolder;
using System.Diagnostics.Eventing.Reader;

namespace ManagementSystem.Teacher
{
    public partial class TeacherWindowVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Student> students;

        [ObservableProperty]
        ObservableCollection<StudentModule> module_student;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string subtitle;

        public int mark;

        public int id = 1000;
        public int id1 = 0;

        public StudentModule Modulemark { get; set; }

        public Student SelectedStudent { get; set; }

        public Academic modulecordinator { get; set; }

        public TeacherWindowVM(Academic teacher)
        {
            modulecordinator = teacher;
            Title = teacher.ModuleName;
            Subtitle = teacher.ModuleCode;
            LoadPerson();
        }

        public TeacherWindowVM()
        {
            LoadPerson();   
        }
          

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentWindowVM();
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();

            if (vm.Person != null)
            {
                vm.Person.ID = id++;
                using (var db = new DataBaseContext())
                {
                    db.Students.Add(vm.Person);
                    db.SaveChanges();
                    LoadPerson();
                }
            }
        }

        public void LoadPerson()
        {
            using (var db = new DataBaseContext())
            {
                var list = db.Students.ToList();
                Students = new ObservableCollection<Student>(list);
            }
        }


        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Select a student to edit", "Error");
            }
            else
            {
                var vm = new AddStudentWindowVM(SelectedStudent, "Edit Student");
                var window = new AddStudentWindow(vm);
                window.ShowDialog();

                using (var db = new DataBaseContext())
                {
                    int index = Students.IndexOf(SelectedStudent);
                    Students.RemoveAt(index);
                    Students.Insert(index, vm.Person);
                    db.SaveChanges();
                }
            }
        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Select a student to delete", "Error");
            }
            else
            {
                using (var db = new DataBaseContext())
                {
                    MessageBox.Show("Delete selected student", "Delete");
                    db.Students.Remove(SelectedStudent);
                    db.SaveChanges();
                    LoadPerson();
                }
            }
        }

        [RelayCommand]
        public void AddGrade()
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Select a student to add grade", "Error");
            }
            else
            {
                using (var db = new DataBaseContext())
                {
                    foreach(StudentModule mark in db.Module_Student)
                    {
                        if((mark.StudentId == SelectedStudent.ID) && (mark.ModuleId == modulecordinator.Id))
                        {
                            var vm1 = new AddGradeWindowVM(SelectedStudent, modulecordinator, mark);
                            AddGradeWindow window1 = new AddGradeWindow(vm1);
                            window1.ShowDialog();
                            db.Module_Student.Remove(mark);
                            vm1.Modulemark.StudentModuleId = id1++;
                            db.Module_Student.Add(vm1.Modulemark);
                            db.SaveChanges();
                            return;
                        }
                    }
                }
                var vm = new AddGradeWindowVM(SelectedStudent, modulecordinator);
                AddGradeWindow window = new AddGradeWindow(vm);
                window.ShowDialog();

                if (vm.Modulemark != null)
                {
                    vm.Modulemark.StudentModuleId = id1++;
                    using (var db1 = new DataBaseContext())
                    {
                        db1.Module_Student.Add(vm.Modulemark);
                        db1.SaveChanges();
                    }
                }
            }
        }
    }
}
