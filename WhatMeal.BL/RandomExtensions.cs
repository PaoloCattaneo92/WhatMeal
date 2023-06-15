namespace WhatMeal.BL;

public static class RandomExtensions
{
    public static E NextEnum<E>(this Random random) where E : struct, Enum
    {
        var values = Enum.GetValues<E>();
        return (E)(values.GetValue(random.Next(values.Length)) ?? default(E));
    }

    public static E NextFromIEnumerable<E>(this Random random, IEnumerable<E> values)
    {
        return (E)(values.ElementAt(random.Next(values.Count())));
    }
}
