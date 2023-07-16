using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagementSystem.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherLoginWindow.xaml
    /// </summary>
    public partial class TeacherLoginWindow : Window
    {
        public TeacherLoginWindow(TeacherLoginWindowVM vm)
        {
            InitializeComponent();
            DataContext = vm;
            vm.Close = () => Close();
        }
        private void Quit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
