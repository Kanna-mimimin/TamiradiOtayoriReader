using System;
using System.Collections.Generic;
using System.Text;

namespace TamiradiOtayoriReader.Converters
{
    class IndexNo2DStringVisualNoConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var param = 0;

            if(parameter is int)
            {
                param = (int)parameter;
            }

            return (int)value + 1 + param;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return int.Parse((string)value) - 1 - (int)parameter;
        }
    }

}
