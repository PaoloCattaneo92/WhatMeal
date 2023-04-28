using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.BL;

public static class RandomExtensions
{
    public static E NextEnum<E>(this Random random) where E : struct, Enum
    {
        var values = Enum.GetValues<E>();
        return (E)(values.GetValue(random.Next(values.Length)) ?? default(E));
    }
}
