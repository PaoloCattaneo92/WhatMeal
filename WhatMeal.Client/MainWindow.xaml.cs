using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WhatMeal.BL;
using WhatMeal.Client.Controls;
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
            InitTypesWrapPanel();

            JsonMealRepository.Instance = new JsonMealRepository(DATA_FOLDER);
        }

        private void InitTypesWrapPanel()
        {
            foreach(var type in Enum.GetValues<DishType>())
            {
                var dtc = new DishTypeCheckBox(type);
                wpTypes.Children.Add(dtc);
            }
        }

        private void InitComboBoxes()
        {
            cbTypeList.ItemsSource = Enum.GetValues<DishType>();
            cbTypeGetRandom.ItemsSource = Enum.GetValues<DishType>();
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
                ? dishes.Where(d => d.Types.Contains(type))
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
            var types = wpTypes.Children.OfType<DishTypeCheckBox>()
                .Where(dtc => dtc.IsChecked)
                .Select(dtc => dtc.Type);

            var dish = new Dish(
                tbName.Text,
                types.ToList(), 
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

            var randomized = DishBL.GetRandom(count, type, dishes);
            UpdateItemSource(lvRandomized, randomized);
        }

        private void btnWeek_Click(object sender, RoutedEventArgs e)
        {
            var weekPlan = new WeekPlan();
        }
    }
}
