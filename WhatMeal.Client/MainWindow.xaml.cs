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
            cbTypeAdd.ItemsSource = Enum.GetValues<DishType>();
            cbTypeList.ItemsSource = Enum.GetValues<DishType>();
            cbTypeAdd.SelectedIndex = 0;
            cbTypeList.SelectedIndex = 0;

            JsonMealRepository.Instance = new JsonMealRepository(DATA_FOLDER);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dishes = WhatMealBL.Dish.GetAll();
            UpdateItemSource(lvDishes, dishes);
        }

        private void cbTypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type = (DishType)cbTypeList.SelectedIndex;
            var filtered = type != DishType.ALL
                ? dishes.Where(d => d.Type == type)
                : dishes;
            UpdateItemSource(lvDishes, filtered);
        }

        private void UpdateItemSource(ListView listView, IEnumerable<Dish> values)
        {
            listView.ItemsSource = null;
            listView.SelectedItem = values;
        }

        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            var dish = new Dish(
                tbName.Text, 
                (DishType)cbTypeAdd.SelectedIndex, 
                tbIngredients.Text.Split(',').Select(i => i.Trim()).ToList());
            WhatMealBL.Dish.InsertUpdate(dish);
        }
    }
}
