using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model
{
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
            new WeekValidationRule("No same meal on lunch/dinner of same day", (w) => !w.Days.Any(d => SameSomething(d.Dinner, d.Lunch)))
        };

        private static bool SameSomething(Meal meal, Meal otherMeal)
        {
            return meal.Carbo.Name == otherMeal.Carbo.Name
                || meal.Protein.Name == otherMeal.Protein.Name
                || meal.Vegetables == otherMeal.Vegetables;
        }
    }
}
