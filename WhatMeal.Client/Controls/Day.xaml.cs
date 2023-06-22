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
    /// Interaction logic for Day.xaml
    /// </summary>
    public partial class Day : UserControl
    {
        public Day()
        {
            InitializeComponent();
        }

        public Day(Model.Day day, int index) : this()
        {
            var dayName = "";
            switch(index)
            {
                case 0: dayName = "Monday"; break;
                case 1: dayName = "Tuesday"; break;
                case 2: dayName = "Wednesday"; break;
                case 3: dayName = "Thursday"; break;
                case 4: dayName = "Friday"; break;
                case 5: dayName = "Saturday"; break;
                case 6: dayName = "Sunday"; break;
            }

            txtDayName.Text = dayName;
            lvLunchDishes.ItemsSource = day.Lunch.Dishes;
            lvDinnerDishes.ItemsSource = day.Dinner.Dishes;
        }
    }
}
