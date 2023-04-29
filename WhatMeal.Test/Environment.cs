﻿using WhatMeal.Model;

namespace WhatMeal.Test;

internal static class Environment
{
    internal const string DATA_FOLDER = @"C:\\whatmeal\\data";

    internal static Dish TEST_DISH = new("Petto di pollo alla piastra", DishType.CARNE, new List<string> { "Pollo", "Aromi" });
}
