using System;
using System.Globalization;
using Xamarin.Forms;

namespace Binder.Converters
{
    public class RentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Is Rent" : "Is Sale";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Equals("Is Rent");
        }
    }
}
