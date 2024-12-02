using System.Globalization;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert the string to font icon text.
    /// </summary>
    public class StringToGlyphConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to font icon text.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (parameter == null || value == null)
            {
                return string.Empty;
            }

            var text = value;
            var label = parameter as Label;

            if (label != null)
            {
                switch ((string)text)
                {
                    case "Text":
                        label.IsVisible = false;
                        return text;
                    case "Viewed":
                    case "New":
                        if (Application.Current?.Resources.TryGetValue("PrimaryColorLight", out var retValObj) == true && retValObj is Color retVal)
                        {
                            label.TextColor = retVal;
                        }

                        break;
                    case "Received": 
                        label.TextColor = Colors.Transparent;
                        return string.Empty;
                    case "Sent":
                        if (Application.Current?.Resources.TryGetValue("Gray-600", out var colorValObj) == true && colorValObj is Color colorVal)
                        {
                            label.TextColor = colorVal;
                        }

                        break;
                    case "Audio":
                    case "Video":
                    case "Contact":
                    case "Photo":
                        label.IsVisible = true;
                        break;
                }

                // Optionally, update the text from resources if needed.
                if (label.Resources.TryGetValue((string)value, out var newText))
                {
                    text = newText;
                }
            }

            return text;
        }

        /// <summary>
        /// This method is used to convert the string to font icon text.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns null.</returns>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}