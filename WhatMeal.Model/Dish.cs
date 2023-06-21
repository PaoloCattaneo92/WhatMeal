using JsonDb;

namespace WhatMeal.Model;

public record Dish
(
    [property:JsonKey]
    string Name,
    List<DishType> Types,
    List<string> Ingredients
);