using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public double GPA { get; set; }

        public ObservableCollection<StudentModule> StudentModules { get; set; }

        public Student() { }

        public Student(int id, string firstName, string lastName, string dateofbirth)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateofbirth;
        }

        public double CalGPA(ObservableCollection<StudentModule> studentmodules) 
        {
            double gpa = 0.0;
            double total = 0.0;
            int n = 0;
            foreach (StudentModule modules in studentmodules)
            {
                n++;
                switch (modules.Grade) 
                {
                    case "A+":
                        total += 4.0;
                        break;
                    case "A":
                        total += 4.0;
                        break;
                    case "A-":
                        total += 3.7;
                        break;
                    case "B+":
                        total += 3.4;
                        break;
                    case "B":
                        total += 3.0;
                        break;
                    case "B-":
                        total += 2.7;
                        break;
                    case "C+":
                        total += 2.3;
                        break;
                    case "C":
                        total += 2.0;
                        break;
                    case "C-":
                        total += 1.7;
                        break;
                    case "E":
                        total += 0.0;
                        break;
                }
            }
            gpa = total / n;
            return gpa;
        }
    }
}
