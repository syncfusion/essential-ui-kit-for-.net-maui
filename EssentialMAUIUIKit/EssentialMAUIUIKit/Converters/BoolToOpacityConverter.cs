using System.Globalization;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// Converts a boolean value to an opacity value for hover effects.
    /// True = 0.1 (10% opacity), False = 0 (0% opacity)
    /// </summary>
    public class BoolToOpacityConverter : IValueConverter
    {
        /// <summary>
        /// Converts boolean to opacity value
        /// </summary>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? 0.1 : 0.0;
            }
            return 0.0;
        }

        /// <summary>
        /// Converts opacity value back to boolean
        /// </summary>
        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double opacity)
            {
                return opacity > 0.05;
            }
            return false;
        }
    }
}
