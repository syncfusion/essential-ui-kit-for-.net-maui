using System.Globalization;

namespace EssentialMAUIUIKit.Converters;

/// <summary>
/// Returns <c>true</c> when the bound string is null or empty, and <c>false</c> otherwise.
/// Inverse of <see cref="StringNotEmptyConverter"/>.
/// </summary>
public class InvertStringNotEmptyConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => string.IsNullOrEmpty(value?.ToString());

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
