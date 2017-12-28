using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace bezpieczniejsi.Converters
{
    public class RiskFiveToReturnString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int num = (int)value;
                if (num == 1) return "Bardzo małe";
                if (num == 2) return "Małe"; // zregionalizuje się później
                if (num == 3) return "Średnie";
                if (num == 4) return "Duże";
                if (num == 5) return "Bardzo Duże";
            }
            if (value is ThreeStageRiskScoreVale)
            {
                ThreeStageRiskScoreVale val = (ThreeStageRiskScoreVale)value;
                if (val == ThreeStageRiskScoreVale.Rare) return "Małe";
                if (val == ThreeStageRiskScoreVale.Medium) return "Średnie";
                if (val == ThreeStageRiskScoreVale.Often) return "Duże";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
