using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpliPassMobile.Converters
{
    /// <summary>
    /// Converter that converts a double value to color based on red to green scale
    /// </summary>
    public class DoubleToFontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
            {
                return null;
            }
            if ((double)value < 5 || (double)value >= 8)
            {
                return Color.White;
            }
            return Color.Black;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
