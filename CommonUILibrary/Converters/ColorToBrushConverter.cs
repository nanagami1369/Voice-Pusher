using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonUILibrary.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is System.Drawing.Color color)) return Binding.DoNothing;
            var mediaColor = System.Windows.Media.Color.FromRgb(color.R, color.G, color.B);
            return new SolidColorBrush(mediaColor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
