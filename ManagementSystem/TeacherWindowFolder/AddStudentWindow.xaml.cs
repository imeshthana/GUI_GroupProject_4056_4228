﻿using ManagementSystem.Teacher;
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

namespace ManagementSystem
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow(AddStudentWindowVM vm)
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
