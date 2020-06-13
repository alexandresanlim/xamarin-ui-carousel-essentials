using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace App.CardTools.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NumberFormatInfo nfi = culture.NumberFormat;
            return Decimal.Parse(value.ToString()).ToString("C");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0m;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0m;

            if (valueLong <= 0)
                return 0m;

            return valueLong / 100m;
        }
    }
}
