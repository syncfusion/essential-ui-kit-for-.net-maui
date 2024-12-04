using System.Globalization;

namespace EssentialMAUIUIKit.Converters
{
    public class DynamicResourceToColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the DynamicResource to color.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the color.</returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            if (!(value is DynamicResourceExtension dynamicResource))
            {
                return value;
            }

            if (Application.Current?.Resources.TryGetValue(dynamicResource.Key, out var color) == true && color is Color)
            {
                return (Color)color;
            }

            return null;
        }

        /// <summary>
        /// This method is used to convert the color to DynamicResource.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
