using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatMeal.Model;

public record WeekRandomizeResult
(
    bool Success,
    Week? Result,
    int Tries,
    List<WeekValidationRuleFail> Failures
    );
