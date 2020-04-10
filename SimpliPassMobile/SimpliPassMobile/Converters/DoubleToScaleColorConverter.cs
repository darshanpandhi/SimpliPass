using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpliPassMobile.Converters
{
    /// <summary>
    /// Converter that converts a double value to color based on red to green scale
    /// </summary>
    public class DoubleToScaleColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
            {
                return null;
            }
            if ((double)value < 5)
            {
                return Color.FromHex("#3EA743");
            }
            if ((double)value < 8)
            {
                return Color.FromHex("#FABF00");
            }

            return Color.FromHex("#D43342");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
