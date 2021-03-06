﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TamiradiOtayoriReader.Converters
{
    class IndexNo2DoubleVisualNoConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value + 1;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value - 1;
        }
    }
}
