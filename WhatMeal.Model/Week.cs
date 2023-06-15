using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public class Week
{
    public Day[] Days { get; } = new Day[7];

    public Week()
    {
    }

    public string Description()
    {
        var buff = "Week description: \n";
        for (int i = 0; i < Days.Length; i++)
        {
            buff += "[" + (i + 1) + "] Pranzo: " + Days[i].Lunch.Carbo.Name + " | " + Days[i].Lunch.Protein.Name + " | " + Days[i].Lunch.Vegetables.Name + "\n";
            buff += "[" + (i + 1) + "] Cena: " + Days[i].Dinner.Carbo.Name + " | " + Days[i].Dinner.Protein.Name + " | " + Days[i].Dinner.Vegetables.Name + "\n";
            buff += "\n";
        }
        return buff;
    }
}
