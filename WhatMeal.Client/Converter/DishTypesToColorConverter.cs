﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WhatMeal.Model;

namespace WhatMeal.Client;

internal class DishTypesToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not List<DishType> types)
        {
            return DishTypeToColorHelp.NOT_FOUND;
        }

        if(!int.TryParse(parameter.ToString(), out int index))
        {
            return DishTypeToColorHelp.NOT_FOUND;
        }

        if (types.Count <= index)
        {
            return DishTypeToColorHelp.NOT_FOUND;
        }

        var dt = types[index];
        return DishTypeToColorHelp.Convert(dt);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
