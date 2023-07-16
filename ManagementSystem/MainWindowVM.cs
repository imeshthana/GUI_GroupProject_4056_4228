using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.AdminWindowFolder;
using ManagementSystem.StudentsWindowFolder;
using ManagementSystem.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem
{
    public partial class MainWindowVM : ObservableObject
    {
        [RelayCommand]
        public static void AcademicLogin()
        {
            var vm = new TeacherLoginWindowVM();
            TeacherLoginWindow window = new TeacherLoginWindow(vm);
            window.ShowDialog();
        }

        [RelayCommand]
        public static void Admin()
        {
            var vm = new AdminLoginWindowVM();
            AdminLoginWindow window = new AdminLoginWindow(vm);
            window.ShowDialog();
        }

        [RelayCommand]
        public static void StudentLogin()
        {
            var vm = new StudentLoginWindowVM();
            StudentLoginWindow window = new StudentLoginWindow(vm);
            window.ShowDialog();
        }
    }
}
