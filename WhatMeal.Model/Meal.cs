namespace WhatMeal.Model;

public record Meal(
    MealType Type,
    List<Dish> Dishes
);