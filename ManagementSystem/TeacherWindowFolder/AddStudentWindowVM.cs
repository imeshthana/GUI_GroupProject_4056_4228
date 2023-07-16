using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.Models;
using ManagementSystem.AdminWindowFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementSystem.Teacher
{
    public partial class AddStudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public string modulename;

        public Student Person { get; private set; }

        public Action Close { get; internal set; }

        public AddStudentWindowVM(Student person, string title)
        {
            Person = person;
            firstname = Person.FirstName;
            lastname = Person.LastName;
            dateofbirth = Person.DateOfBirth;
            Title = title;

        }

        public AddStudentWindowVM()
        {
            Title = "Add Student";
        }


        [RelayCommand]
        public void Save()
        {
            if (Person == null)
            {
                Person = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    DateOfBirth = dateofbirth,
                };

            }
            else
            {
                Person.FirstName = firstname;
                Person.LastName = lastname;
                Person.DateOfBirth = dateofbirth;
            }
            Close();
        }
    }
}
