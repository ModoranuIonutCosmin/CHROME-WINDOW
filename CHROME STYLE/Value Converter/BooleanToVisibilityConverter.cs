using System;
using System.Globalization;
using System.Windows;

namespace CHROME_STYLE
{
    public class BooleanToVisibilityConverter : BaseConverter<BooleanToVisibilityConverter>
    {

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter == null)
            {
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            }
            else
            {
                return (bool)value == false ? Visibility.Hidden : Visibility.Visible;
            }

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
