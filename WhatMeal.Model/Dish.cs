using JsonDb;

namespace WhatMeal.Model;

public record Dish
(
    [property:JsonKey]
    string Name,
    DishType Type,
    List<string> Ingredients
);
