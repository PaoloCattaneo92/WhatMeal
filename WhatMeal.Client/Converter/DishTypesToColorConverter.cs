using System;
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
    public static readonly Brush NOT_FOUND = Brushes.Gray;

    public static readonly Dictionary<DishType, Brush> COLOR_DICT = new()
        {
            { DishType.PASTA, Brushes.Yellow },
            { DishType.PROTEINE_VEGANE, Brushes.Olive },
            { DishType.CARNE_ROSSA, Brushes.Red },
            { DishType.VERDURE, Brushes.Green },
            { DishType.PESCE, Brushes.LightBlue },
            { DishType.ALTRE_PROTEINE, Brushes.Orange },
            { DishType.RISO, Brushes.Wheat },
            { DishType.CARNE_BIANCA, Brushes.Beige },
            { DishType.ALTRI_CARBO, Brushes.LightPink }
        };

    public static Brush ConvertSingle(DishType type)
    {
        if (type == DishType.ALL)
        {
            return NOT_FOUND;
        }

        if (!COLOR_DICT.TryGetValue(type, out Brush? colorValue))
        {
            return NOT_FOUND;
        }

        return colorValue ?? NOT_FOUND;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not List<DishType> types)
        {
            return NOT_FOUND;
        }

        if(!int.TryParse(parameter.ToString(), out int index))
        {
            return NOT_FOUND;
        }

        if (types.Count <= index)
        {
            return NOT_FOUND;
        }

        var dt = types[index];
        return ConvertSingle(dt);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
