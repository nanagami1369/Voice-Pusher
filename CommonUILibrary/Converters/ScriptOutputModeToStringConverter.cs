using System;
using System.Globalization;
using System.Windows.Data;
using System.ComponentModel;
using System.Linq;
namespace CommonUILibrary.Converters
{
    public class ScriptOutputModeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var outputModeFiled = value.GetType().GetField(value.ToString());
            var descriptionAttribute = (DescriptionAttribute)outputModeFiled.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (descriptionAttribute != null)
            {
                return descriptionAttribute.Description;
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
