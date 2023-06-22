using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WhatMeal.Model;

namespace WhatMeal.Client;

internal class DishTypesToNameConverter : IValueConverter
{
    private const string NA = "N.A.";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not List<DishType> types)
        {
            return NA;
        }

        if (!int.TryParse(parameter.ToString(), out int index))
        {
            return NA;
        }

        if (types.Count <= index)
        {
            return NA;
        }

        var dt = types[index];
        return dt.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
