using ManagementSystem.TeacherWindowFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    public class StudentModule
    {

        [Key] public int StudentModuleId { get; set; }
        [ForeignKey("Student")] public int StudentId { get; set; }
        [ForeignKey("Academic")] public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string ModuleCode { get; set; }
        public string Grade { get; set; }
        public int Mark { get; set; }
        public Student Student { get; set; }
        public Academic Teacher { get; set; }

        public StudentModule() { }

        public StudentModule(int id, int studentid, int moduleid, int mark)
        {
            StudentModuleId = id;
            StudentId = studentid;
            ModuleId = moduleid;
            Mark = mark;
            Grade = Func(mark);
        }

        public static string Func(int mark)
        {
            if ((mark <= 100) && (mark >= 85)) { return "A+"; }
            else if ((mark < 85) && (mark >= 75)) { return "A"; }
            else if ((mark < 75) && (mark >= 70)) { return "A-"; }
            else if ((mark < 70) && (mark >= 65)) { return "B+"; }
            else if ((mark < 65) && (mark >= 60)) { return "B"; }
            else if ((mark < 60) && (mark >= 55)) { return "B-"; }
            else if ((mark < 55) && (mark >= 50)) { return "C+"; }
            else if ((mark < 50) && (mark >= 45)) { return "C"; }
            else if ((mark < 45) && (mark >= 40)) { return "C-"; }
            else { return "E"; }
        }
    }
}


