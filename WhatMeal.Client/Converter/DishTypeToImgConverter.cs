using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using WhatMeal.Model;

namespace WhatMeal.Client
{
    internal class DishTypeToImgConverter : IValueConverter
    {
        private const string NOT_FOUND = "img/browser.png";

        private readonly Dictionary<DishType, string> imageDictionary = new()
        {
            { DishType.PASTA, "img/spaguetti.png" },
            { DishType.CARNE_BIANCA, "img/chicken-leg.png" }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not List<DishType> types)
            {
                return NOT_FOUND;
            }

            var dt = types.FirstOrDefault();
            if(dt == DishType.ALL)
            {
                return NOT_FOUND;
            }
            
            if(!imageDictionary.TryGetValue(dt, out string? imageValue))
            {
                return NOT_FOUND;
            }

            return imageValue ?? NOT_FOUND;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
