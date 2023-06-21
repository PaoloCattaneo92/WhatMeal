using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WhatMeal.Model;

namespace WhatMeal.Client;

internal class DishTypeToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not List<DishType> types)
        {
            return Visibility.Collapsed;
        }

        if (!int.TryParse(parameter.ToString(),out int index))
        {
            return Visibility.Collapsed;
        }

        if (types.Count <= index)
        {
            return Visibility.Collapsed;
        }

        return Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
