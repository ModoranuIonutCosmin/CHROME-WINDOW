﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace CHROME_STYLE
{
    public abstract class BaseConverter<T> : MarkupExtension, IValueConverter
    where T : class, new()
    {
        private static T mConverter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var value = mConverter;
            if (value != null)
            {
                return value;
            }

            return (mConverter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
        
    }
}
