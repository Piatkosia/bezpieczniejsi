using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace bezpieczniejsi.Converters
{
    public class RiskThreeToReturnString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int num = (int)value;
                if (num == 1) return "Małe"; // zregionalizuje się później
                if (num == 2) return "Średnie";
                if (num == 3) return "Duże";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
