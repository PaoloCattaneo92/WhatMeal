using JsonDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public record MultiDish
(
    [property: JsonKey]
    string Name,
    List<DishType> Types,
    List<string> Ingredients
);
