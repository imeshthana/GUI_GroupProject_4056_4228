using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementSystem.AdminWindowFolder
{
    public partial class AdminLoginWindowVM : ObservableObject
    {

        [ObservableProperty]
        public string? password;

        public Action? Close { get; internal set; }

        [RelayCommand]
        public void LoginAdmin()
        {
            if (Password == "123")
            {
                Close();
                AdminWindow window = new AdminWindow();
                window.Show();
            }
            else if (Password == null)
            {
                MessageBox.Show("Enter the password", "Error");
            }
            else
            {
                MessageBox.Show("Password is incorrect", "Error");
            }
        }
    }
}
