﻿using Lab6.ViewModel;
using System.Windows;

namespace Lab6.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel();
        }
    }
}
