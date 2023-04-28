using JsonDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public record Dish
(
    DishType Type,
    [property:JsonKey]
    string Name
);
