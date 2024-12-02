using System.Globalization;
using System.Reflection;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert string value to image.
    /// </summary>
    public class StringToImageResourceConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var imageSource = ImageSource.FromResource((string)value, typeof(StringToImageResourceConverter).GetTypeInfo().Assembly);
            return imageSource;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}