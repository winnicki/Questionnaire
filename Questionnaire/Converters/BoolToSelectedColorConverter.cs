using System.Globalization;

namespace Questionnaire.Converters;

public class BooleanToColorConverter : IValueConverter
{
    private readonly Color 
        _green = Color.FromArgb("#FF00FF00"),
        _grey = Color.FromArgb("#FF808080");
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? _green : _grey; 
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var color = (Color) value;
        return color.Equals(_green);
    }
}
