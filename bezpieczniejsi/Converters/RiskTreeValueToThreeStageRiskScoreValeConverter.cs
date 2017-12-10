using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using bezpieczniejsi;
namespace bezpieczniejsi.Converters
{
    public class RiskTreeValueToThreeStageRiskScoreValeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ThreeStageRiskScoreVale)
            {
                ThreeStageRiskScoreVale realValue = (ThreeStageRiskScoreVale)value;
                return ((int)realValue).ToString();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string && targetType.ToString() == "bezpieczniejsi.ThreeStageRiskScoreVale")
            {
                int realValue = Int32.Parse(value as string);
                return (ThreeStageRiskScoreVale)realValue;
            }

            return value;
        }
    }
}
