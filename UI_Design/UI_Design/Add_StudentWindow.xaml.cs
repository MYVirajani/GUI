﻿using Microsoft.Win32;
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

namespace UI_Design
{
    /// <summary>
    /// Interaction logic for Add_StudentWindow.xaml
    /// </summary>
    public partial class Add_StudentWindow : Window
    {

        public Add_StudentWindow(Add_StudentVM window)
        {
            InitializeComponent();

            DataContext = window;
            window.CloseAction = () => Close();
        }

       
       
    }
}
        

                 
