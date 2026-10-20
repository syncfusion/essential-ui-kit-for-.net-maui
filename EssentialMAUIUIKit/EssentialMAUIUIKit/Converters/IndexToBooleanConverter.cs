using System.Globalization;

namespace EssentialMAUIUIKit.Converters
{
    /// <summary>
    /// Converts an integer index into a boolean based on the <see cref="IValueConverter.Convert"/>
    /// parameter. Used by the Company History timeline to alternate left/right cards
    /// and to hide connectors after the last item.
    /// </summary>
    /// <remarks>
    /// Supported <c>parameter</c> values:
    /// <list type="bullet">
    /// <item><c>Even</c>  – returns <c>true</c> when the index is even.</item>
    /// <item><c>Odd</c>   – returns <c>true</c> when the index is odd.</item>
    /// <item><c>NotLast</c> – returns <c>true</c> when the index is less than the
    ///   count passed via <c>ConverterParameter</c> in the form <c>NotLast:N</c>.</item>
    /// </list>
    /// </remarks>
    public class IndexToBooleanConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not int index || parameter is null)
            {
                return false;
            }

            string mode = parameter.ToString() ?? string.Empty;

            return mode switch
            {
                "Even" => index % 2 == 0,
                "Odd" => index % 2 != 0,
                _ when mode.StartsWith("NotLast:", StringComparison.Ordinal) =>
                    int.TryParse(mode.AsSpan("NotLast:".Length), out int total) && index < total - 1,
                _ => false
            };
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
