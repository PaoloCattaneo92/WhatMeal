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
using WhatMeal.Model;

namespace WhatMeal.Client.Controls
{
    /// <summary>
    /// Interaction logic for DishTypeCheckBox.xaml
    /// </summary>
    public partial class DishTypeCheckBox : UserControl
    {
        public DishType Type { get; } = DishType.ALL;
        public bool IsChecked => coloredCheckBox?.IsChecked ?? false;

        public DishTypeCheckBox()
        {
            InitializeComponent();
        }

        public DishTypeCheckBox(DishType type) : this()
        {
            Type = type;
            txtName.Text = type.ToString();
            coloredCheckBox.BackgroundColor = DishTypeToColorHelp.Convert(type);
        }
    }
}
