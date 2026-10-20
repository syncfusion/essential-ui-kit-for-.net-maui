using System.Globalization;
using System.Text.RegularExpressions;
using EssentialMAUIUIKit.Models.Chat;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// This class have methods to convert string to chat-message type.
    /// </summary>
    public class StringToMessageTypeConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to message type.
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

            var label = parameter as Label;
            if (label == null)
            {
                return value;
            }

            var bindingContext = label.BindingContext as ChatItem;
            object messageType;

            switch ((string)value)
            {
                case "Contact":
                    messageType = "John Deo Sync";
                    break;
                case "Text":
                    messageType = bindingContext?.Message ?? string.Empty;
                    break;
                default:
                    messageType = (string)value;
                    break;
            }


            return messageType;
        }

        /// <summary>
        /// This method is used to convert the string to message type.
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

    public class TimeBreakConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            DateTime date;

            if (value is DateTime dt)
            {
                date = dt.Date;
            }
            else if (!DateTime.TryParse(value.ToString(), out date))
            {
                return value.ToString();
            }

            if (date == DateTime.Today)
                return "Today";

            if (date == DateTime.Today.AddDays(-1))
                return "Yesterday";

            return date.ToString("dd MMM yyyy");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
