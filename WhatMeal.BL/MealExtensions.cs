using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.Model;

namespace WhatMeal.BL;

public static class MealExtensions
{
    public static bool IsCompleteMeal(this List<Dish> dishes)
    {
        if(dishes == null)
        {
            return false;
        }

        var carbo = dishes.SelectMany(d => d.Types).Any(dt => dt.IsFor(ElementType.CARBO));
        var protein = dishes.SelectMany(d => d.Types).Any(dt => dt.IsFor(ElementType.PROTEIN));
        var vegetables = dishes.SelectMany(d => d.Types).Any(dt => dt.IsFor(ElementType.VEGETABLES));
        
        return carbo && protein && vegetables;
    }

    public static int CountForElement(this Meal meal, ElementType element)
    {
        return meal.Dishes.SelectMany(d => d.Types).Count(dt => dt.IsFor(element));
    }
}
