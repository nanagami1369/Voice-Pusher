using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using FontAwesome5;

namespace CommonUILibrary.Converters
{
    public class StringFontAwesomeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string inputString)) return EFontAwesomeIcon.None;
            var soridFontName = "Solid_" + inputString;
            if (Enum.TryParse(soridFontName, out EFontAwesomeIcon icon)) return icon;
            return EFontAwesomeIcon.None;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is EFontAwesomeIcon inputIcon)) return Binding.DoNothing;

            return Enum.GetName(typeof(EFontAwesomeIcon), inputIcon);
        }
    }
}
