namespace WhatMeal.Model;

public record Meal(
    SingleDish Carbo,
    SingleDish Protein,
    SingleDish Vegetables
);