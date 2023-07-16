using CommunityToolkit.Mvvm.ComponentModel;
using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ManagementSystem.StudentsWindowFolder
{
    public partial class StudentWindowVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<StudentModule> studentmodules;

        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public string modulecode;

        [ObservableProperty]
        public string modulename;

        [ObservableProperty]
        public double gpa;

        public StudentWindowVM(Student student)
        {
            id = student.ID;
            firstname = student.FirstName;
            lastname = student.LastName;
            dateofbirth = student.DateOfBirth;
            LoadResults(student);
            gpa = student.GPA;
        }

        public StudentWindowVM() { }

        public void LoadResults(Student student)
        {
            using (var db = new DataBaseContext())
            {
                studentmodules = new ObservableCollection<StudentModule>();
                foreach (var module in db.Module_Student)
                {
                    if(student.ID == module.StudentId)
                    {
                        studentmodules.Add(module); 
                    }
                }
            }
            student.GPA = student.CalGPA(studentmodules);
        }
    }
}
