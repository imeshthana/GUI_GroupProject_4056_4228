using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class Academic
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }

        public ObservableCollection<StudentModule> ModuleStudents { get; set; }

        public Academic() { }

        public Academic(int id, string userName, string password, string usermodule, string modulecode)
        {
            Id = id;
            ModuleName = usermodule;
            UserName = userName;
            PassWord = password;
            ModuleCode = modulecode;
        }
    }
}