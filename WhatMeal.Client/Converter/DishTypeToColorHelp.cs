using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WhatMeal.Model;

namespace WhatMeal.Client;

internal class DishTypeToColorHelp
{
    public static readonly Brush NOT_FOUND = Brushes.Gray;

    public static readonly Dictionary<DishType, Brush> COLOR_DICT = new()
        {
            { DishType.PASTA, Brushes.Yellow },
            { DishType.VEGAN_PROTEIN, Brushes.Olive },
            { DishType.MEAT_RED, Brushes.Red },
            { DishType.VEGETABLES, Brushes.Green },
            { DishType.FISH, Brushes.LightBlue },
            { DishType.OTHER_PROTEIN, Brushes.Orange },
            { DishType.RICE, Brushes.Wheat },
            { DishType.MEAT_WHITE, Brushes.Gold },
            { DishType.OTHER_CARBO, Brushes.LightPink }
        };

    public static Brush Convert(DishType type)
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
}
