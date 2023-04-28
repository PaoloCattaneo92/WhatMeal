using JsonDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public record Dish
(
    [property:JsonKey]
    string Name,
    DishType Type,
    List<string> Ingredients
);
