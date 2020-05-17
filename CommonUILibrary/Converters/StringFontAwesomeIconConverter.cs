using System;
using System.Globalization;
using System.Windows.Data;
using FontAwesome.WPF;

namespace CommonUILibrary.Converters
{
    public class StringFontAwesomeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string inputString)) return FontAwesomeIcon.None;
            if (Enum.TryParse(inputString, out FontAwesomeIcon icon)) return icon;
            return FontAwesomeIcon.None;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is FontAwesomeIcon inputIcon)) return Binding.DoNothing;

            return Enum.GetName(typeof(FontAwesomeIcon), inputIcon);
        }
    }
}
