using System.Globalization;
using Syncfusion.Maui.Chat;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// Maps an <see cref="IMessage"/> instance to common chat-bubble properties such as
    /// incoming/outgoing state, bubble color, and alignment based on the supplied
    /// <see cref="IValueConverter.Convert"/> parameter.
    /// </summary>
    public class MessageTypeConverter : IValueConverter
    {
        public MessageTypeConverter()
        {
            // ✅ Subscribe to theme changes so the converter's output stays in sync.
            if (Application.Current != null)
            {
                Application.Current.RequestedThemeChanged += (s, e) => ThemeChanged?.Invoke();
            }
        }

        /// <summary>
        /// Custom event raised when the application theme changes.
        /// </summary>
        public static event Action? ThemeChanged;

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not IMessage msg)
            {
                return null;
            }

            bool isOutgoing = msg.Author?.Name == "You";
            string? param = parameter?.ToString();

            return param switch
            {
                "IsIncoming" => !isOutgoing,
                "IsOutgoing" => isOutgoing,
                "BubbleColor" => GetBubbleColor(isOutgoing),
                "Alignment" => isOutgoing ? LayoutOptions.End : LayoutOptions.Start,
                _ => null
            };
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();

        private static Color GetBubbleColor(bool isOutgoing)
        {
            bool isDark = Application.Current?.RequestedTheme == AppTheme.Dark;

            if (isDark)
            {
                return isOutgoing
                    ? Color.FromArgb("#35303C")   // outgoing dark
                    : Color.FromArgb("#1C1B1D");  // incoming dark
            }

            return isOutgoing
                ? Color.FromArgb("#F7EDFF")       // outgoing light
                : Color.FromArgb("#FCF8FA");      // incoming light
        }
    }

    /// <summary>
    /// Returns <c>true</c> when the bound value is a <see cref="TextMessage"/>.
    /// </summary>
    public class IsTextMessageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            => value is TextMessage;

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    /// <summary>
    /// Returns <c>true</c> when the bound value is an <see cref="ImageMessage"/>.
    /// </summary>
    public class IsImageMessageConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            => value is ImageMessage;

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    /// <summary>
    /// Maps an <see cref="IMessage"/> to a <see cref="LayoutOptions"/> based on whether
    /// the message belongs to the current user (outgoing → end) or the chat partner
    /// (incoming → start). Uses the <see cref="SfChat"/> referenced from XAML as
    /// the comparison source.
    /// </summary>
    public class MessageAlignmentConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not IMessage message || parameter is not SfChat chat)
            {
                return LayoutOptions.Start;
            }

            return message.Author == chat.CurrentUser
                ? LayoutOptions.End   // ✅ Outgoing
                : LayoutOptions.Start; // ✅ Incoming
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => null;
    }
}
