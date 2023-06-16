using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public record FullMeal
(
    List<SingleDish> Dishes
);
