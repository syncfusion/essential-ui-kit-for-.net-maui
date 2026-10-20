using Syncfusion.Maui.Core;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// Maps a chat member's status string to the appropriate <see cref="BadgeIcon"/>.
    /// </summary>
    public class StringToBadgeIconConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return BadgeIcon.None;
            }

            // ✅ Use a plain dot for every known status so the badge shows only the
            // presence color, without any extra icon.
            return value.ToString() switch
            {
                "Available" => BadgeIcon.Dot,
                "Not available" => BadgeIcon.Dot,
                _ => BadgeIcon.None
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// Maps a chat member's status string to a presence color.
    /// </summary>
    public class StatusToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            // ✅ Default → Not Available (Purple)
            if (value == null)
            {
                return Color.FromArgb("#8D4CF5");
            }

            return value.ToString() == "Available"
                ? Color.FromArgb("#3CB053")  // ✅ Green (Available)
                : Color.FromArgb("#8D4CF5"); // ✅ Purple (Not Available)
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => null;
    }
}