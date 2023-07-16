using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem;
using ManagementSystem.AdminWindowFolder;
using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementSystem.Teacher
{
    public partial class TeacherLoginWindowVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Academic> teachers;

        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        public Action Close { get; internal set; }

        [RelayCommand]
        public void LoginTeacher()
        {
            if (username == null || password == null)
            {
                MessageBox.Show("Enter the username and password to login", "Error");
            }
            else
            {
                using (var db = new DataBaseContext())
                {
                    foreach (Academic teacher in db.Teachers)
                    {
                        if ((teacher.UserName == username) && (teacher.PassWord == password))
                        {
                            Close();
                            var vm = new TeacherWindowVM(teacher);
                            var window = new TeacherWindow(vm);
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

