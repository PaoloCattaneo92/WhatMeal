using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Test;

internal class UTGetDish : UTWithDAL
{
    [SetUp]
    public void Setup()
    {
        repository.InsertUpdateDish(Environment.TEST_DISH);
    }

    [Test]
    public void Test()
    {
        var dishes = repository.GetDishes();
        Assert.That(dishes, Is.Not.Null);
        Assert.That(dishes, Is.Not.Empty);
        var testFound = dishes.FirstOrDefault(d => d.Name == Environment.TEST_DISH.Name);
        Assert.That(testFound, Is.Not.Null);
    }
}
