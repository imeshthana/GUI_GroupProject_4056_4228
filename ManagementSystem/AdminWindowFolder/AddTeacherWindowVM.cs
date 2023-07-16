using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementSystem.AdminWindowFolder;

namespace ManagementSystem.AdminWindowFolder
{
    public partial class AddTeacherWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string username;

        [ObservableProperty]
        public string password;

        [ObservableProperty]
        public string modulename;

        [ObservableProperty]
        public string modulecode;

        [ObservableProperty]
        public string title;

        public Academic Person { get; private set; }

        public Action Close { get; internal set; }

        public AddTeacherWindowVM(Academic person, string title)
        {
            Person = person;
            username = Person.UserName;
            password = Person.PassWord;
            modulename = Person.ModuleName;
            modulecode = Person.ModuleCode;
            Title = title;
        }

        public AddTeacherWindowVM()
        {
            Title = "ADD TEACHER";
        }


        [RelayCommand]
        public void Save()
        {
            if (Person == null)
            {
                Person = new Academic()
                {
                    UserName=username,
                    PassWord =password,
                    ModuleName=modulename,
                    ModuleCode=modulecode
                };

            }
            else
            {
                Person.ModuleName = modulename;
                Person.UserName = username;
                Person.PassWord = password;
                Person.ModuleCode = modulecode; 
            }
            Close();
        }
    }
}
