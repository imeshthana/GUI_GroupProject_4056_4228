using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.AdminWindowFolder;
using ManagementSystem.Models;
using ManagementSystem.Teacher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementSystem.StudentsWindowFolder
{
    public partial class StudentLoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Student>? students;

        [ObservableProperty]
        public int? id;

        public Action? Close { get; internal set; }

        [RelayCommand]
        public void LoginStudent()
        {
            if (id == null)
            {
                MessageBox.Show("Enter ID to login", "Error");
            }
            else
            {
                using (var db = new DataBaseContext()) { 
                    foreach (Student student in db.Students)
                    {
                        if ((student.ID == id))
                        {
                            Close();
                            var vm = new StudentWindowVM(student);
                            var window = new StudentWindow(vm);
                            window.ShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show("Incorrect username or password", "Error");
                }
            }
        }
    }
}


