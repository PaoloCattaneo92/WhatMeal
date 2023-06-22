using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WhatMeal.BL;
using WhatMeal.Model;

namespace WhatMeal.Client
{
    /// <summary>
    /// Interaction logic for WeekPlan.xaml
    /// </summary>
    public partial class WeekPlan : Window
    {
        private readonly List<Dish> dishes;
        private readonly List<WeekValidationRule> rules = WeekValidationRule.Default;

        public WeekPlan(WeekRandomizeResult weekResult)
        {
            InitializeComponent();

            if(!weekResult.Success || weekResult.Result == null)
            {
                var buff = $"Week was null after {weekResult.Tries} tries, maybe impossible rules?\n";
                foreach(var fail in weekResult.Failures)
                {
                    buff += $"\n{fail}";
                }
                MessageBox.Show(buff);
                return;
            }

            txtMessage.Text = $"After {weekResult.Tries} tries the week is: ";
            int i = 0;
            var days = weekResult.Result.Days.Select(d => new Controls.Day(d, i++));
            foreach(var day in days)
            {
                spDays.Children.Add(day);
            }
        }
    }
}
