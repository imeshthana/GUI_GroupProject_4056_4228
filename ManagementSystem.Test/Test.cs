using FluentAssertions;
using FluentAssertions.Equivalency;
using ManagementSystem.Models;
using System.Collections.ObjectModel;
using System.Reflection;

namespace ManagementSystem.Test
{
    public class Test
    {
        [Fact]
        public void WhenCreatingStudents_List_ShouldBeEmpty()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            students.Count.Should().Be(0);
        }

        [Fact]
        public void WhenCreatingTeachers_List_ShouldBeEmpty()
        {
            ObservableCollection<Academic> teachers = new ObservableCollection<Academic>();
            teachers.Count.Should().Be(0);
        }

        [Fact]
        public void WhenCreatingModuleMarks_List_ShouldBeEmpty()
        {
            ObservableCollection<StudentModule> modulemarks = new ObservableCollection<StudentModule>();
            modulemarks.Count.Should().Be(0);
        }

        [Fact]
        public void WhenAddingStudents_List_ShouldBeNotBeNull()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            Student student = new Student();
            students.Add(student);
            students.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenAddingTeachers_List_ShouldBeNotBeNull()
        {
            ObservableCollection<Academic> teachers = new ObservableCollection<Academic>();
            Academic teacher = new Academic();
            teachers.Add(teacher);
            teachers.Count.Should().NotBe(0);
        }

        [Fact]
        public void WhenAddingModuleMarks_List_ShouldNotBeNull()
        {
            ObservableCollection<StudentModule> modulemarks = new ObservableCollection<StudentModule>();
            StudentModule studentmark = new StudentModule();
            modulemarks.Add(studentmark);
            modulemarks.Count.Should().NotBe(0);
        }

        [Fact]
        public void AddingModuleMarks()
        {
            StudentModule modulemark = new StudentModule();
            modulemark.Mark = 67;

            modulemark.Mark.Should().BeLessThan(100);
            modulemark.Mark.Should().BeGreaterThan(0);
        }

        [Fact]
        public void AddGrade()
        {
            StudentModule modulemark = new StudentModule();
            int mark = 77;
            modulemark.Grade = StudentModule.Func(mark);

            modulemark.Grade.Should().Be("A");
        }

        [Fact]
        public void CalculateGPA()
        {
            Student student = new Student();

            StudentModule module1 = new StudentModule();
            module1.Mark = 85;
            module1.Grade = StudentModule.Func(module1.Mark);
            StudentModule module2 = new StudentModule();
            module2.Mark = 70;
            module2.Grade = StudentModule.Func(module2.Mark);
            StudentModule module3 = new StudentModule();
            module3.Mark = 50;
            module3.Grade = StudentModule.Func(module3.Mark);

            student.StudentModules = new ObservableCollection<StudentModule> { module1, module2, module3 }; 

            var GPA = student.CalGPA(student.StudentModules);

            GPA.Should().BeApproximately(3.33,0.1);
        }
    }
}