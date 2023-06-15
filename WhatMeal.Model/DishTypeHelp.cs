using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public static class DishTypeHelp
{
    public static IEnumerable<DishType> For(ElementType element)
    {
        var id = (int)element;
        var min = id * 100;
        var max = min + 99;
        return Enum.GetValues<DishType>().Where(dt => (int)dt >= min && (int)dt <= max);
    }
}
