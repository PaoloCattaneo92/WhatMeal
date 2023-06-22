namespace WhatMeal.Model;

public class WeekValidationRuleFail
{
    public string Description { get; }
    public int Count { get; private set; }

    public void Increment()
    {
        Count++;
    }

    public WeekValidationRuleFail(string name)
    {
        Description = name;
    }

    public override string ToString()
    {
        return $"Rule \"{Description}\" failed {Count} times";
    }
}