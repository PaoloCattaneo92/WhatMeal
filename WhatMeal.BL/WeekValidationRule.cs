using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatMeal.Model;

namespace WhatMeal.BL;

public class WeekValidationRule
{
    public string Description { get; }

    private readonly Func<Week, bool> validation;

    public WeekValidationRule(string description, Func<Week, bool> validation)
    {
        this.Description = description;
        this.validation = validation;
    }

    public bool Validate(Week week)
    {
        return validation?.Invoke(week) ?? true;
    }

    public static readonly List<WeekValidationRule> Default = new()
    {
        new WeekValidationRule("No same meal on lunch/dinner of same day", (w) => !w.Days.Any(d => SameSomething(d.Dinner, d.Lunch))),
        new WeekValidationRule("Fish 2/3 times per week", (w) =>
        {
            var count = w.Days.SelectMany(d => d.AllDishes).Where(d => d.Types.Any(t => t == DishType.FISH)).Count();
            return count >= 2 && count <= 3;
        }),
        new WeekValidationRule("Red meat max 3 times per week", (w) =>
        {
            var count = w.Days.SelectMany(d => d.AllDishes).Where(d => d.Types.Any(t => t == DishType.MEAT_RED)).Count();
            return count <= 3;
        }),
        new WeekValidationRule("No same meal 3 times in the week", (w) =>
        {
            var allDishesNames = w.Days.SelectMany(d => d.AllDishes).Select(d => d.Name);
            var distinctNames = allDishesNames.Distinct();
            foreach(var name in distinctNames)
            {
                var count = allDishesNames.Count(n => n == name);
                if(count > 2)
                {
                    return false;
                }
            }

            return true;
        }),
        new WeekValidationRule("No double carbo on lunch or dinner", (w) => !w.Days.Any(d => d.Lunch.CountForElement(ElementType.CARBO) >= 2 || d.Dinner.CountForElement(ElementType.CARBO) >= 2)),
    };

    private static bool SameSomething(Meal lunch, Meal dinner)
    {
        var allDishes = lunch.Dishes.ToList();
        allDishes.AddRange(dinner.Dishes);
        var distincts = allDishes.DistinctBy(d => d.Name).Count();
        return distincts != allDishes.Count;
    }
}
