using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public static class DishTypeHelp
{
    private record Boundaries(int Min, int Max);

    private static Boundaries GetBoundaries(ElementType element)
    {
        var id = (int)element;
        var min = id * 100;
        var max = min + 99;
        return new Boundaries(min, max);
    }

    public static IEnumerable<DishType> For(ElementType element)
    {
        var boundaries = GetBoundaries(element);
        return Enum.GetValues<DishType>().Where(dt => (int)dt >= boundaries.Min && (int)dt <= boundaries.Max);
    }

    public static bool IsFor(this DishType type, ElementType element)
    {
        var boundaries = GetBoundaries(element);
        return (int)type >= boundaries.Min && (int)type <= boundaries.Max;
    }
}
