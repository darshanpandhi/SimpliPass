using System;
using System.Globalization;
using Xamarin.Forms;

namespace SimpliPassMobile.Converters
{
    /// <summary>
    /// Converter that converts an Image file path to ImageSource
    /// </summary>
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
            {
                return null;
            }
            var path = value as string;
            return ImageSource.FromFile(path);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
