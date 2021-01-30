using System;
using System.Globalization;
using System.Windows.Data;
using FontAwesome5;

namespace Voice_Pusher.Views.Converter
{
    public class StringFontAwesomeIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string inputString)
            {
                return EFontAwesomeIcon.None;
            }

            var fontName = "Solid_" + inputString;
            if (Enum.TryParse(fontName, out EFontAwesomeIcon icon))
            {
                return icon;
            }

            return EFontAwesomeIcon.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not EFontAwesomeIcon inputIcon)
            {
                return Binding.DoNothing;
            }

            // valueがEFontAwesomeIcon型以外で無い事は、わかっているので、Null Checkを無効化
            return Enum.GetName(typeof(EFontAwesomeIcon), inputIcon)!;
        }
    }
}
