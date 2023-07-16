using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ManagementSystem.TeacherWindowFolder
{
    public partial class AddGradeWindowVM : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int mark;

        public Academic Modulecordinator { get; private set; }

        public Student Person { get; private set; }

        public StudentModule Modulemark { get; set; }

        [ObservableProperty]
        public string title;

        public Action Close { get; internal set; }

        public AddGradeWindowVM() { }

        public AddGradeWindowVM(Student student, Academic teacher)
        {
            title = teacher.ModuleCode;
            Modulecordinator = teacher;
            Person = student;
            id = student.ID;
            firstname = student.FirstName;
            lastname = student.LastName;
        }

        public AddGradeWindowVM(Student student, Academic teacher, StudentModule studentmark)
        {
            title = teacher.ModuleCode;
            Modulecordinator = teacher;
            Person = student;
            id = student.ID;
            firstname = student.FirstName;
            lastname = student.LastName;
            mark = studentmark.Mark;
        }

        [RelayCommand]
        public void Save()
        {
            Modulemark = new StudentModule()
            {
                StudentId = Person.ID,
                ModuleId = Modulecordinator.Id,
                ModuleCode = Modulecordinator.ModuleCode,
                ModuleName = Modulecordinator.ModuleName,
                Mark = mark,
                Grade = StudentModule.Func(mark)
            };
            Close();
        }
    }
}
