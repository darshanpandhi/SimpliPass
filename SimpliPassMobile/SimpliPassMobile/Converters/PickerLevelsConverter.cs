using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpliPassMobile.Converters
{
    /// <summary>
    /// Converter that ensures correct indexing and levels of Pickers
    /// </summary>
    public class PickerLevelsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
            {
                return -1;
            }
            return (int)value - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
            {
                return -1;
            }
            return (int)value + 1;
        }
    }
}
