using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WhatMeal.BL;
using WhatMeal.DAL;
using WhatMeal.Model;

namespace WhatMeal.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DATA_FOLDER = "C:\\whatmeal\\data";

        private List<Dish> dishes = Enumerable.Empty<Dish>().ToList();

        public MainWindow()
        {
            InitializeComponent();
            InitComboBoxes();

            JsonMealRepository.Instance = new JsonMealRepository(DATA_FOLDER);
        }

        private void InitComboBoxes()
        {
            cbTypeAdd.ItemsSource = Enum.GetValues<DishType>();
            cbTypeList.ItemsSource = Enum.GetValues<DishType>();
            cbTypeGetRandom.ItemsSource = Enum.GetValues<DishType>();
            cbTypeAdd.SelectedIndex = 0;
            cbTypeList.SelectedIndex = 0;
            cbTypeGetRandom.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dishes = WhatMealBL.Dish.GetAll();
            UpdateItemSource(lvDishes, dishes);
        }

        private void cbTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = (DishType)cbTypeList.SelectedItem;
            var filtered = type != DishType.ALL
                ? dishes.Where(d => d.Type == type)
                : dishes;
            UpdateItemSource(lvDishes, filtered);
        }

        private void UpdateItemSource(ListView listView, IEnumerable<Dish> values)
        {
            listView.ItemsSource = null;
            listView.ItemsSource = values;
        }

        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            var dish = new Dish(
                tbName.Text, 
                (DishType)cbTypeAdd.SelectedItem, 
                tbIngredients.Text.Split(',').Select(i => i.Trim()).ToList());
            dishes.Add(dish);
            WhatMealBL.Dish.InsertUpdate(dish);
            cbTypeList_SelectionChanged(null, null);
        }

        private void btnGetRandom_Click(object sender, RoutedEventArgs e)
        {
            if(!int.TryParse(tbGetRandomCount.Text, out int count))
            {
                MessageBox.Show("Cannot parse how many dishes", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var type = (DishType)cbTypeGetRandom.SelectedItem;

            var randomized = WhatMealBL.Dish.GetRandom(count, type, dishes);
            UpdateItemSource(lvRandomized, randomized);
        }

        private void btnWeek_Click(object sender, RoutedEventArgs e)
        {
            var weekPlan = new WeekPlan();
        }
    }
}
