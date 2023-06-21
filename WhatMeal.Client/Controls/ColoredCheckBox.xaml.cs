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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WhatMeal.Client.Controls
{
    /// <summary>
    /// Interaction logic for ColoredCheckBox.xaml
    /// </summary>
    public partial class ColoredCheckBox : UserControl
    {
        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                line1.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                line2.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Brush BackgroundColor
        {
            get
            {
                return rectangle.Fill;
            }
            set
            {
                rectangle.Fill = value;
            }
        }

        public ColoredCheckBox()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}
