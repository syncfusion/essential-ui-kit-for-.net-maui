using System.Globalization;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the Boolean values to color objects.
    /// </summary>
    public class StringToColorConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the bool to color.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the color.</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter == null || value == null)
            {
                return Colors.Black;
            }

            Color color = Colors.Black; // Default color

            switch (parameter.ToString())
            {
                case "0":
                    {
                        switch ((string)value)
                        {
                            case "Dispatched":
                                if (Application.Current?.Resources.TryGetValue("Blue", out var retBlueObj) == true && retBlueObj is Color retBlue)
                                {
                                    color = retBlue;
                                }

                                break;
                            case "Cancelled":
                                if (Application.Current?.Resources.TryGetValue("Red", out var retRedObj) == true && retRedObj is Color retRed)
                                {
                                    color = retRed;
                                }

                                break;
                            default:
                                if (Application.Current?.Resources.TryGetValue("Green", out var retGreenObj) == true && retGreenObj is Color retGreen)
                                {
                                    color = retGreen;
                                }

                                break;
                        }
                        break;
                    }
                case "1":
                    {
                        switch ((string)value)
                        {
                            case "NotStarted":
                                if (Application.Current?.Resources.TryGetValue("Gray-700", out var gray700Obj) == true && gray700Obj is Color gray700)
                                {
                                    color = gray700;
                                }

                                break;
                            case "InProgress":
                            case "Completed":
                                if (Application.Current?.Resources.TryGetValue("Gray-900", out var gray900Obj) == true && gray900Obj is Color gray900)
                                {
                                    color = gray900;
                                }

                                break;
                            default:
                                color = Colors.Transparent;
                                break;
                        }
                        break;
                    }
                default:
                    color = Colors.Transparent;
                    break;
            }

            return color;
        }

        /// <summary>
        /// This method is used to convert the color to bool.
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
