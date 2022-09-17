﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Auto_click_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        [DllImport("Auto_click.dll")]
        static extern bool CheckNum(string text);
        [DllImport("Auto_click.dll")]
        static extern bool Click(double keep, double gap, double stay);
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            if (keep_data.Text == "" || gap_data.Text == "" || stay_data.Text == "")
            {
                MessageBox.Show ("输入不能为空!");
                return;
            }
            if (CheckNum (keep_data.Text) == false || CheckNum(gap_data.Text) == false || CheckNum(stay_data.Text) == false)
            {
                MessageBox.Show ("数字不合法!");
                return;
            }
            Run.IsEnabled = false;
            double keep = double.Parse(keep_data.Text), gap = double.Parse(gap_data.Text), stay = double.Parse(stay_data.Text);
            Click(keep, gap, stay);
            Run.IsEnabled = true;
        }
    }
}
