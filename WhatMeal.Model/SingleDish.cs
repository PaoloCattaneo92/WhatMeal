using JsonDb;

namespace WhatMeal.Model;

public record SingleDish
(
    [property:JsonKey]
    string Name,
    DishType Type,
    List<string> Ingredients
);
