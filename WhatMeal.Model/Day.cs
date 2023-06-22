using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public class Day {
    public Meal Lunch { get; }
    public Meal Dinner { get; }
    public List<Dish> AllDishes => Lunch.Dishes.Concat(Dinner.Dishes).ToList();

    public Day(Meal lunch, Meal dinner)
    {
        Lunch = lunch;
        Dinner = dinner;
    }
}