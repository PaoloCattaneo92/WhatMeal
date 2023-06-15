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
using WhatMeal.BL;
using WhatMeal.Model;

namespace WhatMeal.Client
{
    /// <summary>
    /// Interaction logic for WeekPlan.xaml
    /// </summary>
    public partial class WeekPlan : Window
    {
        private readonly Meal[,] meals = new Meal[7, 7];

        private readonly List<Dish> dishes;

        public WeekPlan()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                
            }
            dishes = WhatMealBL.Dish.GetAll();
            var week = WhatMealBL.RandomizeWeek(dishes);
            MessageBox.Show(week.Description());
        }
    }
}
